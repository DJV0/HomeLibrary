using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HomeLibrary.Client.HttpClients
{
    public abstract class GenericClient<T> where T : class
    {
        protected readonly HttpClient httpClient;
        private string _requestUri;
        public GenericClient(HttpClient client, string requestUri)
        {
            httpClient = client;
            _requestUri = requestUri;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await httpClient.GetFromJsonAsync<ICollection<T>>(_requestUri);
        }

        public async Task<T> GetById(int id)
        {
            return await httpClient.GetFromJsonAsync<T>($"{_requestUri}/{id}");
        }

        public async Task<T> Create(T entity)
        {
            var response = await httpClient.PostAsJsonAsync(_requestUri, entity);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public async Task<T> Update(int id, T entity)
        {
            var response = await httpClient.PutAsJsonAsync(_requestUri, entity);
            response.EnsureSuccessStatusCode();
            var stream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<T>(stream);
        }

        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"{_requestUri}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
