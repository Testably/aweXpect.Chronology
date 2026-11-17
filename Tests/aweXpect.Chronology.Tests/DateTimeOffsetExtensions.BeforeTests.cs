namespace aweXpect.Chronology.Tests;

public sealed partial class DateTimeOffsetExtensions
{
	public sealed class BeforeTests
	{
		[Test]
		public async Task WithDateTimeOffsetBuilderAndTimeSpanBuilder_ShouldKeepOffset()
		{
			DateTimeOffset expected = new(2024, 12, 24, 9, 0, 0, TimeSpan.FromHours(7.5));

			DateTimeOffset result = 3.Hours().Before(24.December(2024).At(12, 0).WithOffset(7.5.Hours()));

			await That(result).IsEqualTo(expected);
			await That(result.Offset).IsEqualTo(expected.Offset)
				.Because("DateTimeOffset equality ignores the offset");
		}

		[Test]
		public async Task WithDateTimeOffsetBuilderAndTimeSpan_ShouldKeepOffset()
		{
			DateTimeOffset expected = new(2024, 12, 24, 9, 0, 0, TimeSpan.FromHours(7.5));
			TimeSpan timeDifference = 3.Hours();

			DateTimeOffset result = timeDifference.Before(24.December(2024).At(12, 0).WithOffset(7.5.Hours()));

			await That(result).IsEqualTo(expected);
			await That(result.Offset).IsEqualTo(expected.Offset)
				.Because("DateTimeOffset equality ignores the offset");
		}

		[Test]
		public async Task WithDateTimeOffsetAndTimeSpanBuilder_ShouldKeepOffset()
		{
			DateTimeOffset expected = new(2024, 12, 24, 9, 0, 0, TimeSpan.FromHours(7.5));
			DateTimeOffset dateTime = new(2024, 12, 24, 12, 0, 0, TimeSpan.FromHours(7.5));

			DateTimeOffset result = 3.Hours().Before(dateTime);

			await That(result).IsEqualTo(expected);
			await That(result.Offset).IsEqualTo(expected.Offset)
				.Because("DateTimeOffset equality ignores the offset");
		}

		[Test]
		public async Task WithDateTimeOffsetAndTimeSpan_ShouldKeepOffset()
		{
			DateTimeOffset expected = new(2024, 12, 24, 9, 0, 0, TimeSpan.FromHours(7.5));
			DateTimeOffset dateTime = new(2024, 12, 24, 12, 0, 0, TimeSpan.FromHours(7.5));
			TimeSpan timeDifference = 3.Hours();

			DateTimeOffset result = timeDifference.Before(dateTime);

			await That(result).IsEqualTo(expected);
			await That(result.Offset).IsEqualTo(expected.Offset)
				.Because("DateTimeOffset equality ignores the offset");
		}
	}
}
