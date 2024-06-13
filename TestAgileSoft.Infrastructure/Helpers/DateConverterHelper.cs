namespace TestAgileSoft.Infrastructure.Helpers
{
    public static class DateConverterHelper
    {
        public static DateTime ConvertDateTimeToLocalZone(
            this DateTime creationDate,
            string localZoneId = "SA Pacific Standard Time"
        )
        {
            TimeZoneInfo localZone = TimeZoneInfo.FindSystemTimeZoneById(localZoneId);

            return TimeZoneInfo.ConvertTime(creationDate, localZone);
        }
    }
}
