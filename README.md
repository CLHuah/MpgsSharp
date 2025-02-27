# MasterCard Payment Gateway Services (MPGS) .NET Library

A .NET library for integrating with MasterCard Payment Gateway Services (MPGS), focusing on Hosted Checkout functionality.

## Features

- Hosted Checkout integration
- Retrieve order and transaction details
- Dependency injection support
- Async/await pattern
- JSON serialization/deserialization

## Installation

```shell
dotnet add package MpgsSharp
```

## Configuration

Configure the MPGS client in your service collection:

```csharp
services.AddMpgsPaymentGateway(options => options
    .WithApiBaseUrl("https://ap-gateway.mastercard.com/")
    .WithMerchantId("YOUR_MERCHANT_ID")
    .WithApiPassword("YOUR_API_PASSWORD")
    .WithApiVersion("100") // Optional, defaults to 100
    .WithTimeoutSeconds(30) // Optional, defaults to 30 seconds
);
```

## Usage

### Creating a Hosted Checkout Session

```csharp
// Get the service from DI
var hostedCheckoutService = serviceProvider.GetRequiredService<IHostedCheckoutService>();

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

```

### Retrieving Order Details using TransactionService

```csharp
var transactionService = serviceProvider.GetRequiredService<ITransactionService>();
var orderDetails = await transactionService.GetOrderAsync(orderId);

// Access order information
var orderStatus = orderDetails.Status;
var orderAmount = orderDetails.Amount;
var orderCurrency = orderDetails.Currency;
```

### Retrieving Transaction Details

```csharp
var transactionService = serviceProvider.GetRequiredService<ITransactionService>();
var transactionDetails = await transactionService.GetTransactionAsync(orderId, transactionId);

// Access transaction information
var transactionResult = transactionDetails.Result;
var transactionStatus = transactionDetails.Status;
```

## Error Handling

The library throws standard exceptions for error conditions:

- `ArgumentException` - For invalid arguments
- `HttpRequestException` - For network/API errors
- `InvalidOperationException` - For serialization/deserialization issues

It's recommended to handle these exceptions appropriately in your application.

## License

[MIT License](LICENSE)
