namespace aweXpect.Chronology.Tests;

public sealed partial class DateTimeExtensions
{
	public sealed class AsTests
	{
		[Test]
		public async Task AsUtc_FromBuilder_ShouldSetKindToUtc()
		{
			DateTime result = 24.December(2024).At(18, 30).AsUtc();

			await That(result).HasKind().EqualTo(DateTimeKind.Utc);
		}

		[Test]
		public async Task AsUtc_FromDateTime_ShouldSetKindToUtc()
		{
			DateTime dateTime = 24.December(2024).At(18, 30);

			DateTime result = dateTime.AsUtc();

			await That(result).HasKind().EqualTo(DateTimeKind.Utc);
		}

		[Test]
		public async Task AsLocal_FromBuilder_ShouldSetKindToLocal()
		{
			DateTime result = 24.December(2024).At(18, 30).AsLocal();

			await That(result).HasKind().EqualTo(DateTimeKind.Local);
		}

		[Test]
		public async Task AsLocal_FromDateTime_ShouldSetKindToLocal()
		{
			DateTime dateTime = 24.December(2024).At(18, 30);

			DateTime result = dateTime.AsLocal();

			await That(result).HasKind().EqualTo(DateTimeKind.Local);
		}
	}
}
