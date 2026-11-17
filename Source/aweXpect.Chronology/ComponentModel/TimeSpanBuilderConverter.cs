using System;
using System.ComponentModel;
using System.Globalization;

namespace aweXpect.Chronology.ComponentModel;

/// <summary>
///     Converts a <see cref="TimeSpanBuilder" /> to the types it implicitly casts to, for code that only sees it as an
///     <see cref="object" />, such as an equivalency comparison.
/// </summary>
public sealed class TimeSpanBuilderConverter : TypeConverter
{
	/// <inheritdoc />
	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
		=> destinationType == typeof(TimeSpan) ||
#if NET8_0_OR_GREATER
		   destinationType == typeof(TimeOnly) ||
#endif
		   base.CanConvertTo(context, destinationType);

	/// <inheritdoc />
	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
		Type destinationType)
	{
		if (value is not TimeSpanBuilder builder)
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}

		if (destinationType == typeof(TimeSpan))
		{
			return (TimeSpan)builder;
		}
#if NET8_0_OR_GREATER

		if (destinationType == typeof(TimeOnly))
		{
			return (TimeOnly)builder;
		}
#endif

		return base.ConvertTo(context, culture, value, destinationType);
	}
}
