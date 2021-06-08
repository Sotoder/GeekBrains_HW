using System;
using System.Net;

namespace WeatherParser
{
    class WeatherData
    {
        string town;
        DateTime day;
        int pressureMin;
        int pressureMax;
        int temperatureMin;
        int temperatureMax;
        int windForceMin;
        int windForceMax;

        public string Town { get => WebUtility.UrlDecode(town); set { town = value; } }
        public string Day { get => day.ToString("dd MMMM yyг. HHч."); set => day = Convert.ToDateTime(value); }
        public string PressureMin { get => pressureMin.ToString(); set => pressureMin = CheckAndSetParam(value, "pressureMin"); }
        public string PressureMax { get => pressureMax.ToString(); set => pressureMax = CheckAndSetParam(value, "pressureMax"); }
        public string TemperatureMin { get => temperatureMin.ToString(); set => temperatureMin = CheckAndSetParam(value, "temperatureMin"); }
        public string TemperatureMax { get => temperatureMax.ToString(); set => temperatureMax = CheckAndSetParam(value, "temperatureMax"); }
        public string WindForceMin { get => windForceMin.ToString(); set => windForceMin = CheckAndSetParam(value, "windForceMim"); }
        public string WindForceMax { get => windForceMax.ToString(); set => windForceMax = CheckAndSetParam(value, "windForceMax"); }

        private int CheckAndSetParam(string strFromXML, string paramName)
        {
            int checkedInt;

            if (int.TryParse(strFromXML, out checkedInt)) return checkedInt;
            else
            {
                return 0;
                //parser.SendErrorMsg(paramName);
            }
        }
    }
}
