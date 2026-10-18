namespace aweXpect.Chronology.Tests;

public sealed class TimeSpanBuilderTests
{
	[Fact]
	public async Task MinusOperator_ShouldSubtractTimeSpan()
	{
		TimeSpanBuilder expected = 2.Hours();
		TimeSpanBuilder builder = new(3.Hours());

		TimeSpan result = builder - 1.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Fact]
	public async Task PlusOperator_ShouldAddTimeSpan()
	{
		TimeSpanBuilder expected = 4.Hours();
		TimeSpanBuilder builder = new(3.Hours());

		TimeSpan result = builder + 1.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Fact]
	public async Task MultiplyOperator_ShouldAddTimeSpan()
	{
		TimeSpanBuilder expected = 6.Hours();
		TimeSpanBuilder builder = new(3.Hours());

		TimeSpan result = builder * 2;

		await That(result).IsEqualTo(expected);
	}

	[Fact]
	public async Task MultiplyOperator_WhenMultiplierIsNaN_ShouldThrowArgumentException()
	{
		TimeSpanBuilder builder = new(1.Hours());

		void Act() => _ = builder * double.NaN;

		await That(Act).ThrowsExactly<ArgumentException>()
			.WithParamName("factor").And
			.WithMessage("TimeSpan does not accept floating point Not-a-Number values.*").AsWildcard()
			.Because("the message suffix with the parameter name differs between .NET Framework and .NET");
	}

	[Fact]
	public async Task MultiplyOperator_WhenResultHasFractionalTicks_ShouldRoundToNearestTick()
	{
		TimeSpanBuilder builder = new(TimeSpan.FromTicks(1));

		TimeSpan result = builder * 1.5;

		await That(result).IsEqualTo(TimeSpan.FromTicks(2))
			.Because("the BCL rounds 1.5 ticks instead of truncating them");
	}

	[Fact]
	public async Task MultiplyOperator_WhenResultIsTooLarge_ShouldThrowOverflowException()
	{
		TimeSpanBuilder builder = new(10000.Days());

		void Act() => _ = builder * 1e6;

		await That(Act).ThrowsExactly<OverflowException>()
			.WithMessage("TimeSpan overflowed because the duration is too long.");
	}

	[Fact]
	public async Task DivisionOperator_ShouldAddTimeSpan()
	{
		TimeSpanBuilder expected = 2.Hours();
		TimeSpanBuilder builder = new(3.Hours());

		TimeSpan result = builder / 1.5;

		await That(result).IsEqualTo(expected);
	}

	[Fact]
	public async Task DivisionOperator_WhenDividingZeroByZero_ShouldThrowOverflowException()
	{
		TimeSpanBuilder builder = new(TimeSpan.Zero);

		void Act() => _ = builder / 0.0;

		await That(Act).ThrowsExactly<OverflowException>()
			.WithMessage("TimeSpan overflowed because the duration is too long.")
			.Because("0 / 0.0 is NaN, which the BCL rejects as an overflow");
	}

	[Fact]
	public async Task DivisionOperator_WhenDivisorIsNaN_ShouldThrowArgumentException()
	{
		TimeSpanBuilder builder = new(1.Hours());

		void Act() => _ = builder / double.NaN;

		await That(Act).ThrowsExactly<ArgumentException>()
			.WithParamName("divisor").And
			.WithMessage("TimeSpan does not accept floating point Not-a-Number values.*").AsWildcard()
			.Because("the message suffix with the parameter name differs between .NET Framework and .NET");
	}

	[Fact]
	public async Task DivisionOperator_WhenDivisorIsZero_ShouldThrowOverflowException()
	{
		TimeSpanBuilder builder = new(1.Hours());

		void Act() => _ = builder / 0;

		await That(Act).ThrowsExactly<OverflowException>()
			.WithMessage("TimeSpan overflowed because the duration is too long.");
	}

	[Fact]
	public async Task DivisionOperator_WhenResultHasFractionalTicks_ShouldRoundToNearestTick()
	{
		TimeSpanBuilder builder = new(TimeSpan.FromTicks(3));

		TimeSpan result = builder / 2;

		await That(result).IsEqualTo(TimeSpan.FromTicks(2))
			.Because("the BCL rounds 1.5 ticks instead of truncating them");
	}

	[Fact]
	public async Task UnaryMinusOperator_ShouldReturnNegatedValue()
	{
		TimeSpan expected = TimeSpan.FromHours(-1);

		TimeSpan result = -1.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Fact]
	public async Task ImplicitOperator_ShouldConvertToTimeSpan()
	{
		TimeSpan expected = new(2, 3, 4);
		TimeSpanBuilder builder = new(2.Hours(3.Minutes(4.Seconds())));

		TimeSpan result = builder;

		await That(result).IsEqualTo(expected);
	}

#if NET8_0_OR_GREATER
	[Fact]
	public async Task ImplicitOperator_ShouldConvertToTimeOnly()
	{
		TimeOnly expected = new(2, 3, 4);
		TimeSpanBuilder builder = new(2.Hours(3.Minutes(4.Seconds())));

		TimeOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif
}
