using System;

namespace aweXpect.Chronology;

/// <summary>
///     Extension methods for creating <see cref="DateTime" />.
/// </summary>
/// <example>
///     Instead of <c>new DateTime(2024, 12, 24)</c><br />
///     you can write <c>24.December(2024)</c>.
/// </example>
public static class DateTimeExtensions
{
	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in January of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder January(this int day, int year)
		=> new(new DateTime(year, 1, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in February of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder February(this int day, int year)
		=> new(new DateTime(year, 2, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in March of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder March(this int day, int year)
		=> new(new DateTime(year, 3, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in April of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder April(this int day, int year)
		=> new(new DateTime(year, 4, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in May of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder May(this int day, int year)
		=> new(new DateTime(year, 5, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in June of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder June(this int day, int year)
		=> new(new DateTime(year, 6, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in July of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder July(this int day, int year)
		=> new(new DateTime(year, 7, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in August of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder August(this int day, int year)
		=> new(new DateTime(year, 8, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in September of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder September(this int day, int year)
		=> new(new DateTime(year, 9, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in October of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder October(this int day, int year)
		=> new(new DateTime(year, 10, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in November of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder November(this int day, int year)
		=> new(new DateTime(year, 11, day, 0, 0, 0, DateTimeKind.Unspecified));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="day" />
	///     in December of the given <paramref name="year" />.
	/// </summary>
	public static DateBuilder December(this int day, int year)
		=> new(new DateTime(year, 12, day, 0, 0, 0, DateTimeKind.Unspecified));


	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="date" /> and <paramref name="time" />.
	/// </summary>
	public static DateTimeBuilder At(this DateBuilder date, TimeSpan time)
		=> new(((DateTime)date).Date + ThrowIfNotTimeOfDay(time));

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="date" /> and time
	///     with the specified <paramref name="hours" />, <paramref name="minutes" />
	///     and optionally <paramref name="seconds" /> and <paramref name="milliseconds" />.
	/// </summary>
	public static DateTimeBuilder At(this DateBuilder date, int hours, int minutes, int seconds = 0,
		int milliseconds = 0)
		=> new(((DateTime)date).Date + new DateTime(1, 1, 1, hours, minutes, seconds, milliseconds).TimeOfDay);

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="date" /> and <paramref name="time" />.
	/// </summary>
	public static DateTime At(this DateTime date, TimeSpan time)
		=> date.Date + ThrowIfNotTimeOfDay(time);

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="date" /> and time
	///     with the specified <paramref name="hours" />, <paramref name="minutes" />
	///     and optionally <paramref name="seconds" /> and <paramref name="milliseconds" />.
	/// </summary>
	public static DateTime At(this DateTime date, int hours, int minutes, int seconds = 0, int milliseconds = 0)
		=> new(date.Year, date.Month, date.Day, hours, minutes, seconds, milliseconds, date.Kind);

#if NET8_0_OR_GREATER
	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="date" /> and <paramref name="time" />.
	/// </summary>
	public static DateTime At(this DateOnly date, TimeSpan time)
		=> date.ToDateTime(TimeOnly.MinValue) + ThrowIfNotTimeOfDay(time);
#endif

#if NET8_0_OR_GREATER
	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="date" /> and time
	///     with the specified <paramref name="hours" />, <paramref name="minutes" />
	///     and optionally <paramref name="seconds" /> and <paramref name="milliseconds" />.
	/// </summary>
	public static DateTime At(this DateOnly date, int hours, int minutes, int seconds = 0, int milliseconds = 0)
		=> new(date.Year, date.Month, date.Day, hours, minutes, seconds, milliseconds, DateTimeKind.Unspecified);
#endif


	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="dateTime" />
	///     with kind set to <see cref="DateTimeKind.Utc" />.
	/// </summary>
	public static DateTimeBuilder AsUtc(this DateTimeBuilder dateTime)
		=> dateTime.SpecifyKind(DateTimeKind.Utc);

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="dateTime" />
	///     with kind set to <see cref="DateTimeKind.Utc" />.
	/// </summary>
	public static DateTime AsUtc(this DateTime dateTime)
		=> DateTime.SpecifyKind(dateTime, DateTimeKind.Utc);

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="dateTime" />
	///     with kind set to <see cref="DateTimeKind.Local" />.
	/// </summary>
	public static DateTimeBuilder AsLocal(this DateTimeBuilder dateTime)
		=> dateTime.SpecifyKind(DateTimeKind.Local);

	/// <summary>
	///     Creates a <see cref="DateTime" /> for the given <paramref name="dateTime" />
	///     with kind set to <see cref="DateTimeKind.Local" />.
	/// </summary>
	public static DateTime AsLocal(this DateTime dateTime)
		=> DateTime.SpecifyKind(dateTime, DateTimeKind.Local);

	/// <summary>
	///     Converts the given <paramref name="dateTime" /> to the local time zone, like
	///     <see cref="DateTime.ToLocalTime()" />.
	/// </summary>
	/// <remarks>
	///     Unlike <see cref="AsLocal(DateTimeBuilder)" />, which keeps the clock time and only sets the kind, this
	///     changes the clock time, so the result depends on the time zone of the machine. A value with the kind
	///     <see cref="DateTimeKind.Unspecified" /> is treated as UTC, so set the kind with
	///     <see cref="AsUtc(DateTimeBuilder)" /> first.
	/// </remarks>
	public static DateTimeBuilder ToLocalTime(this DateTimeBuilder dateTime)
		=> new(((DateTime)dateTime).ToLocalTime());

	/// <summary>
	///     Converts the given <paramref name="dateTime" /> to UTC, like <see cref="DateTime.ToUniversalTime()" />.
	/// </summary>
	/// <remarks>
	///     Unlike <see cref="AsUtc(DateTimeBuilder)" />, which keeps the clock time and only sets the kind, this
	///     changes the clock time, so the result depends on the time zone of the machine. A value with the kind
	///     <see cref="DateTimeKind.Unspecified" /> is treated as local time, so set the kind with
	///     <see cref="AsLocal(DateTimeBuilder)" /> first.
	/// </remarks>
	public static DateTimeBuilder ToUniversalTime(this DateTimeBuilder dateTime)
		=> new(((DateTime)dateTime).ToUniversalTime());


	/// <summary>
	///     Creates a <see cref="DateTime" /> that is the <paramref name="timeDifference" /> before the
	///     given <paramref name="dateTime" />.
	/// </summary>
	public static DateBuilder Before(this TimeSpanBuilder timeDifference, DateBuilder dateTime)
		=> dateTime - timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTime" /> that is the <paramref name="timeDifference" /> before the
	///     given <paramref name="dateTime" />.
	/// </summary>
	public static DateTime Before(this TimeSpanBuilder timeDifference, DateTime dateTime)
		=> dateTime - timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTime" /> that is the <paramref name="timeDifference" /> before the
	///     given <paramref name="dateTime" />.
	/// </summary>
	public static DateBuilder Before(this TimeSpan timeDifference, DateBuilder dateTime)
		=> dateTime - timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTime" /> that is the <paramref name="timeDifference" /> before the
	///     given <paramref name="dateTime" />.
	/// </summary>
	public static DateTime Before(this TimeSpan timeDifference, DateTime dateTime)
		=> dateTime - timeDifference;


	/// <summary>
	///     Creates a <see cref="DateTime" /> that is the <paramref name="timeDifference" /> after the
	///     specified <paramref name="dateTime" />.
	/// </summary>
	public static DateBuilder After(this TimeSpanBuilder timeDifference, DateBuilder dateTime)
		=> dateTime + timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTime" /> that is the <paramref name="timeDifference" /> after the
	///     specified <paramref name="dateTime" />.
	/// </summary>
	public static DateTime After(this TimeSpanBuilder timeDifference, DateTime dateTime)
		=> dateTime + timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTime" /> that is the <paramref name="timeDifference" /> after the
	///     specified <paramref name="dateTime" />.
	/// </summary>
	public static DateBuilder After(this TimeSpan timeDifference, DateBuilder dateTime)
		=> dateTime + timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTime" /> that is the <paramref name="timeDifference" /> after the
	///     specified <paramref name="dateTime" />.
	/// </summary>
	public static DateTime After(this TimeSpan timeDifference, DateTime dateTime)
		=> dateTime + timeDifference;

	private static TimeSpan ThrowIfNotTimeOfDay(TimeSpan time)
		=> time < TimeSpan.Zero || time.Ticks >= TimeSpan.TicksPerDay
			? throw new ArgumentOutOfRangeException(nameof(time), time,
				"The time of day must not be negative and must be less than one day.")
			: time;
}
