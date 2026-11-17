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
}
