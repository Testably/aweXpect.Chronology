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
[TypeConverter(typeof(DateBuilderConverter))]
public readonly struct DateBuilder(DateTime value)
	: IEquatable<DateBuilder>, IComparable<DateBuilder>
{
	private readonly DateTime _value = value;

	/// <summary>
	///     Implicitly casts the <see cref="DateBuilder" /> to a <see cref="DateTime" />.
	/// </summary>
	public static implicit operator DateTime(DateBuilder builder)
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
	public bool Equals(DateBuilder other)
		=> _value.Equals(other._value);

	/// <summary>
	///     Returns <see langword="true" /> if <paramref name="obj" /> is a <see cref="DateBuilder" /> with the same
	///     <see cref="DateTime" />.
	/// </summary>
	public override bool Equals(object? obj)
		=> obj is DateBuilder other && Equals(other);

	/// <summary>
	///     Returns the hash code of the <see cref="DateTime" />.
	/// </summary>
	public override int GetHashCode()
		=> _value.GetHashCode();

	/// <summary>
	///     Compares the <see cref="DateTime" /> with the one of the <paramref name="other" /> builder.
	/// </summary>
	public int CompareTo(DateBuilder other)
		=> _value.CompareTo(other._value);

	/// <summary>
	///     Returns <see langword="true" /> if both builders have the same <see cref="DateTime" />.
	/// </summary>
	public static bool operator ==(DateBuilder left, DateBuilder right)
		=> left._value == right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the builders have different <see cref="DateTime" />s.
	/// </summary>
	public static bool operator !=(DateBuilder left, DateBuilder right)
		=> left._value != right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> <see cref="DateTime" /> is earlier than the
	///     <paramref name="right" /> one.
	/// </summary>
	public static bool operator <(DateBuilder left, DateBuilder right)
		=> left._value < right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> <see cref="DateTime" /> is later than the
	///     <paramref name="right" /> one.
	/// </summary>
	public static bool operator >(DateBuilder left, DateBuilder right)
		=> left._value > right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> <see cref="DateTime" /> is earlier than or equal
	///     to the <paramref name="right" /> one.
	/// </summary>
	public static bool operator <=(DateBuilder left, DateBuilder right)
		=> left._value <= right._value;

	/// <summary>
	///     Returns <see langword="true" /> if the <paramref name="left" /> <see cref="DateTime" /> is later than or equal
	///     to the <paramref name="right" /> one.
	/// </summary>
	public static bool operator >=(DateBuilder left, DateBuilder right)
		=> left._value >= right._value;

#if NET8_0_OR_GREATER
	/// <summary>
	///     Implicitly casts the <see cref="DateBuilder" /> to a <see cref="DateOnly" />.
	/// </summary>
	public static implicit operator DateOnly(DateBuilder builder)
		=> DateOnly.FromDateTime(builder._value);
#endif

	/// <summary>
	///     Adds a <see cref="TimeSpan" /> to the <see cref="DateTime" />.
	/// </summary>
	public static DateBuilder operator +(DateBuilder builder, TimeSpan time)
		=> new(builder._value + time);

	/// <summary>
	///     Subtracts a <see cref="TimeSpan" /> from the <see cref="DateTime" />.
	/// </summary>
	public static DateBuilder operator -(DateBuilder builder, TimeSpan time)
		=> new(builder._value - time);

	internal DateTimeOffsetBuilder SetOffset(TimeSpan offset)
		=> new(new DateTimeOffset(_value, offset));
}
