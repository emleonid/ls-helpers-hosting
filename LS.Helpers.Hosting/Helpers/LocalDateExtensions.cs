namespace LS.Helpers.Hosting.Helpers
{
    using Consts;
    using JetBrains.Annotations;
    using NodaTime;

    /// <summary>
    /// NodaTime LocalDate Extensions
    /// </summary>
    [UsedImplicitly]
    public static class NodaTimeHelpers
    {
        /// <summary>
        /// Gets the kyiv today local date now.
        /// </summary>
        /// <returns></returns>
        public static LocalDate GetKyivToday()
        {
            var instant = SystemClock.Instance.GetCurrentInstant();
            var dateTimeZone = DateTimeZoneProviders.Tzdb[DateTimeConsts.TimeZone.Kyiv];
            var localDate = instant.InZone(dateTimeZone).Date;
            return localDate;
        }
    }
}
