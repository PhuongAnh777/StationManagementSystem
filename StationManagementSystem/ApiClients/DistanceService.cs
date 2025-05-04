using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace StationManagementSystem.ApiClients
{
    // OSRM API
    public class DistanceService
    {
        public async Task<(double distanceKm, double durationHours)> CalculateDistanceAsync(
        double originLat, double originLng,
        double destLat, double destLng)
        {
            string url = $"http://router.project-osrm.org/route/v1/driving/{originLng},{originLat};{destLng},{destLat}?overview=false";

            using HttpClient client = new HttpClient();
            string response = await client.GetStringAsync(url);
            JObject data = JObject.Parse(response);

            if (data["routes"] != null && data["routes"].HasValues)
            {
                double distanceMeters = data["routes"][0]["distance"].Value<double>();
                double durationSeconds = data["routes"][0]["duration"].Value<double>();

                double distanceKm = distanceMeters / 1000.0;
                double durationHours = durationSeconds / 3600.0;

                return (distanceKm, durationHours);
            }

            throw new Exception("Không lấy được dữ liệu khoảng cách.");
        }
    }
}
