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

        public static int ObterNumeroDaSemana(DateTime data)
        {
            data.AddHours(-data.Hour);
            data.AddMinutes(-data.Minute);
            data.AddSeconds(-data.Second);
            data.AddMilliseconds(-data.Millisecond);

            var dateGetDate = data.Day;
            var dateGetDay = (int)data.DayOfWeek;
            var temp = dateGetDate + 3 - (dateGetDay + 6) % 7;
            data = data.AddDays(-data.Day);
            data = data.AddDays(temp);

            var week1 = new DateTime(data.Year, 1, 4);

            var dateGetTime = GetTime(data);
            var week1GetTime = GetTime(week1);
            var diff1 = dateGetTime - week1GetTime;
            var div1 = diff1 / 86400000;
            var diff2 = div1 - 3;
            var week1GetDay = (int)week1.DayOfWeek;

            decimal calc = (diff2 + (week1GetDay + 6) % 7) / 7;

            int numero = 1 + (int)Math.Round(calc, 0);

            return numero;
        }

        private static long GetTime(DateTime dia)
        {
            var time = (dia.ToUniversalTime() - new DateTime(1970, 1, 1));
            return (long)(time.TotalMilliseconds + 0.5);
        }
    }
}
