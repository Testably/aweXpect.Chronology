using System;

namespace aweXpect.Chronology;

/// <summary>
///     Extension methods for creating <see cref="DateTimeOffset" />.
/// </summary>
/// <example>
///     Instead of <c>new DateTime(2024, 24, 12, 14, 30, 0, TimeSpan.FromHours(2))</c><br />
///     you can write <c>24.December(2024).At(14, 30).WithOffset(2.Hours())</c>.
/// </example>
public static class DateTimeOffsetExtensions
{
	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that uses the <paramref name="dateTime" />
	///     with the given <paramref name="offset" />.
	/// </summary>
	public static DateTimeOffsetBuilder WithOffset(this DateBuilder dateTime, TimeSpan offset)
		=> dateTime.SetOffset(offset);

	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that uses the <paramref name="dateTime" />
	///     with the given <paramref name="offset" />.
	/// </summary>
	public static DateTimeOffsetBuilder WithOffset(this DateTimeBuilder dateTime, TimeSpan offset)
		=> dateTime.SetOffset(offset);

	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that uses the <paramref name="dateTime" />
	///     with the given <paramref name="offset" />.
	/// </summary>
	public static DateTimeOffsetBuilder WithOffset(this DateTime dateTime, TimeSpan offset)
		=> new(new DateTimeOffset(dateTime, offset));


	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that is the <paramref name="timeDifference" /> before the
	///     given <paramref name="dateTime" />, with the same offset.
	/// </summary>
	public static DateTimeOffsetBuilder Before(this TimeSpanBuilder timeDifference, DateTimeOffsetBuilder dateTime)
		=> dateTime - timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that is the <paramref name="timeDifference" /> before the
	///     given <paramref name="dateTime" />, with the same offset.
	/// </summary>
	public static DateTimeOffset Before(this TimeSpanBuilder timeDifference, DateTimeOffset dateTime)
		=> dateTime - timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that is the <paramref name="timeDifference" /> before the
	///     given <paramref name="dateTime" />, with the same offset.
	/// </summary>
	public static DateTimeOffsetBuilder Before(this TimeSpan timeDifference, DateTimeOffsetBuilder dateTime)
		=> dateTime - timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that is the <paramref name="timeDifference" /> before the
	///     given <paramref name="dateTime" />, with the same offset.
	/// </summary>
	public static DateTimeOffset Before(this TimeSpan timeDifference, DateTimeOffset dateTime)
		=> dateTime - timeDifference;


	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that is the <paramref name="timeDifference" /> after the
	///     specified <paramref name="dateTime" />, with the same offset.
	/// </summary>
	public static DateTimeOffsetBuilder After(this TimeSpanBuilder timeDifference, DateTimeOffsetBuilder dateTime)
		=> dateTime + timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that is the <paramref name="timeDifference" /> after the
	///     specified <paramref name="dateTime" />, with the same offset.
	/// </summary>
	public static DateTimeOffset After(this TimeSpanBuilder timeDifference, DateTimeOffset dateTime)
		=> dateTime + timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that is the <paramref name="timeDifference" /> after the
	///     specified <paramref name="dateTime" />, with the same offset.
	/// </summary>
	public static DateTimeOffsetBuilder After(this TimeSpan timeDifference, DateTimeOffsetBuilder dateTime)
		=> dateTime + timeDifference;

	/// <summary>
	///     Creates a <see cref="DateTimeOffset" /> that is the <paramref name="timeDifference" /> after the
	///     specified <paramref name="dateTime" />, with the same offset.
	/// </summary>
	public static DateTimeOffset After(this TimeSpan timeDifference, DateTimeOffset dateTime)
		=> dateTime + timeDifference;
}
