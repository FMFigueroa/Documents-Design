using System.Collections.Generic;
using System.Text.Json;

namespace AirQualityCdk.Config
{
    public class City : Latincoder.AirQuality.Model.Config.City { }

    public class AirQualityLambdaOptions
    {
        public string Name { get; set; }
        public string Handler { get; set; }
        public List<KeyValuePair<string, string>> EnvironmentVariables { get; set; } = new List<KeyValuePair<string, string>>();

        /// <summary>
        /// Cities are property required for WaqiCityFeedLambda as URIs will
        /// be from it's values
        /// /// </summary>
        /// <value>List of City to support</value>
        public List<City> Cities { get; set; } = new List<City>(); // defaults to empty list
    }

    public static class EnvCitiesWithStations {
        public readonly static string EnvironmentKey = Constants.EnvCitiesWaqiGetCityFeedLambda;

        public static string GetValueFromCities(List<City> cities) {
            return JsonSerializer.Serialize(cities);
        }
    }
}
