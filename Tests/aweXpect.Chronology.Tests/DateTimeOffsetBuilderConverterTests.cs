using System.ComponentModel;
using System.Globalization;
using aweXpect.Chronology.ComponentModel;

namespace aweXpect.Chronology.Tests;

public sealed class DateTimeOffsetBuilderConverterTests
{
	[Test]
	public async Task CanConvertTo_DateTime_ShouldReturnTrue()
	{
		DateTimeOffsetBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(DateTime));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_DateTimeOffset_ShouldReturnTrue()
	{
		DateTimeOffsetBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(DateTimeOffset));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_String_ShouldReturnTrue()
	{
		DateTimeOffsetBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(string));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_UnsupportedType_ShouldReturnFalse()
	{
		DateTimeOffsetBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(TimeSpan));

		await That(result).IsFalse();
	}

	[Test]
	public async Task ConvertTo_DateTime_ShouldReturnTheDateTime()
	{
		DateTimeOffsetBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture,
			24.December(2024).At(18, 30).WithOffset(2.Hours()), typeof(DateTime));

		await That(result).IsEqualTo(new DateTime(2024, 12, 24, 18, 30, 0));
	}

	[Test]
	public async Task ConvertTo_DateTimeOffset_ShouldReturnTheDateTimeOffset()
	{
		DateTimeOffsetBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture,
			24.December(2024).At(18, 30).WithOffset(2.Hours()), typeof(DateTimeOffset));

		await That(result).IsEqualTo(new DateTimeOffset(2024, 12, 24, 18, 30, 0, TimeSpan.FromHours(2)));
	}

	[Test]
	public async Task ConvertTo_OtherValue_ShouldThrowNotSupportedException()
	{
		DateTimeOffsetBuilderConverter converter = new();

		void Act()
			=> converter.ConvertTo(null, CultureInfo.InvariantCulture,
				new DateTimeOffset(2024, 12, 24, 18, 30, 0, TimeSpan.FromHours(2)), typeof(DateTimeOffset));

		await That(Act).ThrowsExactly<NotSupportedException>();
	}

	[Test]
	public async Task ConvertTo_String_ShouldReturnToString()
	{
		DateTimeOffsetBuilderConverter converter = new();
		DateTimeOffsetBuilder builder = 24.December(2024).At(18, 30).WithOffset(2.Hours());

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, builder, typeof(string));

		await That(result).IsEqualTo(builder.ToString());
	}

	[Test]
	public async Task ConvertTo_UnsupportedType_ShouldThrowNotSupportedException()
	{
		DateTimeOffsetBuilderConverter converter = new();

		void Act()
			=> converter.ConvertTo(null, CultureInfo.InvariantCulture,
				24.December(2024).At(18, 30).WithOffset(2.Hours()), typeof(TimeSpan));

		await That(Act).ThrowsExactly<NotSupportedException>();
	}

	[Test]
	public async Task GetConverter_ShouldReturnDateTimeOffsetBuilderConverter()
	{
		TypeConverter result = TypeDescriptor.GetConverter(typeof(DateTimeOffsetBuilder));

		await That(result).IsExactly<DateTimeOffsetBuilderConverter>();
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task CanConvertTo_DateOnly_ShouldReturnTrue()
	{
		DateTimeOffsetBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(DateOnly));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_TimeOnly_ShouldReturnTrue()
	{
		DateTimeOffsetBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(TimeOnly));

		await That(result).IsTrue();
	}

	[Test]
	public async Task ConvertTo_DateOnly_ShouldReturnTheDate()
	{
		DateTimeOffsetBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture,
			24.December(2024).At(18, 30).WithOffset(2.Hours()), typeof(DateOnly));

		await That(result).IsEqualTo(new DateOnly(2024, 12, 24));
	}

	[Test]
	public async Task ConvertTo_TimeOnly_ShouldReturnTheTimeOfDay()
	{
		DateTimeOffsetBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture,
			24.December(2024).At(18, 30).WithOffset(2.Hours()), typeof(TimeOnly));

		await That(result).IsEqualTo(new TimeOnly(18, 30));
	}
#endif
}
