namespace aweXpect.Chronology.Tests;

public sealed partial class TimeSpanExtensions
{
	public sealed class TicksTests
	{
		[Test]
		[Arguments(15)]
		public async Task Ticks_Int_ShouldReturnCorrectTimeSpan(int ticks)
		{
			TimeSpan expected = TimeSpan.FromTicks(ticks);

			TimeSpan result = ticks.Ticks();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(15, 3.4)]
		public async Task Ticks_Int_WithOffset_ShouldReturnCorrectTimeSpan(int ticks, double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromTicks(ticks) + offset;

			TimeSpan result = ticks.Ticks(offset);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(long.MaxValue)]
		public async Task Ticks_Long_ShouldReturnCorrectTimeSpan(long ticks)
		{
			TimeSpan expected = TimeSpan.FromTicks(ticks);

			TimeSpan result = ticks.Ticks();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(5_000_000_000L, 3.4)]
		public async Task Ticks_Long_WithOffset_ShouldReturnCorrectTimeSpan(long ticks, double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromTicks(ticks) + offset;

			TimeSpan result = ticks.Ticks(offset);

			await That(result).IsEqualTo(expected);
		}
	}
}
