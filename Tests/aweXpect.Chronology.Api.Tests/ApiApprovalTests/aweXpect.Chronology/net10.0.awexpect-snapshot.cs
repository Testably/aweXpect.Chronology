[assembly: System.Reflection.AssemblyMetadata("RepositoryUrl", "https://github.com/Testably/aweXpect.Chronology.git")]
[assembly: System.Runtime.Versioning.TargetFramework(".NETCoreApp,Version=v10.0", FrameworkDisplayName = ".NET 10.0")]
namespace aweXpect.Chronology
{
    public readonly struct DateBuilder
    {
        public DateBuilder(System.DateTime value) { }
        public override string ToString() { }
        public static aweXpect.Chronology.DateBuilder operator +(aweXpect.Chronology.DateBuilder builder, System.TimeSpan time) { }
        public static implicit operator System.DateOnly(aweXpect.Chronology.DateBuilder builder) { }
        public static implicit operator System.DateTime(aweXpect.Chronology.DateBuilder builder) { }
        public static aweXpect.Chronology.DateBuilder operator -(aweXpect.Chronology.DateBuilder builder, System.TimeSpan time) { }
    }
    public readonly struct DateTimeBuilder
    {
        public DateTimeBuilder(System.DateTime value) { }
        public override string ToString() { }
        public static aweXpect.Chronology.DateTimeBuilder operator +(aweXpect.Chronology.DateTimeBuilder builder, System.TimeSpan time) { }
        public static implicit operator System.DateOnly(aweXpect.Chronology.DateTimeBuilder builder) { }
        public static implicit operator System.DateTime(aweXpect.Chronology.DateTimeBuilder builder) { }
        public static implicit operator System.TimeOnly(aweXpect.Chronology.DateTimeBuilder builder) { }
        public static aweXpect.Chronology.DateTimeBuilder operator -(aweXpect.Chronology.DateTimeBuilder builder, System.TimeSpan time) { }
    }
    public static class DateTimeExtensions
    {
        public static System.DateTime After(this System.TimeSpan timeDifference, System.DateTime dateTime) { }
        public static System.DateTime After(this aweXpect.Chronology.TimeSpanBuilder timeDifference, System.DateTime dateTime) { }
        public static aweXpect.Chronology.DateBuilder After(this System.TimeSpan timeDifference, aweXpect.Chronology.DateBuilder dateTime) { }
        public static aweXpect.Chronology.DateBuilder After(this aweXpect.Chronology.TimeSpanBuilder timeDifference, aweXpect.Chronology.DateBuilder dateTime) { }
        public static aweXpect.Chronology.DateBuilder April(this int day, int year) { }
        public static System.DateTime AsLocal(this System.DateTime dateTime) { }
        public static aweXpect.Chronology.DateTimeBuilder AsLocal(this aweXpect.Chronology.DateTimeBuilder dateTime) { }
        public static System.DateTime AsUtc(this System.DateTime dateTime) { }
        public static aweXpect.Chronology.DateTimeBuilder AsUtc(this aweXpect.Chronology.DateTimeBuilder dateTime) { }
        public static System.DateTime At(this System.DateOnly date, System.TimeSpan time) { }
        public static System.DateTime At(this System.DateOnly date, int hours, int minutes, int seconds = 0, int milliseconds = 0) { }
        public static System.DateTime At(this System.DateTime date, System.TimeSpan time) { }
        public static System.DateTime At(this System.DateTime date, int hours, int minutes, int seconds = 0, int milliseconds = 0) { }
        public static aweXpect.Chronology.DateTimeBuilder At(this aweXpect.Chronology.DateBuilder date, System.TimeSpan time) { }
        public static aweXpect.Chronology.DateTimeBuilder At(this aweXpect.Chronology.DateBuilder date, int hours, int minutes, int seconds = 0, int milliseconds = 0) { }
        public static aweXpect.Chronology.DateBuilder August(this int day, int year) { }
        public static System.DateTime Before(this System.TimeSpan timeDifference, System.DateTime dateTime) { }
        public static System.DateTime Before(this aweXpect.Chronology.TimeSpanBuilder timeDifference, System.DateTime dateTime) { }
        public static aweXpect.Chronology.DateBuilder Before(this System.TimeSpan timeDifference, aweXpect.Chronology.DateBuilder dateTime) { }
        public static aweXpect.Chronology.DateBuilder Before(this aweXpect.Chronology.TimeSpanBuilder timeDifference, aweXpect.Chronology.DateBuilder dateTime) { }
        public static aweXpect.Chronology.DateBuilder December(this int day, int year) { }
        public static aweXpect.Chronology.DateBuilder February(this int day, int year) { }
        public static aweXpect.Chronology.DateBuilder January(this int day, int year) { }
        public static aweXpect.Chronology.DateBuilder July(this int day, int year) { }
        public static aweXpect.Chronology.DateBuilder June(this int day, int year) { }
        public static aweXpect.Chronology.DateBuilder March(this int day, int year) { }
        public static aweXpect.Chronology.DateBuilder May(this int day, int year) { }
        public static aweXpect.Chronology.DateBuilder November(this int day, int year) { }
        public static aweXpect.Chronology.DateBuilder October(this int day, int year) { }
        public static aweXpect.Chronology.DateBuilder September(this int day, int year) { }
    }
    public readonly struct DateTimeOffsetBuilder
    {
        public DateTimeOffsetBuilder(System.DateTimeOffset value) { }
        public override string ToString() { }
        public static aweXpect.Chronology.DateTimeOffsetBuilder operator +(aweXpect.Chronology.DateTimeOffsetBuilder builder, System.TimeSpan time) { }
        public static implicit operator System.DateOnly(aweXpect.Chronology.DateTimeOffsetBuilder builder) { }
        public static implicit operator System.DateTime(aweXpect.Chronology.DateTimeOffsetBuilder builder) { }
        public static implicit operator System.DateTimeOffset(aweXpect.Chronology.DateTimeOffsetBuilder builder) { }
        public static implicit operator System.TimeOnly(aweXpect.Chronology.DateTimeOffsetBuilder builder) { }
        public static aweXpect.Chronology.DateTimeOffsetBuilder operator -(aweXpect.Chronology.DateTimeOffsetBuilder builder, System.TimeSpan time) { }
    }
    public static class DateTimeOffsetExtensions
    {
        public static System.DateTimeOffset After(this System.TimeSpan timeDifference, System.DateTimeOffset dateTime) { }
        public static System.DateTimeOffset After(this aweXpect.Chronology.TimeSpanBuilder timeDifference, System.DateTimeOffset dateTime) { }
        public static aweXpect.Chronology.DateTimeOffsetBuilder After(this System.TimeSpan timeDifference, aweXpect.Chronology.DateTimeOffsetBuilder dateTime) { }
        public static aweXpect.Chronology.DateTimeOffsetBuilder After(this aweXpect.Chronology.TimeSpanBuilder timeDifference, aweXpect.Chronology.DateTimeOffsetBuilder dateTime) { }
        public static System.DateTimeOffset Before(this System.TimeSpan timeDifference, System.DateTimeOffset dateTime) { }
        public static System.DateTimeOffset Before(this aweXpect.Chronology.TimeSpanBuilder timeDifference, System.DateTimeOffset dateTime) { }
        public static aweXpect.Chronology.DateTimeOffsetBuilder Before(this System.TimeSpan timeDifference, aweXpect.Chronology.DateTimeOffsetBuilder dateTime) { }
        public static aweXpect.Chronology.DateTimeOffsetBuilder Before(this aweXpect.Chronology.TimeSpanBuilder timeDifference, aweXpect.Chronology.DateTimeOffsetBuilder dateTime) { }
        public static aweXpect.Chronology.DateTimeOffsetBuilder WithOffset(this System.DateTime dateTime, System.TimeSpan offset) { }
        public static aweXpect.Chronology.DateTimeOffsetBuilder WithOffset(this aweXpect.Chronology.DateBuilder dateTime, System.TimeSpan offset) { }
        public static aweXpect.Chronology.DateTimeOffsetBuilder WithOffset(this aweXpect.Chronology.DateTimeBuilder dateTime, System.TimeSpan offset) { }
    }
    public readonly struct TimeSpanBuilder : System.IComparable<aweXpect.Chronology.TimeSpanBuilder>, System.IEquatable<aweXpect.Chronology.TimeSpanBuilder>
    {
        public TimeSpanBuilder(System.TimeSpan value) { }
        public int CompareTo(aweXpect.Chronology.TimeSpanBuilder other) { }
        public bool Equals(aweXpect.Chronology.TimeSpanBuilder other) { }
        public override bool Equals(object? obj) { }
        public override int GetHashCode() { }
        public override string ToString() { }
        public static aweXpect.Chronology.TimeSpanBuilder operator +(aweXpect.Chronology.TimeSpanBuilder builder, System.TimeSpan time) { }
        public static aweXpect.Chronology.TimeSpanBuilder operator /(aweXpect.Chronology.TimeSpanBuilder builder, double divisor) { }
        public static bool operator ==(aweXpect.Chronology.TimeSpanBuilder left, aweXpect.Chronology.TimeSpanBuilder right) { }
        public static bool operator >(aweXpect.Chronology.TimeSpanBuilder left, aweXpect.Chronology.TimeSpanBuilder right) { }
        public static bool operator >=(aweXpect.Chronology.TimeSpanBuilder left, aweXpect.Chronology.TimeSpanBuilder right) { }
        public static implicit operator System.TimeOnly(aweXpect.Chronology.TimeSpanBuilder builder) { }
        public static implicit operator System.TimeSpan(aweXpect.Chronology.TimeSpanBuilder builder) { }
        public static bool operator !=(aweXpect.Chronology.TimeSpanBuilder left, aweXpect.Chronology.TimeSpanBuilder right) { }
        public static bool operator <(aweXpect.Chronology.TimeSpanBuilder left, aweXpect.Chronology.TimeSpanBuilder right) { }
        public static bool operator <=(aweXpect.Chronology.TimeSpanBuilder left, aweXpect.Chronology.TimeSpanBuilder right) { }
        public static aweXpect.Chronology.TimeSpanBuilder operator *(aweXpect.Chronology.TimeSpanBuilder builder, double multiplier) { }
        public static aweXpect.Chronology.TimeSpanBuilder operator *(double multiplier, aweXpect.Chronology.TimeSpanBuilder builder) { }
        public static aweXpect.Chronology.TimeSpanBuilder operator -(aweXpect.Chronology.TimeSpanBuilder builder, System.TimeSpan time) { }
        public static aweXpect.Chronology.TimeSpanBuilder operator -(aweXpect.Chronology.TimeSpanBuilder instance) { }
    }
    public static class TimeSpanBuilderExtensions
    {
        public static aweXpect.Chronology.TimeSpanBuilder Days(this double days) { }
        public static aweXpect.Chronology.TimeSpanBuilder Days(this double days, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Days(this int days) { }
        public static aweXpect.Chronology.TimeSpanBuilder Days(this int days, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Hours(this double hours) { }
        public static aweXpect.Chronology.TimeSpanBuilder Hours(this double hours, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Hours(this int hours) { }
        public static aweXpect.Chronology.TimeSpanBuilder Hours(this int hours, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Microseconds(this double microseconds) { }
        public static aweXpect.Chronology.TimeSpanBuilder Microseconds(this double microseconds, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Microseconds(this int microseconds) { }
        public static aweXpect.Chronology.TimeSpanBuilder Microseconds(this int microseconds, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Milliseconds(this double milliseconds) { }
        public static aweXpect.Chronology.TimeSpanBuilder Milliseconds(this double milliseconds, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Milliseconds(this int milliseconds) { }
        public static aweXpect.Chronology.TimeSpanBuilder Milliseconds(this int milliseconds, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Minutes(this double minutes) { }
        public static aweXpect.Chronology.TimeSpanBuilder Minutes(this double minutes, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Minutes(this int minutes) { }
        public static aweXpect.Chronology.TimeSpanBuilder Minutes(this int minutes, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Seconds(this double seconds) { }
        public static aweXpect.Chronology.TimeSpanBuilder Seconds(this double seconds, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Seconds(this int seconds) { }
        public static aweXpect.Chronology.TimeSpanBuilder Seconds(this int seconds, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Ticks(this int ticks) { }
        public static aweXpect.Chronology.TimeSpanBuilder Ticks(this int ticks, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Ticks(this long ticks) { }
        public static aweXpect.Chronology.TimeSpanBuilder Ticks(this long ticks, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Weeks(this double weeks) { }
        public static aweXpect.Chronology.TimeSpanBuilder Weeks(this double weeks, System.TimeSpan offset) { }
        public static aweXpect.Chronology.TimeSpanBuilder Weeks(this int weeks) { }
        public static aweXpect.Chronology.TimeSpanBuilder Weeks(this int weeks, System.TimeSpan offset) { }
    }
}

