namespace aweXpect.Chronology.Tests;

public sealed partial class TimeSpanExtensions
{
	public sealed class SecondsTests
	{
		[Test]
		[Arguments(1.2)]
		public async Task Seconds_Double_ShouldReturnCorrectTimeSpan(double seconds)
		{
			TimeSpan expected = TimeSpan.FromSeconds(seconds);

			TimeSpan result = seconds.Seconds();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1.2, 3.4)]
		public async Task Seconds_Double_WithOffset_ShouldReturnCorrectTimeSpan(double seconds,
			double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromSeconds(seconds) + offset;

			TimeSpan result = seconds.Seconds(offset);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1)]
		public async Task Seconds_Int_ShouldReturnCorrectTimeSpan(int seconds)
		{
			TimeSpan expected = TimeSpan.FromSeconds(seconds);

			TimeSpan result = seconds.Seconds();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1, 3.4)]
		public async Task Seconds_Int_WithOffset_ShouldReturnCorrectTimeSpan(int seconds,
			double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromSeconds(seconds) + offset;

			TimeSpan result = seconds.Seconds(offset);

			await That(result).IsEqualTo(expected);
		}
	}
}
