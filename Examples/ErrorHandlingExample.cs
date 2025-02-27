using Microsoft.Extensions.DependencyInjection;
using MpgsSharp.Exceptions;
using MpgsSharp.Extensions;
using MpgsSharp.Models.HostedCheckout;
using MpgsSharp.Services.Interfaces;

namespace MpgsSharp.Examples;

/// <summary>
/// Examples of how to handle errors when using the MPGS API.
/// </summary>
public static class ErrorHandlingExample
{
    /// <summary>
    /// Example showing how to handle API errors.
    /// </summary>
    public static async Task HandleApiErrorsExample()
    {
        // Set up services
        var services = new ServiceCollection();
        services.AddMpgsPaymentGateway(options => options
            .WithApiBaseUrl("https://ap-gateway.mastercard.com/")
            .WithMerchantId("YOUR_MERCHANT_ID")
            .WithApiPassword("YOUR_API_PASSWORD"));
            
        var serviceProvider = services.BuildServiceProvider();
        var hostedCheckoutService = serviceProvider.GetRequiredService<IHostedCheckoutService>();
        
        try
        {
            // Create a request that may trigger an API error
            var checkoutRequest = new HostedCheckoutRequest
            {
                // Missing required fields...
                Order = new OrderRequest
                {
                    // Invalid negative amount
                    Amount = -10.00m,
                    Currency = "INVALID_CURRENCY",
                }
            };
            
            await hostedCheckoutService.CreateSessionAsync(checkoutRequest);
        }
        catch (MpgsApiException ex)
        {
            Console.WriteLine($"API Error: {ex.Message}");
            Console.WriteLine($"Status Code: {ex.StatusCode}");
            
            if (ex.ErrorResponse?.Error != null)
            {
                Console.WriteLine($"Error Cause: {ex.ErrorResponse.Error.Cause}");
                Console.WriteLine($"Error Explanation: {ex.ErrorResponse.Error.Explanation}");
                Console.WriteLine($"Error Field: {ex.ErrorResponse.Error.Field}");
                Console.WriteLine($"Support Code: {ex.ErrorResponse.Error.SupportCode}");
            }
        }
        catch (ArgumentException ex)
        {
            // Handle validation errors
            Console.WriteLine($"Validation Error: {ex.Message}");
        }
        catch (Exception ex)
        {
            // Handle other exceptions
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }
}
