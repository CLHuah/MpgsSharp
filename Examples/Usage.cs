using Microsoft.Extensions.DependencyInjection;
using MpgsSharp.Extensions;
using MpgsSharp.Models.HostedCheckout;
using MpgsSharp.Services.Interfaces;

namespace MpgsSharp.Examples;

/// <summary>
///     Examples demonstrating how to use the MPGS Payment Gateway library.
/// </summary>
public static class Usage
{
    /// <summary>
    ///     Example of how to set up and use the MPGS client.
    /// </summary>
    public static async Task RunExampleAsync()
    {
        // Configure services
        var services = new ServiceCollection();
        
        services.AddLogging();

        services.AddMpgsPaymentGateway(options => options
            .WithApiBaseUrl("https://ap-gateway.mastercard.com/")
            .WithMerchantId("YOUR_MERCHANT_ID")
            .WithApiPassword("YOUR_API_PASSWORD")
            .WithApiVersion("100")
            .WithTimeoutSeconds(30));
        
        var serviceProvider = services.BuildServiceProvider();

        // Get the hosted checkout service
        var hostedCheckoutService = serviceProvider.GetRequiredService<IHostedCheckoutService>();

        // Generate order ID that will be used across the payment flow
        var orderId = $"Order-{Guid.NewGuid():N}"[..30]; // Ensure within 40 char limit

        // Create a checkout session
        var checkoutRequest = new HostedCheckoutRequest
        {
            ApiOperation = "INITIATE_CHECKOUT",
            Customer = new CustomerRequest { Email = "customer@example.com" },
            Order = new OrderRequest
            {
                Amount = 100.00m,
                Currency = "MYR",
                Description = "Test Order",
                Id = orderId,
                NotificationUrl = "https://your-website.com/api/payment-notifications",
                StatementDescriptor = new StatementDescriptorRequest { Name = "Your Store Name" }
            },
            Interaction = new InteractionRequest
            {
                ReturnUrl = "https://your-website.com/checkout/complete",
                CancelUrl = "https://your-website.com/checkout/cancel",
                Operation = HostedCheckoutConstants.OperationType.Purchase,
                Merchant = new MerchantInteractionRequest
                {
                    DisplayName = "Your Store Name",
                    Logo = "https://your-website.com/logo.png",
                    Url = "https://your-website.com"
                }
            }
        };

        var checkoutResponse = await hostedCheckoutService.CreateSessionAsync(checkoutRequest);

        // After payment completion, check the status
        // Get the transaction service
        var transactionService = serviceProvider.GetRequiredService<ITransactionService>();

        // Use the same orderId to retrieve order details
        var orderDetails = await transactionService.GetOrderAsync(orderId);
        
        // Check if the transaction status is "CAPTURED"
    }

    /// <summary>
    ///     Example of how to perform a health check of the MPGS gateway.
    /// </summary>
    public static async Task HealthCheckExampleAsync()
    {
        // Configure services
        var services = new ServiceCollection();
        
        services.AddLogging();

        services.AddMpgsPaymentGateway(options => options
            .WithApiBaseUrl("https://ap-gateway.mastercard.com/")
            .WithMerchantId("YOUR_MERCHANT_ID")
            .WithApiPassword("YOUR_API_PASSWORD"));

        var serviceProvider = services.BuildServiceProvider();

        // Get the health check service
        var healthCheckService = serviceProvider.GetRequiredService<IHealthCheckService>();

        // Check if the gateway is operational
        var isHealthy = await healthCheckService.IsHealthyAsync();
        Console.WriteLine($"Gateway is operational: {isHealthy}");

        // Get detailed health information
        var healthInfo = await healthCheckService.CheckHealthAsync();
        Console.WriteLine($"Gateway version: {healthInfo.GatewayVersion}");
        Console.WriteLine($"Gateway status: {healthInfo.Status}");
    }
}