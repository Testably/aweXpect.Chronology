using System;
using System.ComponentModel;
using System.Globalization;

namespace aweXpect.Chronology.ComponentModel;

/// <summary>
///     Converts a <see cref="DateBuilder" /> to the types it implicitly casts to, for code that only sees it as an
///     <see cref="object" />, such as an equivalency comparison.
/// </summary>
public sealed class DateBuilderConverter : TypeConverter
{
	/// <inheritdoc />
	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType)
		=> destinationType == typeof(DateTime) ||
#if NET8_0_OR_GREATER
		   destinationType == typeof(DateOnly) ||
#endif
		   base.CanConvertTo(context, destinationType);

	/// <inheritdoc />
	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value,
		Type destinationType)
	{
		if (value is DateBuilder builder)
		{
			if (destinationType == typeof(DateTime))
			{
				return (DateTime)builder;
			}
#if NET8_0_OR_GREATER

			if (destinationType == typeof(DateOnly))
			{
				return (DateOnly)builder;
			}
#endif
		}

		return base.ConvertTo(context, culture, value, destinationType);
	}
}
