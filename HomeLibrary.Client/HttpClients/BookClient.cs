using HomeLibrary.Shared.Dto;
using System;
using System.Net.Http;

namespace HomeLibrary.Client.HttpClients
{
    public class BookClient : GenericClient<BookDto>
    {
        public BookClient(HttpClient httpClient) : base(httpClient, "/api/books")
        {
            httpClient.BaseAddress = new Uri("https://localhost:44363");
        }
    }
}
