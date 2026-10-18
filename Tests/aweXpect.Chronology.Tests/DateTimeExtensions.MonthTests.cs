namespace aweXpect.Chronology.Tests;

public sealed partial class DateTimeExtensions
{
	public sealed class MonthTests
	{
		[Test]
		public async Task January_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 01, 29);

			DateTime result = 29.January(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task January_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 01, 29);

			DateOnly result = 29.January(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task February_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 02, 28);

			DateTime result = 28.February(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task February_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 02, 28);

			DateOnly result = 28.February(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task March_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 03, 27);

			DateTime result = 27.March(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task March_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 03, 27);

			DateOnly result = 27.March(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task April_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 04, 26);

			DateTime result = 26.April(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task April_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 04, 26);

			DateOnly result = 26.April(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task May_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 05, 25);

			DateTime result = 25.May(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task May_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 05, 25);

			DateOnly result = 25.May(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task June_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 06, 24);

			DateTime result = 24.June(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task June_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 06, 24);

			DateOnly result = 24.June(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task July_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 07, 23);

			DateTime result = 23.July(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task July_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 07, 23);

			DateOnly result = 23.July(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task August_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 08, 22);

			DateTime result = 22.August(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task August_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 08, 22);

			DateOnly result = 22.August(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task September_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 09, 21);

			DateTime result = 21.September(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task September_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 09, 21);

			DateOnly result = 21.September(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task October_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 10, 20);

			DateTime result = 20.October(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task October_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 10, 20);

			DateOnly result = 20.October(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task November_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 11, 19);

			DateTime result = 19.November(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task November_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 11, 19);

			DateOnly result = 19.November(2024);

			await That(result).IsEqualTo(expected);
		}
#endif

		[Test]
		public async Task December_ShouldReturnCorrectDateTime()
		{
			DateTime expected = new(2024, 12, 18);

			DateTime result = 18.December(2024);

			await That(result).IsEqualTo(expected);
		}

#if NET8_0_OR_GREATER
		[Test]
		public async Task December_ShouldReturnCorrectDateOnly()
		{
			DateOnly expected = new(2024, 12, 18);

			DateOnly result = 18.December(2024);

			await That(result).IsEqualTo(expected);
		}
#endif
	}
}
