using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace FormeCastWeatherApp
{
    class Forecast
    {
        private string time = "";

        //various temps
        private float screenTemperature;
        private float maxScreenAirTemp;
        private float minScreenAirTemp;
        //temp air needs to be cooled to in order to achieve 100% humidity (??)
        private float screenDewPointTemperature;
        private float feelsLikeTemperature;

        //wind
        private float windSpeed10m;
        private float windDirectionFrom10m;
        private float windGustSpeed10m;
        private float max10mWindGust;

        //humidity
        private float visibility;
        private float screenRelativeHumidity;

        //mean sea level pressure
        private float mslp;

        private int uvIndex;

        // -1 to 30, different meanings for all
        private int significantWeatherCode;

        //precipitation
        private float precipitationRate;
        private float totalPrecipAmount;
        private float totalSnowAmount;
        private float probOfPrecipitation;

        // contains definitions for all 30 codes, -1 will read correctly from the end of array :)
        private string[] sigWeatherCodes = { "Clear night", "Sunny day", "Partly cloudy (night)", "Partly cloudy (day)", "Not Used", "Mist", "Fog", "Cloudy", "Overcast", "Light rain shower (night)", "Light rain shower (day)", "Drizzle", "Light rain", "Heavy rain shower (night)", "Heavy rain shower (day)", "Heavy rain", "Sleet shower (night)", "Sleet shower (day)", "Sleet", "Hail shower (night)", "Hail shower (day)", "Hail", "Light snow shower (night)", "Light snow shower (day)", "Light snow", "Heavy snow shower (night)", "Heavy snow shower (day)", "Heavy snow", "Thunder shower (night)", "Thunder shower (day)", "Thunder", "Trace rain"};
        private string significantWeather = "";

        private string uvIndexAdvice = "";


        public void SetSignificantWeatherCode(int NewCode)
        {
            this.significantWeatherCode = NewCode;
            this.significantWeather = sigWeatherCodes[NewCode];     //gets the correct weather for the code
        }

        public void SetUVIndex(int NewIndex)
        {
            this.uvIndex = NewIndex;
            if (NewIndex <= 3)
            {
                this.uvIndexAdvice = "Low exposure. No protection required. You can safely stay outside";
            }
            else if (NewIndex <= 5)
            {
                this.uvIndexAdvice = "Moderate exposure. Seek shade during midday hours, cover up and wear sunscreen";
            }
            else if (NewIndex <= 7)
            {
                this.uvIndexAdvice = "High exposure. Seek shade during midday hours, cover up and wear sunscreen";
            }
            else if (NewIndex <= 10)
            {
                this.uvIndexAdvice = "Very high. Avoid being outside during midday hours. Shirt, sunscreen and hat are essential";
            }
            else
            {
                this.uvIndexAdvice = "Extreme. Avoid being outside during midday hours. Shirt, sunscreen and hat essential.";
            }
        }

        //TODO write setters and getters
    }

    
}
