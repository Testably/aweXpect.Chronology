namespace aweXpect.Chronology.Tests;

public sealed class DateTimeOffsetBuilderTests
{
	[Test]
	public async Task MinusOperator_ShouldSubtractTimeSpan()
	{
		DateTimeOffsetBuilder expected = 23.March(2024).At(10, 00).WithOffset(2.Hours());
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 00).WithOffset(2.Hours()));

		DateTime result = builder - 2.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task PlusOperator_ShouldAddTimeSpan()
	{
		DateTimeOffsetBuilder expected = 23.March(2024).At(14, 00).WithOffset(2.Hours());
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 00).WithOffset(2.Hours()));

		DateTime result = builder + 2.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateTime()
	{
		DateTime expected = new(2024, 03, 23, 12, 13, 14);
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 13, 14).WithOffset(2.Hours()));

		DateTime result = builder;

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateTimeOffset()
	{
		DateTimeOffset expected = new(2024, 03, 23, 12, 13, 14, TimeSpan.FromHours(2));
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 13, 14).WithOffset(2.Hours()));

		DateTimeOffset result = builder;

		await That(result).IsEqualTo(expected);
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateOnly()
	{
		DateOnly expected = new(2024, 03, 23);
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 13, 14).WithOffset(2.Hours()));

		DateOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToTimeOnly()
	{
		TimeOnly expected = new(12, 13, 14);
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 13, 14).WithOffset(2.Hours()));

		TimeOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif
}
