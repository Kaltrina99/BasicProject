using Microsoft.Extensions.Configuration;
using Models.DataAccess;
using Models.DTO;
using Newtonsoft.Json;
using Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BaseService : IBaseService
    {
        private readonly HttpClient _httpClient;
        private IConfiguration _configuration;

        public BaseService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        public async Task CreateBase(BaseClassDTO baseClass)
        {
            var content = JsonConvert.SerializeObject(baseClass);
            var bodyContent = new StringContent(content, Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:44352/api/BaseClass/CreateBase", bodyContent);
            string responseResult = response.Content.ReadAsStringAsync().Result;
            if (response.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<BaseClassDTO>(responseResult);
            }
        }

        public async Task<IEnumerable<BaseClass>> GetAll()
        {
            var response = await _httpClient.GetAsync($"https://localhost:44352/api/BaseClass/GetAll");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var apcases = JsonConvert.DeserializeObject<IEnumerable<BaseClass>>(content);

                return apcases;
            }

            return new List<BaseClass>();
        }
    }
}
