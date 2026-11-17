using System.ComponentModel;
using System.Globalization;
using aweXpect.Chronology.ComponentModel;

namespace aweXpect.Chronology.Tests;

public sealed class DateBuilderConverterTests
{
	[Test]
	public async Task CanConvertTo_DateTime_ShouldReturnTrue()
	{
		DateBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(DateTime));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_String_ShouldReturnTrue()
	{
		DateBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(string));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_UnsupportedType_ShouldReturnFalse()
	{
		DateBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(TimeSpan));

		await That(result).IsFalse();
	}

	[Test]
	public async Task ConvertTo_DateTime_ShouldReturnTheDate()
	{
		DateBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, 24.December(2024), typeof(DateTime));

		await That(result).IsEqualTo(new DateTime(2024, 12, 24));
	}

	[Test]
	public async Task ConvertTo_OtherValue_ShouldThrowNotSupportedException()
	{
		DateBuilderConverter converter = new();

		void Act()
			=> converter.ConvertTo(null, CultureInfo.InvariantCulture, new DateTime(2024, 12, 24), typeof(DateTime));

		await That(Act).ThrowsExactly<NotSupportedException>();
	}

	[Test]
	public async Task ConvertTo_String_ShouldReturnToString()
	{
		DateBuilderConverter converter = new();
		DateBuilder builder = 24.December(2024);

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, builder, typeof(string));

		await That(result).IsEqualTo(builder.ToString());
	}

	[Test]
	public async Task ConvertTo_UnsupportedType_ShouldThrowNotSupportedException()
	{
		DateBuilderConverter converter = new();

		void Act()
			=> converter.ConvertTo(null, CultureInfo.InvariantCulture, 24.December(2024), typeof(TimeSpan));

		await That(Act).ThrowsExactly<NotSupportedException>();
	}

	[Test]
	public async Task GetConverter_ShouldReturnDateBuilderConverter()
	{
		TypeConverter result = TypeDescriptor.GetConverter(typeof(DateBuilder));

		await That(result).IsExactly<DateBuilderConverter>();
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task CanConvertTo_DateOnly_ShouldReturnTrue()
	{
		DateBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(DateOnly));

		await That(result).IsTrue();
	}

	[Test]
	public async Task ConvertTo_DateOnly_ShouldReturnTheDate()
	{
		DateBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, 24.December(2024), typeof(DateOnly));

		await That(result).IsEqualTo(new DateOnly(2024, 12, 24));
	}
#endif
}
