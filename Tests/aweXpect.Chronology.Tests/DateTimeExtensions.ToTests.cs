namespace aweXpect.Chronology.Tests;

public sealed partial class DateTimeExtensions
{
	public sealed class ToTests
	{
		[Test]
		[Arguments(DateTimeKind.Utc)]
		[Arguments(DateTimeKind.Local)]
		[Arguments(DateTimeKind.Unspecified)]
		public async Task ToLocalTime_ShouldConvertLikeDateTime(DateTimeKind kind)
		{
			DateTime expected = DateTime.SpecifyKind(new DateTime(2024, 12, 24, 18, 30, 0), kind).ToLocalTime();

			DateTime result = new DateTimeBuilder(DateTime.SpecifyKind(new DateTime(2024, 12, 24, 18, 30, 0), kind))
				.ToLocalTime();

			await That(result).IsEqualTo(expected);
			await That(result).HasKind().EqualTo(DateTimeKind.Local);
		}

		[Test]
		[Arguments(DateTimeKind.Utc)]
		[Arguments(DateTimeKind.Local)]
		[Arguments(DateTimeKind.Unspecified)]
		public async Task ToUniversalTime_ShouldConvertLikeDateTime(DateTimeKind kind)
		{
			DateTime expected = DateTime.SpecifyKind(new DateTime(2024, 12, 24, 18, 30, 0), kind).ToUniversalTime();

			DateTime result = new DateTimeBuilder(DateTime.SpecifyKind(new DateTime(2024, 12, 24, 18, 30, 0), kind))
				.ToUniversalTime();

			await That(result).IsEqualTo(expected);
			await That(result).HasKind().EqualTo(DateTimeKind.Utc);
		}

		[Test]
		public async Task ToLocalTime_AfterAsUtc_ShouldMatchConvertedUtcValue()
		{
			DateTime expected = new DateTime(1601, 1, 1, 0, 0, 0, DateTimeKind.Utc).ToLocalTime();

			DateTime result = 1.January(1601).At(0, 0).AsUtc().ToLocalTime();

			await That(result).IsEqualTo(expected);
		}

		[Test]
		public async Task ToUniversalTime_AfterAsLocal_ShouldMatchConvertedLocalValue()
		{
			DateTime expected = new DateTime(2024, 12, 24, 18, 30, 0, DateTimeKind.Local).ToUniversalTime();

			DateTime result = 24.December(2024).At(18, 30).AsLocal().ToUniversalTime();

			await That(result).IsEqualTo(expected);
		}
	}
}
