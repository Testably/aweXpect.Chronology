using System;

namespace aweXpect.Chronology;

/// <summary>
///     Extension methods for creating <see cref="TimeSpanBuilder" />.
/// </summary>
/// <example>
///     Instead of <c>new TimeSpan(0, 5, 30)</c><br />
///     you can write <c>5.Minutes(30.Seconds())</c>.
/// </example>
public static class TimeSpanBuilderExtensions
{
	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="ticks" />.
	/// </summary>
	public static TimeSpanBuilder Ticks(this int ticks)
		=> new(TimeSpan.FromTicks(ticks));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="ticks" />.
	/// </summary>
	public static TimeSpanBuilder Ticks(this long ticks)
		=> new(TimeSpan.FromTicks(ticks));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="ticks" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Ticks(this int ticks, TimeSpan offset)
		=> new(TimeSpan.FromTicks(ticks).Add(offset));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="ticks" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Ticks(this long ticks, TimeSpan offset)
		=> new(TimeSpan.FromTicks(ticks).Add(offset));


	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="microseconds" />.
	/// </summary>
	public static TimeSpanBuilder Microseconds(this int microseconds)
		=> new(FromMicroseconds(microseconds));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="microseconds" />.
	/// </summary>
	public static TimeSpanBuilder Microseconds(this double microseconds)
		=> new(FromMicroseconds(microseconds));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="microseconds" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Microseconds(this int microseconds, TimeSpan offset)
		=> new(FromMicroseconds(microseconds).Add(offset));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="microseconds" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Microseconds(this double microseconds, TimeSpan offset)
		=> new(FromMicroseconds(microseconds).Add(offset));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="milliseconds" />.
	/// </summary>
	public static TimeSpanBuilder Milliseconds(this int milliseconds)
		=> new(TimeSpan.FromMilliseconds(milliseconds));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="milliseconds" />.
	/// </summary>
	public static TimeSpanBuilder Milliseconds(this double milliseconds)
		=> new(TimeSpan.FromMilliseconds(milliseconds));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="milliseconds" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Milliseconds(this int milliseconds, TimeSpan offset)
		=> new(TimeSpan.FromMilliseconds(milliseconds).Add(offset));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="milliseconds" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Milliseconds(this double milliseconds, TimeSpan offset)
		=> new(TimeSpan.FromMilliseconds(milliseconds).Add(offset));


	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="seconds" />.
	/// </summary>
	public static TimeSpanBuilder Seconds(this int seconds)
		=> new(TimeSpan.FromSeconds(seconds));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="seconds" />.
	/// </summary>
	public static TimeSpanBuilder Seconds(this double seconds)
		=> new(TimeSpan.FromSeconds(seconds));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="seconds" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Seconds(this int seconds, TimeSpan offset)
		=> new(TimeSpan.FromSeconds(seconds).Add(offset));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="seconds" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Seconds(this double seconds, TimeSpan offset)
		=> new(TimeSpan.FromSeconds(seconds).Add(offset));


	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="minutes" />.
	/// </summary>
	public static TimeSpanBuilder Minutes(this int minutes)
		=> new(TimeSpan.FromMinutes(minutes));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="minutes" />.
	/// </summary>
	public static TimeSpanBuilder Minutes(this double minutes)
		=> new(TimeSpan.FromMinutes(minutes));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="minutes" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Minutes(this int minutes, TimeSpan offset)
		=> new(TimeSpan.FromMinutes(minutes).Add(offset));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="minutes" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Minutes(this double minutes, TimeSpan offset)
		=> new(TimeSpan.FromMinutes(minutes).Add(offset));


	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="hours" />.
	/// </summary>
	public static TimeSpanBuilder Hours(this int hours)
		=> new(TimeSpan.FromHours(hours));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="hours" />.
	/// </summary>
	public static TimeSpanBuilder Hours(this double hours)
		=> new(TimeSpan.FromHours(hours));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="hours" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Hours(this int hours, TimeSpan offset)
		=> new(TimeSpan.FromHours(hours).Add(offset));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="hours" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Hours(this double hours, TimeSpan offset)
		=> new(TimeSpan.FromHours(hours).Add(offset));


	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="days" />.
	/// </summary>
	public static TimeSpanBuilder Days(this int days)
		=> new(TimeSpan.FromDays(days));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="days" />.
	/// </summary>
	public static TimeSpanBuilder Days(this double days)
		=> new(TimeSpan.FromDays(days));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="days" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Days(this int days, TimeSpan offset)
		=> new(TimeSpan.FromDays(days).Add(offset));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="days" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Days(this double days, TimeSpan offset)
		=> new(TimeSpan.FromDays(days).Add(offset));


	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="weeks" />.
	/// </summary>
	public static TimeSpanBuilder Weeks(this int weeks)
		=> new(TimeSpan.FromDays(weeks * DaysPerWeek));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="weeks" />.
	/// </summary>
	public static TimeSpanBuilder Weeks(this double weeks)
		=> new(TimeSpan.FromDays(weeks * DaysPerWeek));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="weeks" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Weeks(this int weeks, TimeSpan offset)
		=> new(TimeSpan.FromDays(weeks * DaysPerWeek).Add(offset));

	/// <summary>
	///     Creates a <see cref="TimeSpanBuilder" /> based on the number of <paramref name="weeks" />
	///     and adds the given <paramref name="offset" />.
	/// </summary>
	public static TimeSpanBuilder Weeks(this double weeks, TimeSpan offset)
		=> new(TimeSpan.FromDays(weeks * DaysPerWeek).Add(offset));

	/// <summary>
	///     A <see langword="double" />, so that <c>int.MaxValue.Weeks()</c> overflows the <see cref="TimeSpan" />
	///     instead of silently wrapping around in <see langword="int" /> arithmetic.
	/// </summary>
	private const double DaysPerWeek = 7.0;

#if NET8_0_OR_GREATER
	private static TimeSpan FromMicroseconds(double microseconds)
		=> TimeSpan.FromMicroseconds(microseconds);
#else
	/// <summary>
	///     Mirrors <c>TimeSpan.FromMicroseconds(double)</c> of .NET 7+, which netstandard2.0 lacks.
	///     <c>TimeSpan.FromMilliseconds</c> cannot be used instead, as .NET Framework rounds it to whole milliseconds.
	/// </summary>
	private static TimeSpan FromMicroseconds(double microseconds)
	{
		if (double.IsNaN(microseconds))
		{
			throw new ArgumentException("TimeSpan does not accept floating point Not-a-Number values.");
		}

		double ticks = microseconds * TicksPerMicrosecond;
		if (ticks > long.MaxValue || ticks < long.MinValue)
		{
			throw new OverflowException("TimeSpan overflowed because the duration is too long.");
		}

		return ticks >= long.MaxValue ? TimeSpan.MaxValue : TimeSpan.FromTicks((long)ticks);
	}

	private const long TicksPerMicrosecond = 10;
#endif
}
