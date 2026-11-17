using System;
using System.ComponentModel;
using aweXpect.Chronology.ComponentModel;

namespace aweXpect.Chronology;

#if NET8_0_OR_GREATER
/// <summary>
///     A builder that allows implicit cast to <see cref="DateTime" />, <see cref="DateOnly" />
///     and <see cref="TimeOnly" />.
/// </summary>
#else
/// <summary>
///     A builder that allows implicit cast to <see cref="DateTime" />.
/// </summary>
#endif
[TypeConverter(typeof(DateTimeBuilderConverter))]
public readonly struct DateTimeBuilder(DateTime value)
	: IEquatable<DateTimeBuilder>, IComparable<DateTimeBuilder>
{
	private readonly DateTime _value = value;

	/// <summary>
	///     Implicitly casts the <see cref="DateTimeBuilder" /> to a <see cref="DateTime" />.
	/// </summary>
	public static implicit operator DateTime(DateTimeBuilder builder)
		=> builder._value;

	/// <inheritdoc cref="DateTime.ToString()" />
	public override string ToString()
		=> _value.ToString();

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="other" /> builder has the same <see cref="DateTime" />.
	/// </summary>
	/// <remarks>
	///     Like <see cref="DateTime.Equals(DateTime)" />, the <see cref="DateTime.Kind" /> is ignored.
	/// </remarks>
	public bool Equals(DateTimeBuilder other)
		=> _value.Equals(other._value);

	/// <summary>
	///     Returns <see langword="true" /> if <paramref name="obj" /> is a <see cref="DateTimeBuilder" /> with the same
	///     <see cref="DateTime" />.
	/// </summary>
	public override bool Equals(object? obj)
		=> obj is DateTimeBuilder other && Equals(other);

	/// <summary>
	///     Returns the hash code of the <see cref="DateTime" />.
	/// </summary>
	public override int GetHashCode()
		=> _value.GetHashCode();

	/// <summary>
	///     Compares the <see cref="DateTime" /> with the one of the <paramref name="other" /> builder.
	/// </summary>
	public int CompareTo(DateTimeBuilder other)
		=> _value.CompareTo(other._value);

	/// <summary>
	///     Returns <see langword="true" /> if both builders have the same <see cref="DateTime" />.
	/// </summary>
	public static bool operator ==(DateTimeBuilder left, DateTimeBuilder right)
		=> left._value == right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the builders have different <see cref="DateTime" />s.
	/// </summary>
	public static bool operator !=(DateTimeBuilder left, DateTimeBuilder right)
		=> left._value != right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> <see cref="DateTime" /> is earlier than the
	///     <paramref name="right" /> one.
	/// </summary>
	public static bool operator <(DateTimeBuilder left, DateTimeBuilder right)
		=> left._value < right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> <see cref="DateTime" /> is later than the
	///     <paramref name="right" /> one.
	/// </summary>
	public static bool operator >(DateTimeBuilder left, DateTimeBuilder right)
		=> left._value > right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> <see cref="DateTime" /> is earlier than or equal
	///     to the <paramref name="right" /> one.
	/// </summary>
	public static bool operator <=(DateTimeBuilder left, DateTimeBuilder right)
		=> left._value <= right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> <see cref="DateTime" /> is later than or equal
	///     to the <paramref name="right" /> one.
	/// </summary>
	public static bool operator >=(DateTimeBuilder left, DateTimeBuilder right)
		=> left._value >= right._value;

#if NET8_0_OR_GREATER
	/// <summary>
	///     Implicitly casts the <see cref="DateTimeBuilder" /> to a <see cref="DateOnly" />.
	/// </summary>
	public static implicit operator DateOnly(DateTimeBuilder builder)
		=> DateOnly.FromDateTime(builder._value);
#endif

#if NET8_0_OR_GREATER
	/// <summary>
	///     Implicitly casts the <see cref="DateTimeBuilder" /> to a <see cref="TimeOnly" />.
	/// </summary>
	public static implicit operator TimeOnly(DateTimeBuilder builder)
		=> TimeOnly.FromDateTime(builder._value);
#endif

	/// <summary>
	///     Adds a <see cref="TimeSpan" /> to the <see cref="DateTime" />.
	/// </summary>
	public static DateTimeBuilder operator +(DateTimeBuilder builder, TimeSpan time)
		=> new(builder._value + time);

	/// <summary>
	///     Subtracts a <see cref="TimeSpan" /> from the <see cref="DateTime" />.
	/// </summary>
	public static DateTimeBuilder operator -(DateTimeBuilder builder, TimeSpan time)
		=> new(builder._value - time);

	internal DateTimeBuilder SpecifyKind(DateTimeKind kind)
		=> new(DateTime.SpecifyKind(_value, kind));

	internal DateTimeOffsetBuilder SetOffset(TimeSpan offset)
		=> new(new DateTimeOffset(_value, offset));
}
