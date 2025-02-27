using Microsoft.Extensions.DependencyInjection;
using MpgsSharp.Configuration;
using MpgsSharp.Services;
using MpgsSharp.Services.Interfaces;
using System.Net;

namespace MpgsSharp.Extensions;

/// <summary>
///     Extension methods for setting up MPGS services in an <see cref="IServiceCollection" />.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    ///     Adds MPGS Payment Gateway services to the specified <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configureOptions">A callback to configure the <see cref="MpgsOptions" />.</param>
    /// <returns>The <see cref="IServiceCollection" /> so that additional calls can be chained.</returns>
    public static IServiceCollection AddMpgsPaymentGateway(this IServiceCollection services,
        Action<MpgsOptions> configureOptions)
    {
        // Configure options
        var options = new MpgsOptions();
        configureOptions(options);
        options.Validate();

        services.AddSingleton(options);

        // Register HTTP client
        services.AddHttpClient<IMpgsHttpClient, MpgsHttpClient>(client =>
        {
            client.BaseAddress = new Uri(options.ApiBaseUrl);
            client.Timeout = TimeSpan.FromSeconds(options.TimeoutSeconds);
        })
        .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            // Use default credentials and set credentials for the client
            UseDefaultCredentials = true,
            Credentials = new NetworkCredential(
                "merchant." + options.MerchantId,
                options.ApiPassword)
        });

        // Register services
        services.AddTransient<IHealthCheckService, HealthCheckService>();
        services.AddTransient<IHostedCheckoutService, HostedCheckoutService>();
        services.AddTransient<IMpgsClient, MpgsClient>();
        services.AddTransient<ITransactionService, TransactionService>();

        return services;
    }
}