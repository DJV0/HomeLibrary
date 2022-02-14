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
        private readonly string _requestUri;
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
            var response = await httpClient.PostAsJsonAsync($"{_requestUri}/create", entity);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<T>();
        }

        public async Task<bool> Update(int id, T entity)
        {
            var response = await httpClient.PutAsJsonAsync($"{_requestUri}/{id}", entity);
            response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode) return false;
            return true;
            
        }

        public async Task Delete(int id)
        {
            var response = await httpClient.DeleteAsync($"{_requestUri}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
