using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace TvCast.AzureFunctions.Triggers
{
    public static class ShowBlobTrigger
    {
        [FunctionName("ShowBlobTrigger")]
        public static async Task RunAsync([BlobTrigger("show/{name}"), StorageAccount("AzureWebJobsStorage")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}