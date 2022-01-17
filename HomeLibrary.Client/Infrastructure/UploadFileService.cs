using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeLibrary.Client.Infrastructure
{
    public class UploadFileService
    {
        private readonly string _connectionString;
        private readonly string _blobContainerName = "images";

        public UploadFileService(string connectionString/*, string containerName,*/)
        {
            _connectionString = connectionString;
            //_blobContainerName = containerName;
        }

        public async Task<string> UploadAsync(IBrowserFile file)
        {
            if(file.Size > 0)
            {
                try
                {
                    var blobContainerClient = new BlobContainerClient(_connectionString, _blobContainerName);
                    var createResponse = await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

                    BlobClient blobClient = blobContainerClient.GetBlobClient(file.Name);
                    using (var fileStream = file.OpenReadStream())
                    {
                        await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                    }
                    return blobClient.Uri.ToString();
                }
                catch (Exception)
                {
                    throw;
                }
                
            }

            return String.Empty;
        }
    }
}
