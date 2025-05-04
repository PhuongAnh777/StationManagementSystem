using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace StationManagementSystem.ApiClients
{
    // geocoding Nominatim (OpenStreetMap).
    public class GeocodingService
    {
        public async Task<(double lat, double lon)?> GetCoordinatesAsync(string placeName)
        {
            string url = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(placeName)}&format=json&limit=1";

            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("User-Agent", "YourAppName");

            string response = await client.GetStringAsync(url);
            JArray data = JArray.Parse(response);

            if (data.Count > 0)
            {
                double lat = double.Parse(data[0]["lat"].ToString());
                double lon = double.Parse(data[0]["lon"].ToString());
                return (lat, lon);
            }

            return null;
        }
    }
}
