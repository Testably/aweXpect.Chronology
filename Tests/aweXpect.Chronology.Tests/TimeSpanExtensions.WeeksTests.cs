namespace aweXpect.Chronology.Tests;

public sealed partial class TimeSpanExtensions
{
	public sealed class WeeksTests
	{
		[Test]
		[Arguments(1.5)]
		public async Task Weeks_Double_ShouldReturnCorrectTimeSpan(double weeks)
		{
			TimeSpan expected = TimeSpan.FromDays(10.5);

			TimeSpan result = weeks.Weeks();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(1.5, 3.4)]
		public async Task Weeks_Double_WithOffset_ShouldReturnCorrectTimeSpan(double weeks, double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromDays(10.5) + offset;

			TimeSpan result = weeks.Weeks(offset);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(2)]
		public async Task Weeks_Int_ShouldReturnCorrectTimeSpan(int weeks)
		{
			TimeSpan expected = TimeSpan.FromDays(14);

			TimeSpan result = weeks.Weeks();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(2, 3.4)]
		public async Task Weeks_Int_WithOffset_ShouldReturnCorrectTimeSpan(int weeks, double offsetSeconds)
		{
			TimeSpan offset = TimeSpan.FromSeconds(offsetSeconds);
			TimeSpan expected = TimeSpan.FromDays(14) + offset;

			TimeSpan result = weeks.Weeks(offset);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(613_566_757)]
		public async Task Weeks_Int_WhenTooLarge_ShouldThrowOverflowException(int weeks)
		{
			void Act() => _ = weeks.Weeks();

			await That(Act).ThrowsExactly<OverflowException>()
				.Because("7 * 613,566,757 wraps around to 3 in int arithmetic, which would silently give 3 days");
		}
	}
}
