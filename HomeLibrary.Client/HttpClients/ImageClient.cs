using HomeLibrary.Shared.Dto;
using System;
using System.Net.Http;

namespace HomeLibrary.Client.HttpClients
{
    public class ImageClient : GenericClient<ImageDto>
    {
        public ImageClient(HttpClient httpClient) : base(httpClient, "/api/images")
        {
            httpClient.BaseAddress = new Uri("https://localhost:44363");
        }
    }
}
