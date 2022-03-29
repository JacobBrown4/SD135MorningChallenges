using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BoredAPI
{
    public class BoredService
    {
        private readonly HttpClient _httpClient = new HttpClient();

        public async Task<Event> GetRandomActivityAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("http://www.boredapi.com/api/activity/");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Event>();
            }
            return null;
        }
        public async Task<Event> GetActivityByTypeAsync(string query)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"http://www.boredapi.com/api/activity?type={query}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Event>();
            }
            return null;
        }

        public async Task<Event> GetActivityByParticipantsAsync(string participants)
        {
            int number;
            if (!int.TryParse(participants, out number))
                number = 1;
            HttpResponseMessage response = await _httpClient.GetAsync($"http://www.boredapi.com/api/activity?participants={number}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Event>();
            }
            return null;
        }

        public async Task<Event> GetActivityByPriceRangeAsync(string min,string max)
        {
            double minNum;
            if (!double.TryParse(min, out minNum))
                minNum = 0;

            double maxNum;
            if (!double.TryParse(max, out maxNum))
                maxNum = 1000;

            HttpResponseMessage response = await _httpClient.GetAsync($"http://www.boredapi.com/api/activity?minprice={minNum}&maxprice={maxNum}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Event>();
            }
            return null;
        }
    }
}
