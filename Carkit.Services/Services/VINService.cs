using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Carkit.Services.DtoModels.VIN;

namespace Carkit.Services.Services
{
    public interface IVINService
    {
        Task<DecodeVIN> GetCar(string VIN);
    }

    public class VINService : IVINService
    {
        private readonly IHttpClientFactory _clientFactory;
        private const string VINClient = "VINClient";

        public VINService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<DecodeVIN> GetCar(string VIN)
        {
            var client = _clientFactory.CreateClient(VINClient);

            string url = $"{VIN}?format=json";
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<DecodeVINResponse>();
                return result.Results;
            }

            return null;
        }
    }
}
