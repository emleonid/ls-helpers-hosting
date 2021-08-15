namespace LS.Helpers.Hosting.Extensions
{
    using System;
    using JetBrains.Annotations;

    /// <summary>
    /// DateTimeExtensions
    /// </summary>
    [UsedImplicitly]
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Converts to day start.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDayStart(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }

        /// <summary>
        /// Converts to day end.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDayEnd(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
        }

        /// <summary>
        /// Determines whether [is today date] [the specified date].
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if [is today date] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsTodayDate(this DateTime date)
        {
            var dateFrom = DateTime.UtcNow.ToDayStart();
            var dateTo = DateTime.UtcNow.ToDayEnd();

            if (date >= dateFrom && date <= dateTo)
            {
                return true;
            }

            return false;
        }
    }
}
