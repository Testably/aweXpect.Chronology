namespace aweXpect.Chronology.Tests;

public sealed class TimeSpanBuilderTests
{
	[Test]
	public async Task MinusOperator_ShouldSubtractTimeSpan()
	{
		TimeSpanBuilder expected = 2.Hours();
		TimeSpanBuilder builder = new(3.Hours());

		TimeSpan result = builder - 1.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task PlusOperator_ShouldAddTimeSpan()
	{
		TimeSpanBuilder expected = 4.Hours();
		TimeSpanBuilder builder = new(3.Hours());

		TimeSpan result = builder + 1.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task MultiplyOperator_ShouldAddTimeSpan()
	{
		TimeSpanBuilder expected = 6.Hours();
		TimeSpanBuilder builder = new(3.Hours());

		TimeSpan result = builder * 2;

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task MultiplyOperator_WithMultiplierFirst_ShouldMultiplyTimeSpan()
	{
		TimeSpanBuilder expected = 6.Hours();
		TimeSpanBuilder builder = new(3.Hours());

		TimeSpan result = 2 * builder;

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task MultiplyOperator_WithMultiplierFirst_WhenMultiplierIsNaN_ShouldThrowArgumentException()
	{
		TimeSpanBuilder builder = new(1.Hours());

		void Act() => _ = double.NaN * builder;

		await That(Act).ThrowsExactly<ArgumentException>()
			.WithParamName("factor").And
			.WithMessage("TimeSpan does not accept floating point Not-a-Number values.*").AsWildcard()
			.Because("the operator delegates to the one with the multiplier second, like the BCL");
	}

	[Test]
	public async Task MultiplyOperator_WhenMultiplierIsNaN_ShouldThrowArgumentException()
	{
		TimeSpanBuilder builder = new(1.Hours());

		void Act() => _ = builder * double.NaN;

		await That(Act).ThrowsExactly<ArgumentException>()
			.WithParamName("factor").And
			.WithMessage("TimeSpan does not accept floating point Not-a-Number values.*").AsWildcard()
			.Because("the message suffix with the parameter name differs between .NET Framework and .NET");
	}

	[Test]
	public async Task MultiplyOperator_WhenResultHasFractionalTicks_ShouldRoundToNearestTick()
	{
		TimeSpanBuilder builder = new(TimeSpan.FromTicks(1));

		TimeSpan result = builder * 1.5;

		await That(result).IsEqualTo(TimeSpan.FromTicks(2))
			.Because("the BCL rounds 1.5 ticks instead of truncating them");
	}

	[Test]
	public async Task MultiplyOperator_WhenResultIsTooLarge_ShouldThrowOverflowException()
	{
		TimeSpanBuilder builder = new(10000.Days());

		void Act() => _ = builder * 1e6;

		await That(Act).ThrowsExactly<OverflowException>()
			.WithMessage("TimeSpan overflowed because the duration is too long.");
	}

	[Test]
	public async Task DivisionOperator_ShouldAddTimeSpan()
	{
		TimeSpanBuilder expected = 2.Hours();
		TimeSpanBuilder builder = new(3.Hours());

		TimeSpan result = builder / 1.5;

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task DivisionOperator_WhenDividingZeroByZero_ShouldThrowOverflowException()
	{
		TimeSpanBuilder builder = new(TimeSpan.Zero);

		void Act() => _ = builder / 0.0;

		await That(Act).ThrowsExactly<OverflowException>()
			.WithMessage("TimeSpan overflowed because the duration is too long.")
			.Because("0 / 0.0 is NaN, which the BCL rejects as an overflow");
	}

	[Test]
	public async Task DivisionOperator_WhenDivisorIsNaN_ShouldThrowArgumentException()
	{
		TimeSpanBuilder builder = new(1.Hours());

		void Act() => _ = builder / double.NaN;

		await That(Act).ThrowsExactly<ArgumentException>()
			.WithParamName("divisor").And
			.WithMessage("TimeSpan does not accept floating point Not-a-Number values.*").AsWildcard()
			.Because("the message suffix with the parameter name differs between .NET Framework and .NET");
	}

	[Test]
	public async Task DivisionOperator_WhenDivisorIsZero_ShouldThrowOverflowException()
	{
		TimeSpanBuilder builder = new(1.Hours());

		void Act() => _ = builder / 0;

		await That(Act).ThrowsExactly<OverflowException>()
			.WithMessage("TimeSpan overflowed because the duration is too long.");
	}

	[Test]
	public async Task DivisionOperator_WhenResultHasFractionalTicks_ShouldRoundToNearestTick()
	{
		TimeSpanBuilder builder = new(TimeSpan.FromTicks(3));

		TimeSpan result = builder / 2;

		await That(result).IsEqualTo(TimeSpan.FromTicks(2))
			.Because("the BCL rounds 1.5 ticks instead of truncating them");
	}

	[Test]
	public async Task UnaryMinusOperator_ShouldReturnNegatedValue()
	{
		TimeSpan expected = TimeSpan.FromHours(-1);

		TimeSpan result = -1.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task ImplicitOperator_ShouldConvertToTimeSpan()
	{
		TimeSpan expected = new(2, 3, 4);
		TimeSpanBuilder builder = new(2.Hours(3.Minutes(4.Seconds())));

		TimeSpan result = builder;

		await That(result).IsEqualTo(expected);
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToTimeOnly()
	{
		TimeOnly expected = new(2, 3, 4);
		TimeSpanBuilder builder = new(2.Hours(3.Minutes(4.Seconds())));

		TimeOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif

	[Test]
	public async Task ToString_ShouldReturnTimeSpanString()
	{
		TimeSpanBuilder builder = 1.Days(2.Hours(30.Minutes()));

		string result = $"{builder}";

		await That(result).IsEqualTo("1.02:30:00")
			.Because("string interpolation should print the value instead of the type name");
	}

	[Test]
	[Arguments(60, 60, true)]
	[Arguments(60, 61, false)]
	public async Task Equals_ShouldCompareTimeSpans(int leftSeconds, int rightSeconds, bool expected)
	{
		TimeSpanBuilder left = leftSeconds.Seconds();
		TimeSpanBuilder right = rightSeconds.Seconds();

		bool result = left.Equals(right);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task Equals_WithObject_WhenBuilderHasSameTimeSpan_ShouldReturnTrue()
	{
		TimeSpanBuilder builder = 1.Minutes();
		object other = 60.Seconds();

		bool result = builder.Equals(other);

		await That(result).IsTrue();
	}

	[Test]
	public async Task Equals_WithObject_WhenBuilderHasDifferentTimeSpan_ShouldReturnFalse()
	{
		TimeSpanBuilder builder = 1.Minutes();
		object other = 61.Seconds();

		bool result = builder.Equals(other);

		await That(result).IsFalse();
	}

	[Test]
	public async Task Equals_WithObject_WhenTimeSpan_ShouldReturnFalse()
	{
		TimeSpanBuilder builder = 1.Minutes();
		object other = TimeSpan.FromMinutes(1);

		bool result = builder.Equals(other);

		await That(result).IsFalse()
			.Because("TimeSpan.Equals(builder) is false, so the equality must not be one-sided");
	}

	[Test]
	public async Task Equals_WithObject_WhenNull_ShouldReturnFalse()
	{
		TimeSpanBuilder builder = 1.Minutes();

		bool result = builder.Equals(null);

		await That(result).IsFalse();
	}

	[Test]
	public async Task GetHashCode_ShouldBeEqualForEqualTimeSpans()
	{
		TimeSpanBuilder builder = 1.Minutes();

		int result = 60.Seconds().GetHashCode();

		await That(result).IsEqualTo(builder.GetHashCode());
	}

	[Test]
	public async Task GetHashCode_ShouldUseTimeSpanHashCode()
	{
		TimeSpanBuilder builder = 1.Minutes();

		int result = builder.GetHashCode();

		await That(result).IsEqualTo(TimeSpan.FromMinutes(1).GetHashCode());
	}

	[Test]
	[Arguments(59, 60, -1)]
	[Arguments(60, 60, 0)]
	[Arguments(61, 60, 1)]
	public async Task CompareTo_ShouldCompareTimeSpans(int leftSeconds, int rightSeconds, int expected)
	{
		TimeSpanBuilder left = leftSeconds.Seconds();
		TimeSpanBuilder right = rightSeconds.Seconds();

		int result = left.CompareTo(right);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(59, 60, false)]
	[Arguments(60, 60, true)]
	[Arguments(61, 60, false)]
	public async Task EqualityOperator_ShouldCompareTimeSpans(int leftSeconds, int rightSeconds, bool expected)
	{
		bool result = leftSeconds.Seconds() == rightSeconds.Seconds();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(59, 60, true)]
	[Arguments(60, 60, false)]
	[Arguments(61, 60, true)]
	public async Task InequalityOperator_ShouldCompareTimeSpans(int leftSeconds, int rightSeconds, bool expected)
	{
		bool result = leftSeconds.Seconds() != rightSeconds.Seconds();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(59, 60, true)]
	[Arguments(60, 60, false)]
	[Arguments(61, 60, false)]
	public async Task LessThanOperator_ShouldCompareTimeSpans(int leftSeconds, int rightSeconds, bool expected)
	{
		bool result = leftSeconds.Seconds() < rightSeconds.Seconds();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(59, 60, false)]
	[Arguments(60, 60, false)]
	[Arguments(61, 60, true)]
	public async Task GreaterThanOperator_ShouldCompareTimeSpans(int leftSeconds, int rightSeconds, bool expected)
	{
		bool result = leftSeconds.Seconds() > rightSeconds.Seconds();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(59, 60, true)]
	[Arguments(60, 60, true)]
	[Arguments(61, 60, false)]
	public async Task LessThanOrEqualOperator_ShouldCompareTimeSpans(int leftSeconds, int rightSeconds,
		bool expected)
	{
		bool result = leftSeconds.Seconds() <= rightSeconds.Seconds();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(59, 60, false)]
	[Arguments(60, 60, true)]
	[Arguments(61, 60, true)]
	public async Task GreaterThanOrEqualOperator_ShouldCompareTimeSpans(int leftSeconds, int rightSeconds,
		bool expected)
	{
		bool result = leftSeconds.Seconds() >= rightSeconds.Seconds();

		await That(result).IsEqualTo(expected);
	}
}
