namespace aweXpect.Chronology.Tests;

public sealed class DateTimeBuilderTests
{
	[Test]
	public async Task MinusOperator_ShouldSubtractTimeSpan()
	{
		DateTimeBuilder expected = 23.March(2024).At(10, 00);
		DateTimeBuilder builder = new(23.March(2024).At(12, 00));

		DateTime result = builder - 2.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task PlusOperator_ShouldAddTimeSpan()
	{
		DateTimeBuilder expected = 23.March(2024).At(14, 00);
		DateTimeBuilder builder = new(23.March(2024).At(12, 00));

		DateTime result = builder + 2.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateTime()
	{
		DateTime expected = new(2024, 03, 23, 12, 13, 14);
		DateTimeBuilder builder = new(23.March(2024).At(12, 13, 14));

		DateTime result = builder;

		await That(result).IsEqualTo(expected);
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateOnly()
	{
		DateOnly expected = new(2024, 03, 23);
		DateTimeBuilder builder = new(23.March(2024).At(12, 13, 14));

		DateOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToTimeOnly()
	{
		TimeOnly expected = new(12, 13, 14);
		DateTimeBuilder builder = new(23.March(2024).At(12, 13, 14));

		TimeOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif

	[Test]
	public async Task ToString_ShouldReturnDateTimeString()
	{
		DateTime value = new(2024, 03, 23, 12, 13, 14);
		DateTimeBuilder builder = 23.March(2024).At(12, 13, 14);

		string result = $"{builder}";

		await That(result).IsEqualTo(value.ToString())
			.Because("string interpolation should print the value instead of the type name");
	}

	[Test]
	[Arguments(30, 30, true)]
	[Arguments(30, 31, false)]
	public async Task Equals_ShouldCompareDateTimes(int leftMinute, int rightMinute, bool expected)
	{
		DateTimeBuilder left = 23.March(2024).At(12, leftMinute);
		DateTimeBuilder right = 23.March(2024).At(12, rightMinute);

		bool result = left.Equals(right);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task Equals_WhenKindDiffers_ShouldReturnTrue()
	{
		DateTimeBuilder left = 23.March(2024).At(12, 30).AsUtc();
		DateTimeBuilder right = 23.March(2024).At(12, 30).AsLocal();

		bool result = left.Equals(right);

		await That(result).IsTrue()
			.Because("the equality follows DateTime, which ignores the Kind");
	}

	[Test]
	public async Task Equals_WithObject_WhenBuilderHasSameDateTime_ShouldReturnTrue()
	{
		DateTimeBuilder builder = 23.March(2024).At(12, 30);
		object other = 23.March(2024).At(12, 30);

		bool result = builder.Equals(other);

		await That(result).IsTrue();
	}

	[Test]
	public async Task Equals_WithObject_WhenBuilderHasDifferentDateTime_ShouldReturnFalse()
	{
		DateTimeBuilder builder = 23.March(2024).At(12, 30);
		object other = 23.March(2024).At(12, 31);

		bool result = builder.Equals(other);

		await That(result).IsFalse();
	}

	[Test]
	public async Task Equals_WithObject_WhenDateTime_ShouldReturnFalse()
	{
		DateTimeBuilder builder = 23.March(2024).At(12, 30);
		object other = new DateTime(2024, 3, 23, 12, 30, 0);

		bool result = builder.Equals(other);

		await That(result).IsFalse()
			.Because("DateTime.Equals(builder) is false, so the equality must not be one-sided");
	}

	[Test]
	public async Task Equals_WithObject_WhenNull_ShouldReturnFalse()
	{
		DateTimeBuilder builder = 23.March(2024).At(12, 30);

		bool result = builder.Equals(null);

		await That(result).IsFalse();
	}

	[Test]
	public async Task GetHashCode_ShouldBeEqualForEqualDateTimes()
	{
		DateTimeBuilder builder = 23.March(2024).At(12, 30);

		int result = 23.March(2024).At(12, 30).GetHashCode();

		await That(result).IsEqualTo(builder.GetHashCode());
	}

	[Test]
	public async Task GetHashCode_ShouldUseDateTimeHashCode()
	{
		DateTimeBuilder builder = 23.March(2024).At(12, 30);

		int result = builder.GetHashCode();

		await That(result).IsEqualTo(new DateTime(2024, 3, 23, 12, 30, 0).GetHashCode());
	}

	[Test]
	[Arguments(29, 30, -1)]
	[Arguments(30, 30, 0)]
	[Arguments(31, 30, 1)]
	public async Task CompareTo_ShouldCompareDateTimes(int leftMinute, int rightMinute, int expected)
	{
		DateTimeBuilder left = 23.March(2024).At(12, leftMinute);
		DateTimeBuilder right = 23.March(2024).At(12, rightMinute);

		int result = left.CompareTo(right);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, false)]
	[Arguments(30, 30, true)]
	[Arguments(31, 30, false)]
	public async Task EqualityOperator_ShouldCompareDateTimes(int leftMinute, int rightMinute, bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute) == 23.March(2024).At(12, rightMinute);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, true)]
	[Arguments(30, 30, false)]
	[Arguments(31, 30, true)]
	public async Task InequalityOperator_ShouldCompareDateTimes(int leftMinute, int rightMinute, bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute) != 23.March(2024).At(12, rightMinute);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, true)]
	[Arguments(30, 30, false)]
	[Arguments(31, 30, false)]
	public async Task LessThanOperator_ShouldCompareDateTimes(int leftMinute, int rightMinute, bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute) < 23.March(2024).At(12, rightMinute);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, false)]
	[Arguments(30, 30, false)]
	[Arguments(31, 30, true)]
	public async Task GreaterThanOperator_ShouldCompareDateTimes(int leftMinute, int rightMinute, bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute) > 23.March(2024).At(12, rightMinute);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, true)]
	[Arguments(30, 30, true)]
	[Arguments(31, 30, false)]
	public async Task LessThanOrEqualOperator_ShouldCompareDateTimes(int leftMinute, int rightMinute,
		bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute) <= 23.March(2024).At(12, rightMinute);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, false)]
	[Arguments(30, 30, true)]
	[Arguments(31, 30, true)]
	public async Task GreaterThanOrEqualOperator_ShouldCompareDateTimes(int leftMinute, int rightMinute,
		bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute) >= 23.March(2024).At(12, rightMinute);

		await That(result).IsEqualTo(expected);
	}
}
