namespace aweXpect.Chronology.Tests;

public sealed partial class DateTimeExtensions
{
	public sealed class AfterTests
	{
		[Test]
		public async Task WithDateTimeBuilderAndTimeSpanBuilder_ShouldAddTimeSpanToDateTime()
		{
			DateTime expected = new(2024, 12, 24, 21, 0, 0);

			DateTime result = 21.Hours().After(24.December(2024));

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task WithDateTimeBuilderAndTimeSpan_ShouldAddTimeSpanToDateTime()
		{
			DateTime expected = new(2024, 12, 24, 21, 0, 0);
			TimeSpan timeDifference = 21.Hours();

			DateTime result = timeDifference.After(24.December(2024));

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task WithDateTimeAndTimeSpanBuilder_ShouldAddTimeSpanToDateTime()
		{
			DateTime expected = new(2024, 12, 24, 21, 0, 0);
			DateTime dateTime = 24.December(2024);

			DateTime result = 21.Hours().After(dateTime);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task WithDateTimeAndTimeSpan_ShouldAddTimeSpanToDateTime()
		{
			DateTime expected = new(2024, 12, 24, 21, 0, 0);
			TimeSpan timeDifference = 21.Hours();
			DateTime dateTime = 24.December(2024);

			DateTime result = timeDifference.After(dateTime);

			await That(result).IsEqualTo(expected);
		}
	}
}
