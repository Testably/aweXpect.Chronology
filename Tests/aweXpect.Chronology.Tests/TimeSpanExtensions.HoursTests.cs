namespace aweXpect.Chronology.Tests;

public sealed partial class TimeSpanExtensions
{
	public sealed class HoursTests
	{
		[Test]
		[Arguments(1.2)]
		public async Task Hours_Double_ShouldReturnCorrectTimeSpan(double hours)
		{
			TimeSpan expected = TimeSpan.FromHours(hours);

			TimeSpan result = hours.Hours();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1.2, 3.4)]
		public async Task Hours_Double_WithOffset_ShouldReturnCorrectTimeSpan(double hours,
			double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromHours(hours) + offset;

			TimeSpan result = hours.Hours(offset);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1)]
		public async Task Hours_Int_ShouldReturnCorrectTimeSpan(int hours)
		{
			TimeSpan expected = TimeSpan.FromHours(hours);

			TimeSpan result = hours.Hours();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1, 3.4)]
		public async Task Hours_Int_WithOffset_ShouldReturnCorrectTimeSpan(int hours, double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromHours(hours) + offset;

			TimeSpan result = hours.Hours(offset);

			await That(result).IsEqualTo(expected);
		}
	}
}
