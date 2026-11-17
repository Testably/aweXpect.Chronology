namespace aweXpect.Chronology.Tests;

public sealed class DateTimeOffsetBuilderTests
{
	[Test]
	public async Task MinusOperator_ShouldSubtractTimeSpan()
	{
		DateTimeOffsetBuilder expected = 23.March(2024).At(10, 00).WithOffset(2.Hours());
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 00).WithOffset(2.Hours()));

		DateTime result = builder - 2.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task PlusOperator_ShouldAddTimeSpan()
	{
		DateTimeOffsetBuilder expected = 23.March(2024).At(14, 00).WithOffset(2.Hours());
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 00).WithOffset(2.Hours()));

		DateTime result = builder + 2.Hours();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateTime()
	{
		DateTime expected = new(2024, 03, 23, 12, 13, 14);
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 13, 14).WithOffset(2.Hours()));

		DateTime result = builder;

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateTimeOffset()
	{
		DateTimeOffset expected = new(2024, 03, 23, 12, 13, 14, TimeSpan.FromHours(2));
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 13, 14).WithOffset(2.Hours()));

		DateTimeOffset result = builder;

		await That(result).IsEqualTo(expected);
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateOnly()
	{
		DateOnly expected = new(2024, 03, 23);
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 13, 14).WithOffset(2.Hours()));

		DateOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToTimeOnly()
	{
		TimeOnly expected = new(12, 13, 14);
		DateTimeOffsetBuilder builder = new(23.March(2024).At(12, 13, 14).WithOffset(2.Hours()));

		TimeOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif

	[Test]
	public async Task ToString_ShouldReturnDateTimeOffsetString()
	{
		DateTimeOffset value = new(2024, 03, 23, 12, 13, 14, TimeSpan.FromHours(2));
		DateTimeOffsetBuilder builder = 23.March(2024).At(12, 13, 14).WithOffset(2.Hours());

		string result = $"{builder}";

		await That(result).IsEqualTo(value.ToString())
			.Because("string interpolation should print the value instead of the type name");
	}

	[Test]
	[Arguments(30, 30, true)]
	[Arguments(30, 31, false)]
	public async Task Equals_ShouldCompareDateTimeOffsets(int leftMinute, int rightMinute, bool expected)
	{
		DateTimeOffsetBuilder left = 23.March(2024).At(12, leftMinute).WithOffset(2.Hours());
		DateTimeOffsetBuilder right = 23.March(2024).At(12, rightMinute).WithOffset(2.Hours());

		bool result = left.Equals(right);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task Equals_WhenSamePointInTimeWithDifferentOffset_ShouldReturnTrue()
	{
		DateTimeOffsetBuilder left = 23.March(2024).At(12, 30).WithOffset(2.Hours());
		DateTimeOffsetBuilder right = 23.March(2024).At(10, 30).WithOffset(TimeSpan.Zero);

		bool result = left.Equals(right);

		await That(result).IsTrue()
			.Because("the equality follows DateTimeOffset, which compares the point in time and ignores the offset");
	}

	[Test]
	public async Task Equals_WithObject_WhenBuilderHasSamePointInTime_ShouldReturnTrue()
	{
		DateTimeOffsetBuilder builder = 23.March(2024).At(12, 30).WithOffset(2.Hours());
		object other = 23.March(2024).At(12, 30).WithOffset(2.Hours());

		bool result = builder.Equals(other);

		await That(result).IsTrue();
	}

	[Test]
	public async Task Equals_WithObject_WhenBuilderHasDifferentPointInTime_ShouldReturnFalse()
	{
		DateTimeOffsetBuilder builder = 23.March(2024).At(12, 30).WithOffset(2.Hours());
		object other = 23.March(2024).At(12, 30).WithOffset(1.Hours());

		bool result = builder.Equals(other);

		await That(result).IsFalse();
	}

	[Test]
	public async Task Equals_WithObject_WhenDateTimeOffset_ShouldReturnFalse()
	{
		DateTimeOffsetBuilder builder = 23.March(2024).At(12, 30).WithOffset(2.Hours());
		object other = new DateTimeOffset(2024, 3, 23, 12, 30, 0, TimeSpan.FromHours(2));

		bool result = builder.Equals(other);

		await That(result).IsFalse()
			.Because("DateTimeOffset.Equals(builder) is false, so the equality must not be one-sided");
	}

	[Test]
	public async Task Equals_WithObject_WhenNull_ShouldReturnFalse()
	{
		DateTimeOffsetBuilder builder = 23.March(2024).At(12, 30).WithOffset(2.Hours());

		bool result = builder.Equals(null);

		await That(result).IsFalse();
	}

	[Test]
	public async Task GetHashCode_ShouldBeEqualForSamePointInTime()
	{
		DateTimeOffsetBuilder builder = 23.March(2024).At(12, 30).WithOffset(2.Hours());

		int result = 23.March(2024).At(10, 30).WithOffset(TimeSpan.Zero).GetHashCode();

		await That(result).IsEqualTo(builder.GetHashCode())
			.Because("builders that are equal must have the same hash code");
	}

	[Test]
	public async Task GetHashCode_ShouldUseDateTimeOffsetHashCode()
	{
		DateTimeOffsetBuilder builder = 23.March(2024).At(12, 30).WithOffset(2.Hours());

		int result = builder.GetHashCode();

		await That(result).IsEqualTo(new DateTimeOffset(2024, 3, 23, 12, 30, 0, TimeSpan.FromHours(2)).GetHashCode());
	}

	[Test]
	[Arguments(29, 30, -1)]
	[Arguments(30, 30, 0)]
	[Arguments(31, 30, 1)]
	public async Task CompareTo_ShouldCompareDateTimeOffsets(int leftMinute, int rightMinute, int expected)
	{
		DateTimeOffsetBuilder left = 23.March(2024).At(12, leftMinute).WithOffset(2.Hours());
		DateTimeOffsetBuilder right = 23.March(2024).At(12, rightMinute).WithOffset(2.Hours());

		int result = left.CompareTo(right);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task CompareTo_ShouldComparePointInTime()
	{
		DateTimeOffsetBuilder left = 23.March(2024).At(12, 30).WithOffset(2.Hours());
		DateTimeOffsetBuilder right = 23.March(2024).At(11, 30).WithOffset(0.Hours());

		int result = left.CompareTo(right);

		await That(result).IsEqualTo(-1)
			.Because("12:30 +02:00 is one hour before 11:30 +00:00");
	}

	[Test]
	[Arguments(29, 30, false)]
	[Arguments(30, 30, true)]
	[Arguments(31, 30, false)]
	public async Task EqualityOperator_ShouldCompareDateTimeOffsets(int leftMinute, int rightMinute,
		bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute).WithOffset(2.Hours()) ==
		              23.March(2024).At(12, rightMinute).WithOffset(2.Hours());

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, true)]
	[Arguments(30, 30, false)]
	[Arguments(31, 30, true)]
	public async Task InequalityOperator_ShouldCompareDateTimeOffsets(int leftMinute, int rightMinute,
		bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute).WithOffset(2.Hours()) !=
		              23.March(2024).At(12, rightMinute).WithOffset(2.Hours());

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, true)]
	[Arguments(30, 30, false)]
	[Arguments(31, 30, false)]
	public async Task LessThanOperator_ShouldCompareDateTimeOffsets(int leftMinute, int rightMinute,
		bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute).WithOffset(2.Hours()) <
		              23.March(2024).At(12, rightMinute).WithOffset(2.Hours());

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, false)]
	[Arguments(30, 30, false)]
	[Arguments(31, 30, true)]
	public async Task GreaterThanOperator_ShouldCompareDateTimeOffsets(int leftMinute, int rightMinute,
		bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute).WithOffset(2.Hours()) >
		              23.March(2024).At(12, rightMinute).WithOffset(2.Hours());

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, true)]
	[Arguments(30, 30, true)]
	[Arguments(31, 30, false)]
	public async Task LessThanOrEqualOperator_ShouldCompareDateTimeOffsets(int leftMinute, int rightMinute,
		bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute).WithOffset(2.Hours()) <=
		              23.March(2024).At(12, rightMinute).WithOffset(2.Hours());

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(29, 30, false)]
	[Arguments(30, 30, true)]
	[Arguments(31, 30, true)]
	public async Task GreaterThanOrEqualOperator_ShouldCompareDateTimeOffsets(int leftMinute, int rightMinute,
		bool expected)
	{
		bool result = 23.March(2024).At(12, leftMinute).WithOffset(2.Hours()) >=
		              23.March(2024).At(12, rightMinute).WithOffset(2.Hours());

		await That(result).IsEqualTo(expected);
	}
}
