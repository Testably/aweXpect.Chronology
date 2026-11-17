namespace aweXpect.Chronology.Tests;

public sealed class DateBuilderTests
{
	[Test]
	public async Task MinusOperator_ShouldSubtractTimeSpan()
	{
		DateBuilder expected = 20.March(2024);
		DateBuilder builder = new(23.March(2024));

		DateTime result = builder - 3.Days();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task PlusOperator_ShouldAddTimeSpan()
	{
		DateBuilder expected = 26.March(2024);
		DateBuilder builder = new(23.March(2024));

		DateTime result = builder + 3.Days();

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateTime()
	{
		DateTime expected = new(2024, 03, 23);
		DateBuilder builder = new(23.March(2024));

		DateTime result = builder;

		await That(result).IsEqualTo(expected);
	}

#if NET8_0_OR_GREATER
	[Test]
	public async Task ImplicitOperator_ShouldConvertToDateOnly()
	{
		DateOnly expected = new(2024, 03, 23);
		DateBuilder builder = new(23.March(2024));

		DateOnly result = builder;

		await That(result).IsEqualTo(expected);
	}
#endif

	[Test]
	public async Task ToString_ShouldReturnDateTimeString()
	{
		DateTime value = new(2024, 03, 23);
		DateBuilder builder = 23.March(2024);

		string result = $"{builder}";

		await That(result).IsEqualTo(value.ToString())
			.Because("string interpolation should print the value instead of the type name");
	}

	[Test]
	[Arguments(23, 23, true)]
	[Arguments(23, 24, false)]
	public async Task Equals_ShouldCompareDates(int leftDay, int rightDay, bool expected)
	{
		DateBuilder left = leftDay.March(2024);
		DateBuilder right = rightDay.March(2024);

		bool result = left.Equals(right);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	public async Task Equals_WithObject_WhenBuilderHasSameDate_ShouldReturnTrue()
	{
		DateBuilder builder = 23.March(2024);
		object other = 23.March(2024);

		bool result = builder.Equals(other);

		await That(result).IsTrue();
	}

	[Test]
	public async Task Equals_WithObject_WhenBuilderHasDifferentDate_ShouldReturnFalse()
	{
		DateBuilder builder = 23.March(2024);
		object other = 24.March(2024);

		bool result = builder.Equals(other);

		await That(result).IsFalse();
	}

	[Test]
	public async Task Equals_WithObject_WhenDateTime_ShouldReturnFalse()
	{
		DateBuilder builder = 23.March(2024);
		object other = new DateTime(2024, 3, 23);

		bool result = builder.Equals(other);

		await That(result).IsFalse()
			.Because("DateTime.Equals(builder) is false, so the equality must not be one-sided");
	}

	[Test]
	public async Task Equals_WithObject_WhenNull_ShouldReturnFalse()
	{
		DateBuilder builder = 23.March(2024);

		bool result = builder.Equals(null);

		await That(result).IsFalse();
	}

	[Test]
	public async Task GetHashCode_ShouldBeEqualForEqualDates()
	{
		DateBuilder builder = 23.March(2024);

		int result = 23.March(2024).GetHashCode();

		await That(result).IsEqualTo(builder.GetHashCode());
	}

	[Test]
	public async Task GetHashCode_ShouldUseDateTimeHashCode()
	{
		DateBuilder builder = 23.March(2024);

		int result = builder.GetHashCode();

		await That(result).IsEqualTo(new DateTime(2024, 3, 23).GetHashCode());
	}

	[Test]
	[Arguments(22, 23, -1)]
	[Arguments(23, 23, 0)]
	[Arguments(24, 23, 1)]
	public async Task CompareTo_ShouldCompareDates(int leftDay, int rightDay, int expected)
	{
		DateBuilder left = leftDay.March(2024);
		DateBuilder right = rightDay.March(2024);

		int result = left.CompareTo(right);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(22, 23, false)]
	[Arguments(23, 23, true)]
	[Arguments(24, 23, false)]
	public async Task EqualityOperator_ShouldCompareDates(int leftDay, int rightDay, bool expected)
	{
		bool result = leftDay.March(2024) == rightDay.March(2024);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(22, 23, true)]
	[Arguments(23, 23, false)]
	[Arguments(24, 23, true)]
	public async Task InequalityOperator_ShouldCompareDates(int leftDay, int rightDay, bool expected)
	{
		bool result = leftDay.March(2024) != rightDay.March(2024);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(22, 23, true)]
	[Arguments(23, 23, false)]
	[Arguments(24, 23, false)]
	public async Task LessThanOperator_ShouldCompareDates(int leftDay, int rightDay, bool expected)
	{
		bool result = leftDay.March(2024) < rightDay.March(2024);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(22, 23, false)]
	[Arguments(23, 23, false)]
	[Arguments(24, 23, true)]
	public async Task GreaterThanOperator_ShouldCompareDates(int leftDay, int rightDay, bool expected)
	{
		bool result = leftDay.March(2024) > rightDay.March(2024);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(22, 23, true)]
	[Arguments(23, 23, true)]
	[Arguments(24, 23, false)]
	public async Task LessThanOrEqualOperator_ShouldCompareDates(int leftDay, int rightDay, bool expected)
	{
		bool result = leftDay.March(2024) <= rightDay.March(2024);

		await That(result).IsEqualTo(expected);
	}

	[Test]
	[Arguments(22, 23, false)]
	[Arguments(23, 23, true)]
	[Arguments(24, 23, true)]
	public async Task GreaterThanOrEqualOperator_ShouldCompareDates(int leftDay, int rightDay, bool expected)
	{
		bool result = leftDay.March(2024) >= rightDay.March(2024);

		await That(result).IsEqualTo(expected);
	}
}
