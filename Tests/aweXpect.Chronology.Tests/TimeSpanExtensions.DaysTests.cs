namespace aweXpect.Chronology.Tests;

public sealed partial class TimeSpanExtensions
{
	public sealed class DaysTests
	{
		[Test]
		[Arguments(1.2)]
		public async Task Days_Double_ShouldReturnCorrectTimeSpan(double days)
		{
			TimeSpan expected = TimeSpan.FromDays(days);

			TimeSpan result = days.Days();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1.2, 3.4)]
		public async Task Days_Double_WithOffset_ShouldReturnCorrectTimeSpan(double days,
			double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromDays(days) + offset;

			TimeSpan result = days.Days(offset);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1)]
		public async Task Days_Int_ShouldReturnCorrectTimeSpan(int days)
		{
			TimeSpan expected = days.Days();

			TimeSpan result = days.Days();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1, 3.4)]
		public async Task Days_Int_WithOffset_ShouldReturnCorrectTimeSpan(int days, double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = days.Days() + offset;

			TimeSpan result = days.Days(offset);

			await That(result).IsEqualTo(expected);
		}
	}
}
