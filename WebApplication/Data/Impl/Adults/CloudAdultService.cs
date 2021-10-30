using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop.Implementation;
using Models;

namespace WebApplication.Data.Impl.Adults
{
    public class CloudAdultService : IAdults
    {
        private string uri = "https://localhost:5001";
        private readonly HttpClient client;

        public CloudAdultService()
        {
            client = new HttpClient();
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
            HttpResponseMessage response = await client.GetAsync(uri + "/adults");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Error or whatever");
            }

            string message = await response.Content.ReadAsStringAsync();
            Console.WriteLine(message);
            List<Adult> result = JsonSerializer.Deserialize<List<Adult>>(message);
            return result;
        }

        public async Task AddAdultAsync(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson, Encoding.UTF8, "application/json");
            await client.PostAsync(uri + "/adults", content);
        }

        public async Task RemoveAdultAsync(int adultId)
        {
            await client.DeleteAsync($"{uri}/adults/{adultId}");
        }

        public async Task Update(Adult adult)
        {
            string adultAsJson = JsonSerializer.Serialize(adult);
            HttpContent content = new StringContent(adultAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PatchAsync($"{uri}/adults/{adult.id}", content);
        }

        public async Task<Adult> GetAsync(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}