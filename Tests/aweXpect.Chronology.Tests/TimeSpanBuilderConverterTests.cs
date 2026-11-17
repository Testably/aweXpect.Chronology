using System.ComponentModel;
using System.Globalization;
using aweXpect.Chronology.ComponentModel;

namespace aweXpect.Chronology.Tests;

public sealed class TimeSpanBuilderConverterTests
{
	[Test]
	public async Task CanConvertTo_String_ShouldReturnTrue()
	{
		TimeSpanBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(string));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_TimeSpan_ShouldReturnTrue()
	{
		TimeSpanBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(TimeSpan));

		await That(result).IsTrue();
	}

	[Test]
	public async Task CanConvertTo_UnsupportedType_ShouldReturnFalse()
	{
		TimeSpanBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(DateTime));

		await That(result).IsFalse();
	}

	[Test]
	public async Task ConvertTo_OtherValue_ShouldThrowNotSupportedException()
	{
		TimeSpanBuilderConverter converter = new();

		void Act()
			=> converter.ConvertTo(null, CultureInfo.InvariantCulture, TimeSpan.FromMinutes(5), typeof(TimeSpan));

		await That(Act).ThrowsExactly<NotSupportedException>();
	}

	[Test]
	public async Task ConvertTo_String_ShouldReturnToString()
	{
		TimeSpanBuilderConverter converter = new();
		TimeSpanBuilder builder = 5.Minutes();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, builder, typeof(string));

		await That(result).IsEqualTo(builder.ToString());
	}

	[Test]
	public async Task ConvertTo_TimeSpan_ShouldReturnTheTimeSpan()
	{
		TimeSpanBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, 5.Minutes(), typeof(TimeSpan));

		await That(result).IsEqualTo(TimeSpan.FromMinutes(5));
	}

	[Test]
	public async Task ConvertTo_UnsupportedType_ShouldThrowNotSupportedException()
	{
		TimeSpanBuilderConverter converter = new();

		void Act()
			=> converter.ConvertTo(null, CultureInfo.InvariantCulture, 5.Minutes(), typeof(DateTime));

		await That(Act).ThrowsExactly<NotSupportedException>();
	}

	[Test]
	public async Task GetConverter_ShouldReturnTimeSpanBuilderConverter()
	{
		TypeConverter result = TypeDescriptor.GetConverter(typeof(TimeSpanBuilder));

		await That(result).IsExactly<TimeSpanBuilderConverter>();
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task CanConvertTo_TimeOnly_ShouldReturnTrue()
	{
		TimeSpanBuilderConverter converter = new();

		bool result = converter.CanConvertTo(null, typeof(TimeOnly));

		await That(result).IsTrue();
	}

	[Test]
	public async Task ConvertTo_TimeOnly_ShouldReturnTheTimeOfDay()
	{
		TimeSpanBuilderConverter converter = new();

		object? result = converter.ConvertTo(null, CultureInfo.InvariantCulture, 18.Hours(30.Minutes()),
			typeof(TimeOnly));

		await That(result).IsEqualTo(new TimeOnly(18, 30));
	}
#endif
}
