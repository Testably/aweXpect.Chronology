using System;

namespace aweXpect.Chronology;

#if NET8_0_OR_GREATER
/// <summary>
///     A builder that allows implicit cast to <see cref="TimeSpan" /> and <see cref="TimeOnly" />.
/// </summary>
#else
/// <summary>
///     A builder that allows implicit cast to <see cref="TimeSpan" />.
/// </summary>
#endif
public readonly struct TimeSpanBuilder(TimeSpan value)
{
	private readonly TimeSpan _value = value;

	/// <summary>
	///     Implicitly casts the <see cref="TimeSpanBuilder" /> to a <see cref="TimeSpan" />.
	/// </summary>
	public static implicit operator TimeSpan(TimeSpanBuilder builder)
		=> builder._value;

	/// <summary>
	///     Returns a new <see cref="TimeSpanBuilder" /> whose value is the negated value of this <paramref name="instance" />.
	/// </summary>
	public static TimeSpanBuilder operator -(TimeSpanBuilder instance)
		=> new(instance._value.Negate());

#if NET8_0_OR_GREATER
	/// <summary>
	///     Implicitly casts the <see cref="TimeSpanBuilder" /> to a <see cref="TimeOnly" />.
	/// </summary>
	public static implicit operator TimeOnly(TimeSpanBuilder builder)
		=> TimeOnly.FromTimeSpan(builder._value);
#endif

	/// <summary>
	///     Adds a <see cref="TimeSpan" /> to the <see cref="TimeSpan" />.
	/// </summary>
	public static TimeSpanBuilder operator +(TimeSpanBuilder builder, TimeSpan time)
		=> new(builder._value + time);

	/// <summary>
	///     Subtracts a <see cref="TimeSpan" /> from the <see cref="TimeSpan" />.
	/// </summary>
	public static TimeSpanBuilder operator -(TimeSpanBuilder builder, TimeSpan time)
		=> new(builder._value - time);

	/// <summary>
	///     Multiplies a <see cref="TimeSpan" /> with the <paramref name="multiplier" />.
	/// </summary>
	public static TimeSpanBuilder operator *(TimeSpanBuilder builder, double multiplier)
#if NET8_0_OR_GREATER
		=> new(builder._value * multiplier);
#else
		=> new(FromDoubleTicks(builder._value.Ticks * ThrowIfNaN(multiplier, "factor")));
#endif

	/// <summary>
	///     Divides a <see cref="TimeSpan" /> by the <paramref name="divisor" />.
	/// </summary>
	public static TimeSpanBuilder operator /(TimeSpanBuilder builder, double divisor)
#if NET8_0_OR_GREATER
		=> new(builder._value / divisor);
#else
		=> new(FromDoubleTicks(builder._value.Ticks / ThrowIfNaN(divisor, "divisor")));
#endif

#if !NET8_0_OR_GREATER
	/// <summary>
	///     Mirrors the BCL <c>TimeSpan * double</c> and <c>TimeSpan / double</c> operators, which netstandard2.0 lacks.
	/// </summary>
	private static double ThrowIfNaN(double value, string paramName)
		=> double.IsNaN(value)
			? throw new ArgumentException("TimeSpan does not accept floating point Not-a-Number values.", paramName)
			: value;

	private static TimeSpan FromDoubleTicks(double ticks)
	{
		ticks = Math.Round(ticks);
		if (ticks > long.MaxValue || ticks < long.MinValue || double.IsNaN(ticks))
		{
			throw new OverflowException("TimeSpan overflowed because the duration is too long.");
		}

		return ticks >= long.MaxValue ? TimeSpan.MaxValue : TimeSpan.FromTicks((long)ticks);
	}
#endif
}
