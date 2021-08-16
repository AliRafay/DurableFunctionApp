using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace DurableFunctionApp
{
    public static class HttpFunctions
        {
            [FunctionName(nameof(ProcessVideoStarter))]
            public static async Task<HttpResponseMessage> ProcessVideoStarter(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestMessage req,
            [DurableClient] IDurableOrchestrationClient starter,
            ILogger log)
            {
                // Function input comes from the request content.
                string instanceId = await starter.StartNewAsync("VideoProcessorOrchestrator", null);

                log.LogInformation($"Started VideoProcessorOrchestrator with ID = '{instanceId}'.");

                return starter.CreateCheckStatusResponse(req, instanceId);
            }
        }
}