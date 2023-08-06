using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace BL.BLImplementation
{
    public class GoogleMapsApiClient
    {
        private const string ApiBaseUrl = "https://maps.googleapis.com/maps/api/geocode/json";
        private readonly HttpClient _httpClient;

        public GoogleMapsApiClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<(double latitude, double longitude)> GeocodeAddress(string address)
        {
            string apiKey = "AIzaSyC-WLL34cv-nSfp-ImPs_DpC5mQ8BRq-P0"; // Replace with your Google Maps API key

            string encodedAddress = Uri.EscapeDataString(address);
            string requestUrl = $"{ApiBaseUrl}?address={encodedAddress}&key={apiKey}";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);
            string json = await response.Content.ReadAsStringAsync();

            // Deserialize the JSON response
            var geocodeResponse = JsonConvert.DeserializeObject<GoogleMapsGeocodeResponse>(json);

            // Extract the latitude and longitude
            double latitude = geocodeResponse.Results[0].Geometry.Location.Latitude;
            double longitude = geocodeResponse.Results[0].Geometry.Location.Longitude;

            return (latitude, longitude);
        }
    }
}



public class GoogleMapsGeocodeResponse
{
    [JsonProperty("results")]
    public GoogleMapsGeocodeResult[] Results { get; set; }
}

public class GoogleMapsGeocodeResult
{
    [JsonProperty("geometry")]
    public GoogleMapsGeocodeGeometry Geometry { get; set; }
}

public class GoogleMapsGeocodeGeometry
{
    [JsonProperty("location")]
    public GoogleMapsGeocodeLocation Location { get; set; }
}

public class GoogleMapsGeocodeLocation
{
    [JsonProperty("lat")]
    public double Latitude { get; set; }

    [JsonProperty("lng")]
    public double Longitude { get; set; }
}

//using System;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Net.Http.Formatting;

//public class GoogleMapsService
//{
//    private readonly HttpClient _httpClient;
//    private const string DistanceMatrixEndpoint = "https://maps.googleapis.com/maps/api/distancematrix/json";

//    public GoogleMapsService()
//    {
//        _httpClient = new HttpClient();
//    }

//    public async Task<double> GetDistanceBetweenCities(string originCity, string destinationCity)
//    {
//        // Replace 'YOUR_API_KEY' with your actual Google Maps API key
//        string apiKey = "AIzaSyC-WLL34cv-nSfp-ImPs_DpC5mQ8BRq-P0";
//        string requestUrl = $"{DistanceMatrixEndpoint}?origins={originCity}&destinations={destinationCity}&key={apiKey}";

//        HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

//        if (response.IsSuccessStatusCode)
//        {
//            var data = await response.Content.ReadAsAsync<DistanceMatrixResponse>();
//            double distance = data.Rows[0].Elements[0].Distance.Value;
//            return distance;
//        }

//        throw new Exception("Failed to retrieve distance data from Google Maps API.");
//    }
//}

//public class DistanceMatrixResponse
//{
//    public DistanceMatrixRow[] Rows { get; set; }
//}

//public class DistanceMatrixRow
//{
//    public DistanceMatrixElement[] Elements { get; set; }
//}

//public class DistanceMatrixElement
//{
//    public Distance Distance { get; set; }
//}

//public class Distance
//{
//    public double Value { get; set; }
//}