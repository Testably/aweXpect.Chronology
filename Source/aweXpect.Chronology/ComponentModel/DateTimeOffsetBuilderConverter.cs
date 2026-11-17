using System;
using System.ComponentModel;
using System.Globalization;

namespace aweXpect.Chronology.ComponentModel;

/// <summary>
///     Converts a <see cref="DateTimeOffsetBuilder" /> to the types it implicitly casts to, for code that only sees it
///     as an <see cref="object" />, such as an equivalency comparison.
/// </summary>
public sealed class DateTimeOffsetBuilderConverter : TypeConverter
{
	/// <inheritdoc />
	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
		=> destinationType == typeof(DateTimeOffset) ||
		   destinationType == typeof(DateTime) ||
#if NET8_0_OR_GREATER
		   destinationType == typeof(DateOnly) ||
		   destinationType == typeof(TimeOnly) ||
#endif
		   base.CanConvertTo(context, destinationType);

	/// <inheritdoc />
	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
		Type destinationType)
	{
		if (value is not DateTimeOffsetBuilder builder)
		{
			return base.ConvertTo(context, culture, value, destinationType);
		}

		if (destinationType == typeof(DateTimeOffset))
		{
			return (DateTimeOffset)builder;
		}

		if (destinationType == typeof(DateTime))
		{
			return (DateTime)builder;
		}
#if NET8_0_OR_GREATER

		if (destinationType == typeof(DateOnly))
		{
			return (DateOnly)builder;
		}

		if (destinationType == typeof(TimeOnly))
		{
			return (TimeOnly)builder;
		}
#endif

		return base.ConvertTo(context, culture, value, destinationType);
	}
}
