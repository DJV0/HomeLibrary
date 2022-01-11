using HomeLibrary.Shared.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace HomeLibrary.Client.HttpClients
{
    public class TagClient
    {
        private readonly HttpClient _httpClient;
        private string _requestUri = "/api/tags";

        public TagClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            httpClient.BaseAddress = new Uri("https://localhost:44363");
        }

        public async Task<ICollection<TagDto>> GetAll()
        {
            return await _httpClient.GetFromJsonAsync<ICollection<TagDto>>(_requestUri);
        }

        public async Task<TagDto> GetByName(string name)
        {
            return await _httpClient.GetFromJsonAsync<TagDto>($"{_requestUri}/{name}");
        }

        public async Task<TagDto> Create(string tagDto)
        {
            var response = await _httpClient.PostAsJsonAsync(_requestUri, tagDto);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TagDto>(stream);
        }

        public async Task<TagDto> Update(string name, TagDto tagDto)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_requestUri}/{name}", tagDto);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<TagDto>(stream);
        }

        public async Task Delete(string name)
        {
            var response = await _httpClient.DeleteAsync(name);
            response.EnsureSuccessStatusCode();
        }
    }
}
