﻿using Azure.Identity;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Application.Common.Interfaces;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Infrastructure.Data;
using TrucksInspections_ASP.NETCore_Angular_CleanArchitecture.Web.Services;
using Microsoft.AspNetCore.Mvc;

using ZymLabs.NSwag.FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddWebServices(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();

        services.AddScoped<IUser, CurrentUser>();

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddDbContextCheck<ApplicationDbContext>();

        services.AddExceptionHandler<CustomExceptionHandler>();

        services.AddRazorPages();

        services.AddScoped(provider =>
        {
            var validationRules = provider.GetService<IEnumerable<FluentValidationRule>>();
            var loggerFactory = provider.GetService<ILoggerFactory>();

            return new FluentValidationSchemaProcessor(provider, validationRules, loggerFactory);
        });

        // Customise default API behaviour
        services.Configure<ApiBehaviorOptions>(options =>
            options.SuppressModelStateInvalidFilter = true);

        services.AddEndpointsApiExplorer();

        services.AddOpenApiDocument((configure, sp) =>
        {
            configure.Title = "TrucksInspections_ASP.NETCore_Angular_CleanArchitecture API";

            // Add the fluent validations schema processor
            var fluentValidationSchemaProcessor = 
                sp.CreateScope().ServiceProvider.GetRequiredService<FluentValidationSchemaProcessor>();

            // BUG: SchemaProcessors is missing in NSwag 14 (https://github.com/RicoSuter/NSwag/issues/4524#issuecomment-1811897079)
            // configure.SchemaProcessors.Add(fluentValidationSchemaProcessor);

        });

        return services;
    }

    public static IServiceCollection AddKeyVaultIfConfigured(this IServiceCollection services, ConfigurationManager configuration)
    {
        var keyVaultUri = configuration["KeyVaultUri"];
        if (!string.IsNullOrWhiteSpace(keyVaultUri))
        {
            configuration.AddAzureKeyVault(
                new Uri(keyVaultUri),
                new DefaultAzureCredential());
        }

        return services;
    }
}
