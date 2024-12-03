using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormeCastWeatherApp
{
    public record GeoJson
    {
        // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
        public record Feature(
     string type,
     Geometry geometry,
     Properties properties
        );

        public record FeelsLikeTemperature(
     string type,
     string description,
     Unit unit
        );

        public record Geometry(
     string type,
     IReadOnlyList<double> coordinates
        );

        public record Location(
     string name
        );

        public record Max10mWindGust(
     string type,
     string description,
     Unit unit
        );

        public record MaxScreenAirTemp(
     string type,
     string description,
     Unit unit
        );

        public record MinScreenAirTemp(
     string type,
     string description,
     Unit unit
        );

        public record Mslp(
     string type,
     string description,
     Unit unit
        );

        public record Parameter(
     TotalSnowAmount totalSnowAmount,
     ScreenTemperature screenTemperature,
     Visibility visibility,
     WindDirectionFrom10m windDirectionFrom10m,
     PrecipitationRate precipitationRate,
     MaxScreenAirTemp maxScreenAirTemp,
     FeelsLikeTemperature feelsLikeTemperature,
     ScreenDewPointTemperature screenDewPointTemperature,
     ScreenRelativeHumidity screenRelativeHumidity,
     WindSpeed10m windSpeed10m,
     ProbOfPrecipitation probOfPrecipitation,
     Max10mWindGust max10mWindGust,
     SignificantWeatherCode significantWeatherCode,
     MinScreenAirTemp minScreenAirTemp,
     TotalPrecipAmount totalPrecipAmount,
     Mslp mslp,
     WindGustSpeed10m windGustSpeed10m,
     UvIndex uvIndex
        );

        public record PrecipitationRate(
     string type,
     string description,
     Unit unit
        );

        public record ProbOfPrecipitation(
     string type,
     string description,
     Unit unit
        );

        public record Properties(
     Location location,
     double requestPointDistance,
     string modelRunDate,
     IReadOnlyList<TimeSeries> timeSeries
        );

        public record Root(
     IReadOnlyList<Feature> features,
     IReadOnlyList<Parameter> parameters,
     string type
        );

        public record ScreenDewPointTemperature(
     string type,
     string description,
     Unit unit
        );

        public record ScreenRelativeHumidity(
     string type,
     string description,
     Unit unit
        );

        public record ScreenTemperature(
     string type,
     string description,
     Unit unit
        );

        public record SignificantWeatherCode(
     string type,
     string description,
     Unit unit
        );

        public record Symbol(
     string value,
     string type
        );

        public record TimeSeries(
     string time,
     double screenTemperature,
     double maxScreenAirTemp,
     double minScreenAirTemp,
     double screenDewPointTemperature,
     double feelsLikeTemperature,
     double windSpeed10m,
     int windDirectionFrom10m,
     double windGustSpeed10m,
     double max10mWindGust,
     int visibility,
     double screenRelativeHumidity,
     int mslp,
     int uvIndex,
     int significantWeatherCode,
     int precipitationRate,
     int totalPrecipAmount,
     int totalSnowAmount,
     int probOfPrecipitation
        );

        public record TotalPrecipAmount(
     string type,
     string description,
     Unit unit
        );

        public record TotalSnowAmount(
     string type,
     string description,
     Unit unit
        );

        public record Unit(
     string label,
     Symbol symbol
        );

        public record UvIndex(
     string type,
     string description,
     Unit unit
        );

        public record Visibility(
     string type,
     string description,
     Unit unit
        );

        public record WindDirectionFrom10m(
     string type,
     string description,
     Unit unit
        );

        public record WindGustSpeed10m(
     string type,
     string description,
     Unit unit
        );

        public record WindSpeed10m(
     string type,
     string description,
     Unit unit
        );


    }
}
