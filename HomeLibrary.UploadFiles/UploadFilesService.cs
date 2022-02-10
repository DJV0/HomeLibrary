using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeLibrary.UploadFiles
{
    public class UploadFilesService
    {
        private readonly string _connectionString;
        private readonly string _blobContainerName = "images";

        public UploadFilesService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<string>> UploadAsync(IFormFileCollection files)
        {
            List<string> uriList = new List<string>();
            foreach (var file in files)
            {
                if(file.Length > 0)
                {
                    var blobContainerClient = new BlobContainerClient(_connectionString, _blobContainerName);
                    var createResponse = await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);

                    BlobClient blobClient = blobContainerClient.GetBlobClient(file.FileName);
                    using (var fileStream = file.OpenReadStream())
                    {
                        await blobClient.UploadAsync(fileStream, new BlobHttpHeaders { ContentType = file.ContentType });
                    }
                    uriList.Add(blobClient.Uri.ToString());
                }
            }
            return uriList;
        }
    }
}
