using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HomeLibrary.Shared.Dto;
using Newtonsoft.Json;

namespace HomeLibrary.Client.HttpClients
{
    public class OpenLibraryClient
    {
        private HttpClient _client;
        private PropertyRenameSerializerContractResolver _jsonContractRevolser;
        public OpenLibraryClient(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("https://openlibrary.org");
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _jsonContractRevolser = new PropertyRenameSerializerContractResolver();
        }

        public async Task<OpenLibraryBookDto> GetBook(string isbn)
        {
            var request = new HttpRequestMessage(
                HttpMethod.Get,
                $"/api/books?bibkeys=ISBN:{isbn}&jscmd=data&format=json");

            _jsonContractRevolser.RenameProperty(typeof(OpenLibraryBookDto), "ISBN:{ }", $"ISBN:{isbn}");
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = _jsonContractRevolser;

            using (var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
            {
                var stream = await response.Content.ReadAsStringAsync();
                response.EnsureSuccessStatusCode();
                return JsonConvert.DeserializeObject<OpenLibraryBookDto>(stream, serializerSettings);
            }
        }
    }
}
