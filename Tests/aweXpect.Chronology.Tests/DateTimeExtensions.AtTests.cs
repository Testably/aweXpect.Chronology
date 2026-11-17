namespace aweXpect.Chronology.Tests;

public sealed partial class DateTimeExtensions
{
	public sealed class AtTests
	{
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
		public async Task FromBuilder_WithLastMillisecondOfDay_ShouldSetTime()
		{
			DateTime expected = new(2024, 12, 24, 23, 59, 59, 999, DateTimeKind.Unspecified);

			DateTime result = 24.December(2024).At(23, 59, 59, 999);

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task FromBuilder_WithTimeOfDay_ShouldReplaceTime()
		{
			DateTime expected = new(2024, 12, 24, 6, 0, 0);
			DateBuilder date = 24.December(2024) + 18.Hours();

			DateTime result = date.At(6, 0);

			await That(result).IsEqualTo(expected)
				.Because("At sets the time of day like the DateTime overload instead of adding to the time");
		}

		[Test]
		public async Task FromBuilder_WithHourAndMinutes_ShouldKeepKind()
		{
			DateBuilder date = new(new DateTime(2024, 12, 24, 0, 0, 0, DateTimeKind.Utc));

			DateTime result = date.At(18, 30);

			await That(result.Kind).IsEqualTo(DateTimeKind.Utc);
		}

		[Test]
		[Arguments(24, 0, 0)]
		[Arguments(-1, 0, 0)]
		[Arguments(18, 60, 0)]
		[Arguments(18, -1, 0)]
		[Arguments(18, 30, 60)]
		[Arguments(18, 30, -1)]
		public async Task FromBuilder_WhenHourMinuteOrSecondIsOutOfRange_ShouldThrowArgumentOutOfRangeException(
			int hours, int minutes, int seconds)
		{
			void Act() => _ = 24.December(2024).At(hours, minutes, seconds);

			await That(Act).ThrowsExactly<ArgumentOutOfRangeException>()
				.Because("the components must not roll over into the next minute, hour or day");
		}

		[Test]
		[Arguments(1000)]
		[Arguments(-1)]
		public async Task FromBuilder_WhenMillisecondIsOutOfRange_ShouldThrowArgumentOutOfRangeException(
			int milliseconds)
		{
			void Act() => _ = 24.December(2024).At(18, 30, 0, milliseconds);

			await That(Act).ThrowsExactly<ArgumentOutOfRangeException>()
				.WithParamName("millisecond")
				.Because("the millisecond must not roll over into the next second");
		}

		[Test]
		public async Task FromBuilder_WithTimeSpan_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 15);

			DateTime result = 24.December(2024).At(18.Hours(30.Minutes(15.Seconds())));

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

		[Test]
		public async Task FromDateTime_WithTimeSpan_ShouldAddTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 15);
			DateTime date = 24.December(2024);

			DateTime result = date.At(18.Hours(30.Minutes(15.Seconds())));

			await That(result).IsEqualTo(expected);
		}

		[Test]
		[Arguments(DateTimeKind.Local)]
		[Arguments(DateTimeKind.Utc)]
		public async Task FromDateTime_WithTimeSpan_ShouldKeepKind(DateTimeKind kind)
		{
			DateTime date = new(2024, 12, 24, 10, 45, 20, kind);

			DateTime result = date.At(18.Hours());

			await That(result).HasKind().EqualTo(kind);
		}

		[Test]
		public async Task FromDateTime_WithTimeSpan_ShouldReplaceExistingTime()
		{
			DateTime expected = new(2024, 12, 24, 18, 30, 15);
			DateTime date = new(2024, 12, 24, 10, 45, 20, 500);

			DateTime result = date.At(18.Hours(30.Minutes(15.Seconds())));

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
