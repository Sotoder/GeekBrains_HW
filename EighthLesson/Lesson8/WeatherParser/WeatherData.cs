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
        public DateTime Day { get => day; set => day = value; }
        public string PressureMin { get => $"{pressureMin.ToString()} мм. рт. ст."; set => pressureMin = CheckAndSetParam(value, "pressureMin"); }
        public string PressureMax { get => $"{pressureMax.ToString()} мм. рт. ст."; set => pressureMax = CheckAndSetParam(value, "pressureMax"); }
        public string TemperatureMin { get => $"{temperatureMin.ToString()}℃"; set => temperatureMin = CheckAndSetParam(value, "temperatureMin"); }
        public string TemperatureMax { get => $"{temperatureMax.ToString()}℃"; set => temperatureMax = CheckAndSetParam(value, "temperatureMax"); }
        public string WindForceMin { get => $"{windForceMin.ToString()} м/с"; set => windForceMin = CheckAndSetParam(value, "windForceMim"); }
        public string WindForceMax { get => $"{windForceMax.ToString()} м/с"; set => windForceMax = CheckAndSetParam(value, "windForceMax"); }

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
