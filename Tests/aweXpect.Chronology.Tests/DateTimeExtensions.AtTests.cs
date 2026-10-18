namespace aweXpect.Chronology.Tests;

public sealed partial class DateTimeExtensions
{
	public sealed class AtTests
	{
		[Test]
		public async Task FromBuilder_WithTimeSpan_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 15);

			DateTime result = 24.December(2024).At(18.Hours(30.Minutes(15.Seconds())));

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromBuilder_WithHourAndMinutes_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 00);

			DateTime result = 24.December(2024).At(18, 30);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromBuilder_WithHourMinutesAndSeconds_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 59);

			DateTime result = 24.December(2024).At(18, 30, 59);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromBuilder_WithHourMinutesSecondsAndMilliseconds_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 0, 150, DateTimeKind.Unspecified);

			DateTime result = 24.December(2024).At(18, 30, 0, 150);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromDateTime_WithTimeSpan_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 15);
			DateTime date = 24.December(2024);

			DateTime result = date.At(18.Hours(30.Minutes(15.Seconds())));

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromDateTime_WithHourAndMinutes_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 00);
			DateTime date = 24.December(2024);

			DateTime result = date.At(18, 30);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromDateTime_WithHourMinutesAndSeconds_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 59);
			DateTime date = 24.December(2024);

			DateTime result = date.At(18, 30, 59);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromDateTime_WithHourMinutesSecondsAndMilliseconds_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 0, 150, DateTimeKind.Unspecified);
			DateTime date = 24.December(2024);

			DateTime result = date.At(18, 30, 0, 150);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task FromDateOnly_WithTimeSpan_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 15);
			DateOnly date = 24.December(2024);

			DateTime result = date.At(18.Hours(30.Minutes(15.Seconds())));

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromDateOnly_WithHourAndMinutes_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 00);
			DateOnly date = 24.December(2024);

			DateTime result = date.At(18, 30);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromDateOnly_WithHourMinutesAndSeconds_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 59);
			DateOnly date = 24.December(2024);

			DateTime result = date.At(18, 30, 59);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromDateOnly_WithHourMinutesSecondsAndMilliseconds_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 0, 150, DateTimeKind.Unspecified);
			DateOnly date = 24.December(2024);

			DateTime result = date.At(18, 30, 0, 150);

			await That(result).IsEqualTo(expected);
		}
#endif
	}
}
