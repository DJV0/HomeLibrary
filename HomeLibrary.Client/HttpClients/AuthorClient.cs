using HomeLibrary.Shared.Dto;
using System;
using System.Net.Http;

namespace HomeLibrary.Client.HttpClients
{
    public class AuthorClient : GenericClient<AuthorDto>
    {
        public AuthorClient(HttpClient httpClient) : base(httpClient, "/api/authors")
        {
            httpClient.BaseAddress = new Uri("https://localhost:44363");
        }
    }
}
