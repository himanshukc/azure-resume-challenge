using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using Microsoft.Azure.WebJobs.Extensions.CosmosDB;




namespace Company.Function
{
    public static class ResumeChallengeCounter
    {

        //Constants for CosmosDB configuration

        //private const string databaseName = "azureresumech"

        [FunctionName("ResumeChallengeCounter")]
        public static HttpResponseMessage Run (
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,

            [CosmosDB(

                databaseName: "Azureresume",
                containerName: "counter",
                Connection = "AzureResumechConnectionString",
                Id = "1",
                PartitionKey = "1")] Counter counter,

            [CosmosDB (
                databaseName: "Azureresume",
                containerName: "counter",
                Connection = "AzureResumechConnectionString",
                Id = "1",
                PartitionKey = "1")] out Counter updatedCounter,
            ILogger log)

        {
            // Here is where the counter gets updated. Troubleshooting with backend automation
            log.LogInformation (" C# HTTP trigger function processed a request.");
           
           //increment the count
            updatedCounter = counter;
            updatedCounter.Count += 1;
     

           
            var jsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage (System.Net.HttpStatusCode.OK)
            {
                Content = new StringContent (jsonToReturn, Encoding.UTF8, "application/json")
            };


        }
            
    }
}
