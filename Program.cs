using System;
using System.Threading.Tasks;
using IntegrationEngine;

var supervisor = new ResiliencyService();
int internalCounter = 0;

Func<Task<string>> unreliableTask = async () =>
{
    internalCounter++;
    await Task.Delay(100);
    if (internalCounter < 3) throw new Exception("Connection Timeout");
    return "Data from External API";
};
Console.WriteLine(">>> STARTING RESILIENT INTEGRATION...");
var result = await supervisor.ExecuteWithRetryAsync(unreliableTask);
if (result.Success)
{
    Console.WriteLine($"[FINAL] Succes on attempt {result.AttemptCount}: {result.Data}");
}
else
{
    Console.WriteLine($"[CRITICAL] {result.Message}");
}
