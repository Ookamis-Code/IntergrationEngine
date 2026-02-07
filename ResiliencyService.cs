using System;
using System.Threading.Tasks;

namespace IntegrationEngine;

public class ResiliencyService
{
    private const int MaxRetries = 3;
    private const int DelayMiliseconds = 1000;

    public async Task<ServiceResponse<T>> ExecuteWithRetryAsync<T>(Func<Task<T>> action)
    {
        var response = new ServiceResponse<T>();
        for (int i = 1; i <= MaxRetries; i++)
        {
            try
            {
                response.AttemptCount = i;
                response.Data = await action();
                response.Success = true;
                response.Message = "Operation Successful";
                return response;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[RETRY {i}] Operation failed: {ex.Message}");
                if (i < MaxRetries)
                {
                    await Task.Delay(DelayMiliseconds);
                }
            }
        }
        response.Success = false;
        response.Message = "Circuit Tripped: Max retires exceeded.";
        return response;
    }
}