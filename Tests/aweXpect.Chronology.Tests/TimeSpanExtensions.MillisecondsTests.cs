namespace aweXpect.Chronology.Tests;

public sealed partial class TimeSpanExtensions
{
	public sealed class MillisecondsTests
	{
		[Test]
		[Arguments(1.2)]
		public async Task Milliseconds_Double_ShouldReturnCorrectTimeSpan(double milliseconds)
		{
			TimeSpan expected = TimeSpan.FromMilliseconds(milliseconds);

			TimeSpan result = milliseconds.Milliseconds();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1.2, 3.4)]
		public async Task Milliseconds_Double_WithOffset_ShouldReturnCorrectTimeSpan(
			double milliseconds, double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromMilliseconds(milliseconds) + offset;

			TimeSpan result = milliseconds.Milliseconds(offset);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1)]
		public async Task Milliseconds_Int_ShouldReturnCorrectTimeSpan(int milliseconds)
		{
			TimeSpan expected = TimeSpan.FromMilliseconds(milliseconds);

			TimeSpan result = milliseconds.Milliseconds();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1, 3.4)]
		public async Task Milliseconds_Int_WithOffset_ShouldReturnCorrectTimeSpan(int milliseconds,
			double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromMilliseconds(milliseconds) + offset;

			TimeSpan result = milliseconds.Milliseconds(offset);

			await That(result).IsEqualTo(expected);
		}
	}
}
