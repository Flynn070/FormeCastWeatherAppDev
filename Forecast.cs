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
        float screenTemperature;
        float maxScreenAirTemp;
        float minScreenAirTemp;
        //temp air needs to be cooled to in order to achieve 100% humidity (??)
        float screenDewPointTemperature;
        float feelsLikeTemperature;

        //wind
        float windSpeed10m;
        float windDirectionFrom10m;
        float windGustSpeed10m;
        float max10mWindGust;

        //humidity
        float visibility;
        float screenRelativeHumidity;

        //mean sea level pressure
        float mslp; 

        float uvIndex;

        // -1 to 30, different meanings for all
        int significantWeatherCode;

        //precipitation
        float precipitationRate;
        float totalPrecipAmount;
        float totalSnowAmount;
        float probOfPrecipitation;

        // contains definitions for all 30 codes, -1 will read correctly from the end of array :)
        string[] sigWeatherCodes = { "Clear night", "Sunny day", "Partly cloudy (night)", "Partly cloudy (day)", "Not Used", "Mist", "Fog", "Cloudy", "Overcast", "Light rain shower (night)", "Light rain shower (day)", "Drizzle", "Light rain", "Heavy rain shower (night)", "Heavy rain shower (day)", "Heavy rain", "Sleet shower (night)", "Sleet shower (day)", "Sleet", "Hail shower (night)", "Hail shower (day)", "Hail", "Light snow shower (night)", "Light snow shower (day)", "Light snow", "Heavy snow shower (night)", "Heavy snow shower (day)", "Heavy snow", "Thunder shower (night)", "Thunder shower (day)", "Thunder", "Trace rain"};
        string significantWeather = "";

        public void SetSignificantWeatherCode(int NewCode)
        {
            this.significantWeatherCode = NewCode;
            this.significantWeather = sigWeatherCodes[NewCode];     //gets the correct weather for the code
        }

        //TODO write setters and getters
    }

    
}
