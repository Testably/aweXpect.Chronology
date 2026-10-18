namespace aweXpect.Chronology.Tests;

public sealed partial class DateTimeExtensions
{
	public sealed class BeforeTests
	{
		[Test]
		public async Task WithDateTimeBuilderAndTimeSpanBuilder_ShouldSubtractTimeSpanFromDateTime()
		{
			DateTime expected = new(2024, 12, 24, 21, 0, 0);

			DateTime result = 3.Hours().Before(25.December(2024));

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task WithDateTimeBuilderAndTimeSpan_ShouldSubtractTimeSpanFromDateTime()
		{
			DateTime expected = new(2024, 12, 24, 21, 0, 0);
			TimeSpan timeDifference = 3.Hours();

			DateTime result = timeDifference.Before(25.December(2024));

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task WithDateTimeAndTimeSpanBuilder_ShouldSubtractTimeSpanFromDateTime()
		{
			DateTime expected = new(2024, 12, 24, 21, 0, 0);
			DateTime dateTime = 25.December(2024);

			DateTime result = 3.Hours().Before(dateTime);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task WithDateTimeAndTimeSpan_ShouldSubtractTimeSpanFromDateTime()
		{
			DateTime expected = new(2024, 12, 24, 21, 0, 0);
			TimeSpan timeDifference = 3.Hours();
			DateTime dateTime = 25.December(2024);

			DateTime result = timeDifference.Before(dateTime);

			await That(result).IsEqualTo(expected);
		}
	}
}
