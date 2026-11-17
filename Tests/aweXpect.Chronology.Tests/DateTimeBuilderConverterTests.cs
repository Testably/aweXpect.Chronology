using System.ComponentModel;
using System.Globalization;
using aweXpect.Chronology.ComponentModel;

namespace aweXpect.Chronology.Tests;

public sealed class DateTimeBuilderConverterTests
{
	[Test]
	public async Task CanConvertTo_DateTime_ShouldReturnTrue()
	{
		DateTimeBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(DateTime));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_String_ShouldReturnTrue()
	{
		DateTimeBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(string));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_UnsupportedType_ShouldReturnFalse()
	{
		DateTimeBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(TimeSpan));

		await That(result).IsFalse();
	}

	[Test]
	public async Task ConvertTo_DateTime_ShouldReturnTheDateTime()
	{
		DateTimeBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, 24.December(2024).At(18, 30),
			typeof(DateTime));

		await That(result).IsEqualTo(new DateTime(2024, 12, 24, 18, 30, 0));
	}

	[Test]
	public async Task ConvertTo_OtherValue_ShouldThrowNotSupportedException()
	{
		DateTimeBuilderConverter converter = new();

		void Act()
			=> converter.ConvertTo(null, CultureInfo.InvariantCulture, new DateTime(2024, 12, 24, 18, 30, 0),
				typeof(DateTime));

		await That(Act).ThrowsExactly<NotSupportedException>();
	}

	[Test]
	public async Task ConvertTo_String_ShouldReturnToString()
	{
		DateTimeBuilderConverter converter = new();
		DateTimeBuilder builder = 24.December(2024).At(18, 30);

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, builder, typeof(string));

		await That(result).IsEqualTo(builder.ToString());
	}

	[Test]
	public async Task ConvertTo_UnsupportedType_ShouldThrowNotSupportedException()
	{
		DateTimeBuilderConverter converter = new();

		void Act()
			=> converter.ConvertTo(null, CultureInfo.InvariantCulture, 24.December(2024).At(18, 30),
				typeof(TimeSpan));

		await That(Act).ThrowsExactly<NotSupportedException>();
	}

	[Test]
	public async Task GetConverter_ShouldReturnDateTimeBuilderConverter()
	{
		TypeConverter result = TypeDescriptor.GetConverter(typeof(DateTimeBuilder));

		await That(result).IsExactly<DateTimeBuilderConverter>();
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task CanConvertTo_DateOnly_ShouldReturnTrue()
	{
		DateTimeBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(DateOnly));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_TimeOnly_ShouldReturnTrue()
	{
		DateTimeBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(TimeOnly));

		await That(result).IsTrue();
	}

	[Test]
	public async Task ConvertTo_DateOnly_ShouldReturnTheDate()
	{
		DateTimeBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, 24.December(2024).At(18, 30),
			typeof(DateOnly));

		await That(result).IsEqualTo(new DateOnly(2024, 12, 24));
	}

	[Test]
	public async Task ConvertTo_TimeOnly_ShouldReturnTheTimeOfDay()
	{
		DateTimeBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, 24.December(2024).At(18, 30),
			typeof(TimeOnly));

		await That(result).IsEqualTo(new TimeOnly(18, 30));
	}
#endif
}
