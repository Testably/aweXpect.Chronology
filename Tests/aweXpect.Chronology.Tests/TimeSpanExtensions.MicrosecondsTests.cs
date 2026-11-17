namespace aweXpect.Chronology.Tests;

public sealed partial class TimeSpanExtensions
{
	public sealed class MicrosecondsTests
	{
		[Test]
		[Arguments(1.25, 12)]
		[Arguments(-1.25, -12)]
		public async Task Microseconds_Double_ShouldTruncateToTicks(double microseconds, long expectedTicks)
		{
			TimeSpan result = microseconds.Microseconds();

			await That(result).IsEqualTo(TimeSpan.FromTicks(expectedTicks))
				.Because("TimeSpan.FromMicroseconds truncates fractional ticks towards zero");
		}

		[Test]
		[Arguments(1.25, 3.4)]
		public async Task Microseconds_Double_WithOffset_ShouldReturnCorrectTimeSpan(double microseconds,
			double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromTicks(12) + offset;

			TimeSpan result = microseconds.Microseconds(offset);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task Microseconds_Double_WhenNaN_ShouldThrowArgumentException()
		{
			void Act() => _ = double.NaN.Microseconds();

			await That(Act).ThrowsExactly<ArgumentException>()
				.WithMessage("TimeSpan does not accept floating point Not-a-Number values.")
				.Because("TimeSpan.FromMicroseconds throws without a parameter name, so the message has no suffix");
		}

		[Test]
		[Arguments(double.MaxValue)]
		[Arguments(double.MinValue)]
		[Arguments(double.PositiveInfinity)]
		[Arguments(double.NegativeInfinity)]
		public async Task Microseconds_Double_WhenTooLarge_ShouldThrowOverflowException(double microseconds)
		{
			void Act() => _ = microseconds.Microseconds();

			await That(Act).ThrowsExactly<OverflowException>()
				.WithMessage("TimeSpan overflowed because the duration is too long.");
		}

		[Test]
		[Arguments(1_500, 15_000)]
		[Arguments(int.MaxValue, int.MaxValue * 10L)]
		[Arguments(int.MinValue, int.MinValue * 10L)]
		public async Task Microseconds_Int_ShouldReturnCorrectTimeSpan(int microseconds, long expectedTicks)
		{
			TimeSpan result = microseconds.Microseconds();

			await That(result).IsEqualTo(TimeSpan.FromTicks(expectedTicks));
		}

		[Test]
		[Arguments(1_500, 3.4)]
		public async Task Microseconds_Int_WithOffset_ShouldReturnCorrectTimeSpan(int microseconds,
			double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromTicks(15_000) + offset;

			TimeSpan result = microseconds.Microseconds(offset);

			await That(result).IsEqualTo(expected);
		}
	}
}
