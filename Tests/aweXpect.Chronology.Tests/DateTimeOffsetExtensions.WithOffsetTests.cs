namespace aweXpect.Chronology.Tests;

public sealed class DateTimeOffsetExtensions
{
	public sealed class WithOffsetTests
	{
		[Test]
		public async Task WithDateTime_ShouldApplyOffset()
		{
			DateTimeOffset expected = new(2024, 12, 24, 21, 0, 0, TimeSpan.FromHours(7.5));
			DateTime dateTime = 24.December(2024).At(21, 0);

			DateTimeOffset result = dateTime.WithOffset(7.5.Hours());

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task WithDateTimeBuilder_ShouldApplyOffset()
		{
			DateTimeOffset expected = new(2024, 12, 24, 21, 0, 0, TimeSpan.FromHours(7.5));
			DateTimeBuilder dateTime = 24.December(2024).At(21, 0);

			DateTimeOffset result = dateTime.WithOffset(7.5.Hours());

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task WithDateBuilder_ShouldApplyOffset()
		{
			DateTimeOffset expected = new(2024, 12, 24, 0, 0, 0, TimeSpan.FromHours(7.5));
			DateBuilder dateTime = 24.December(2024);

			DateTimeOffset result = dateTime.WithOffset(7.5.Hours());

			await That(result).IsEqualTo(expected);
		}
	}
}
