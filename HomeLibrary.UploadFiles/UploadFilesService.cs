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

        public async Task<IDictionary<string, string>> UploadAsync(IFormFileCollection files)
        {
            Dictionary<string, string> uriList = new Dictionary<string, string>();
            foreach (var file in files)
            {
                if(file.Length > 0)
                {
                    string fileName = file.FileName;
                    var blobContainerClient = new BlobContainerClient(_connectionString, _blobContainerName);
                    await blobContainerClient.CreateIfNotExistsAsync(PublicAccessType.Blob);
                    var blobClient = blobContainerClient.GetBlobClient(fileName);
                    if ((await blobClient.ExistsAsync()).Value)
                    {
                        Random rnd = new Random((int)DateTime.Now.Ticks);
                        fileName = "image_" + rnd.Next().ToString() + fileName;
                        blobClient = blobContainerClient.GetBlobClient(fileName);
                    }
                    await blobContainerClient.UploadBlobAsync(fileName, file.OpenReadStream());
                    uriList.Add(fileName, blobClient.Uri.ToString());
                }
            }
            return uriList;
        }

        public async Task DeleteAsync(string fileName)
        {
            var blobContainerClient = new BlobContainerClient(_connectionString, _blobContainerName);
            var blobClient = blobContainerClient.GetBlobClient(fileName);
            await blobClient.DeleteIfExistsAsync();
        }
    }
}
