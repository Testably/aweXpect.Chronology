using System;
using System.ComponentModel;
using aweXpect.Chronology.ComponentModel;

namespace aweXpect.Chronology;

#if NET8_0_OR_GREATER
/// <summary>
///     A builder that allows implicit cast to <see cref="DateTimeOffset" />, <see cref="DateTime" />,
///     <see cref="DateOnly" /> and <see cref="TimeOnly" />.
/// </summary>
#else
/// <summary>
///     A builder that allows implicit cast to <see cref="DateTimeOffset" /> and <see cref="DateTime" />.
/// </summary>
#endif
[TypeConverter(typeof(DateTimeOffsetBuilderConverter))]
public readonly struct DateTimeOffsetBuilder(DateTimeOffset value)
	: IEquatable<DateTimeOffsetBuilder>, IComparable<DateTimeOffsetBuilder>
{
	private readonly DateTimeOffset _value = value;

	/// <summary>
	///     Implicitly casts the <see cref="DateTimeOffsetBuilder" /> to a <see cref="DateTime" />.
	/// </summary>
	public static implicit operator DateTime(DateTimeOffsetBuilder builder)
		=> builder._value.DateTime;

	/// <summary>
	///     Implicitly casts the <see cref="DateTimeOffsetBuilder" /> to a <see cref="DateTimeOffset" />.
	/// </summary>
	public static implicit operator DateTimeOffset(DateTimeOffsetBuilder builder)
		=> builder._value;

	/// <inheritdoc cref="DateTimeOffset.ToString()" />
	public override string ToString()
		=> _value.ToString();

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="other" /> builder represents the same point in time.
	/// </summary>
	/// <remarks>
	///     Like <see cref="DateTimeOffset.Equals(DateTimeOffset)" />, the offset is ignored, so
	///     <c>12:00 +02:00</c> equals <c>10:00 +00:00</c>.
	/// </remarks>
	public bool Equals(DateTimeOffsetBuilder other)
		=> _value.Equals(other._value);

	/// <summary>
	///     Returns <see langword="true" /> if <paramref name="obj" /> is a <see cref="DateTimeOffsetBuilder" /> that
	///     represents the same point in time.
	/// </summary>
	public override bool Equals(object? obj)
		=> obj is DateTimeOffsetBuilder other && Equals(other);

	/// <summary>
	///     Returns the hash code of the <see cref="DateTimeOffset" />.
	/// </summary>
	public override int GetHashCode()
		=> _value.GetHashCode();

	/// <summary>
	///     Compares the point in time with the one of the <paramref name="other" /> builder.
	/// </summary>
	public int CompareTo(DateTimeOffsetBuilder other)
		=> _value.CompareTo(other._value);

	/// <summary>
	///     Returns <see langword="true" /> if both builders represent the same point in time.
	/// </summary>
	public static bool operator ==(DateTimeOffsetBuilder left, DateTimeOffsetBuilder right)
		=> left._value == right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the builders represent different points in time.
	/// </summary>
	public static bool operator !=(DateTimeOffsetBuilder left, DateTimeOffsetBuilder right)
		=> left._value != right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> point in time is earlier than the
	///     <paramref name="right" /> one.
	/// </summary>
	public static bool operator <(DateTimeOffsetBuilder left, DateTimeOffsetBuilder right)
		=> left._value < right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> point in time is later than the
	///     <paramref name="right" /> one.
	/// </summary>
	public static bool operator >(DateTimeOffsetBuilder left, DateTimeOffsetBuilder right)
		=> left._value > right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> point in time is earlier than or equal to the
	///     <paramref name="right" /> one.
	/// </summary>
	public static bool operator <=(DateTimeOffsetBuilder left, DateTimeOffsetBuilder right)
		=> left._value <= right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> point in time is later than or equal to the
	///     <paramref name="right" /> one.
	/// </summary>
	public static bool operator >=(DateTimeOffsetBuilder left, DateTimeOffsetBuilder right)
		=> left._value >= right._value;

#if NET8_0_OR_GREATER
	/// <summary>
	///     Implicitly casts the <see cref="DateTimeOffsetBuilder" /> to a <see cref="DateOnly" />.
	/// </summary>
	public static implicit operator DateOnly(DateTimeOffsetBuilder builder)
		=> DateOnly.FromDateTime(builder._value.DateTime);
#endif

#if NET8_0_OR_GREATER
	/// <summary>
	///     Implicitly casts the <see cref="DateTimeOffsetBuilder" /> to a <see cref="TimeOnly" />.
	/// </summary>
	public static implicit operator TimeOnly(DateTimeOffsetBuilder builder)
		=> TimeOnly.FromDateTime(builder._value.DateTime);
#endif

	/// <summary>
	///     Adds a <see cref="TimeSpan" /> to the <see cref="DateTimeOffset" />.
	/// </summary>
	public static DateTimeOffsetBuilder operator +(DateTimeOffsetBuilder builder, TimeSpan time)
		=> new(builder._value + time);

	/// <summary>
	///     Subtracts a <see cref="TimeSpan" /> from the <see cref="DateTimeOffset" />.
	/// </summary>
	public static DateTimeOffsetBuilder operator -(DateTimeOffsetBuilder builder, TimeSpan time)
		=> new(builder._value - time);
}
