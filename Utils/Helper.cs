using System;
using System.Globalization;

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
            data = data.AddHours(-data.Hour);
            data = data.AddMinutes(-data.Minute);
            data = data.AddSeconds(-data.Second);
            data = data.AddMilliseconds(-data.Millisecond);

            var week1 = new DateTime(data.Year, 1, 1);

            var qtdMilisegundos1970ateData = GetTime(data);
            var qtdMs1970ate1janDoAnoDaData = GetTime(week1);
            var diffMsEntreDataEDia1janDoAnoDaData = qtdMilisegundos1970ateData - qtdMs1970ate1janDoAnoDaData;
            var qtdDiasDiferencaEntreDataEDia1JanDoAnoDaData = diffMsEntreDataEDia1janDoAnoDaData / 86400000;
            var diff2 = qtdDiasDiferencaEntreDataEDia1JanDoAnoDaData + 1;
            var diaDaSemanaDoDia1JanDoAnoDaData = (int)week1.DayOfWeek;

            var d6 = diaDaSemanaDoDia1JanDoAnoDaData + 6;
            var resto = d6 % 7;

            decimal calc = (diff2 + resto) / 7;

            int numero = 1 + (int)Math.Round(calc, 0);

            return numero;
        }

        public static string ConverterDataSqlite(DateTime? data)
        {
            if (data.HasValue)
                return data.Value.ToString("s", CultureInfo.CreateSpecificCulture("pt-BR")).Replace('T', ' ') + ".000";

            return "";
        }

        public static byte ConverteBoolSqlite(bool valor)
        {
            if (valor)
            {
                return 1;
            }

            return 0;
        }

        private static long GetTime(DateTime dia)
        {
            var time = (dia.ToUniversalTime() - new DateTime(1970, 1, 1));
            return (long)(time.TotalMilliseconds + 0.5);
        }
    }
}
