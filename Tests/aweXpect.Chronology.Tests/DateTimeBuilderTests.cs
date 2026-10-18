namespace aweXpect.Chronology.Tests;

public sealed class DateTimeBuilderTests
{
	[Test]
	public async Task MinusOperator_ShouldSubtractTimeSpan()
	{
		DateTimeBuilder expected = 23.March(2024).At(10, 00);
		DateTimeBuilder builder = new(23.March(2024).At(12, 00));

		DateTime result = builder - 2.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task PlusOperator_ShouldAddTimeSpan()
	{
		DateTimeBuilder expected = 23.March(2024).At(14, 00);
		DateTimeBuilder builder = new(23.March(2024).At(12, 00));

		DateTime result = builder + 2.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateTime()
	{
		DateTime expected = new(2024, 03, 23, 12, 13, 14);
		DateTimeBuilder builder = new(23.March(2024).At(12, 13, 14));

		DateTime result = builder;

		await That(result).IsEqualTo(expected);
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateOnly()
	{
		DateOnly expected = new(2024, 03, 23);
		DateTimeBuilder builder = new(23.March(2024).At(12, 13, 14));

		DateOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToTimeOnly()
	{
		TimeOnly expected = new(12, 13, 14);
		DateTimeBuilder builder = new(23.March(2024).At(12, 13, 14));

		TimeOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif
}
