using System;

namespace Utils
{
    public static class Helper
    {
        public static string RetonarDiaDaSemana(DateTime dateTime)
        {
            switch (dateTime.DayOfWeek.ToString().ToLowerInvariant())
            {
                case "sunday":
                    return "dom";
                case "monday":
                    return "seg";
                case "tuesday":
                    return "ter";
                case "wednesday":
                    return "qua";
                case "thursday":
                    return "qui";
                case "friday":
                    return "sex";
                case "saturday":
                    return "sab";
                default:
                    return "";
            }
        }
    }
}
