namespace LS.Helpers.Hosting.Extensions.NodaTime
{
    using Consts;
    using global::NodaTime;
    using JetBrains.Annotations;

    /// <summary>
    /// NodaTime LocalDate Extensions
    /// </summary>
    [UsedImplicitly]
    public static class LocalDateExtensions
    {
        /// <summary>
        /// Gets the kyiv today local date now.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static LocalDate GetKyivToday(this LocalDate date)
        {
            var instant = SystemClock.Instance.GetCurrentInstant();
            var dateTimeZone = DateTimeZoneProviders.Tzdb[DateTimeConsts.TimeZone.Kyiv];
            var localDate = instant.InZone(dateTimeZone).Date;

            return localDate;
        }
    }
}
