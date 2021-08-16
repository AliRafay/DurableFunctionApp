using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.DurableTask;
using Microsoft.Azure.WebJobs.Host;

namespace DurableFunctionApp
{
    public static class OrchestratorFunctions
    {
        [FunctionName("VideoProcessorOrchestrator")]
        public static async Task<List<string>> RunOrchestrator(
            [OrchestrationTrigger] IDurableOrchestrationContext context)
        {
            var outputs = new List<string>();

            // Replace "hello" with the name of your Durable Activity Function.
            outputs.Add(await context.CallActivityAsync<string>("Activity1", "Tokyo"));
            outputs.Add(await context.CallActivityAsync<string>("Activity1", "Seattle"));
            outputs.Add(await context.CallActivityAsync<string>("Activity1", "London"));

            // returns ["Hello Tokyo!", "Hello Seattle!", "Hello London!"]
            return outputs;
        }
    }
}