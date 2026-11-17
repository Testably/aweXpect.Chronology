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
