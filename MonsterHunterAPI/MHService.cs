using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MonsterHunterAPI
{
    public class MHService
    {
        private readonly HttpClient _httpClient = new HttpClient();


        public async Task<Monster> GetMonsterById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"https://mhw-db.com/monsters/{id}");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsAsync<Monster>();
            }
            return null;
        }
    }
}
