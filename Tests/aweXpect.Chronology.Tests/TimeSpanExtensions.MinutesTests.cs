namespace aweXpect.Chronology.Tests;

public sealed partial class TimeSpanExtensions
{
	public sealed class MinutesTests
	{
		[Test]
		[Arguments(1.2)]
		public async Task Minutes_Double_ShouldReturnCorrectTimeSpan(double minutes)
		{
			TimeSpan expected = TimeSpan.FromMinutes(minutes);

			TimeSpan result = minutes.Minutes();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1.2, 3.4)]
		public async Task Minutes_Double_WithOffset_ShouldReturnCorrectTimeSpan(double minutes,
			double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromMinutes(minutes) + offset;

			TimeSpan result = minutes.Minutes(offset);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1)]
		public async Task Minutes_Int_ShouldReturnCorrectTimeSpan(int minutes)
		{
			TimeSpan expected = TimeSpan.FromMinutes(minutes);

			TimeSpan result = minutes.Minutes();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1, 3.4)]
		public async Task Minutes_Int_WithOffset_ShouldReturnCorrectTimeSpan(int minutes,
			double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromMinutes(minutes) + offset;

			TimeSpan result = minutes.Minutes(offset);

			await That(result).IsEqualTo(expected);
		}
	}
}
