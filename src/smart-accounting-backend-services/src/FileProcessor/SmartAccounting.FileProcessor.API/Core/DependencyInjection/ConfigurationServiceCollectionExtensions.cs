﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SmartAccounting.EventBus.Configuration;
using SmartAccounting.FileProcessor.API.Configuration;
using SmartAccounting.Logging.Configuration;

namespace SmartAccounting.FileProcessor.API.Core.DependencyInjection
{
    internal static class ConfigurationServiceCollectionExtensions
    {
        public static IServiceCollection AddAppConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<SwaggerConfiguration>(config.GetSection("SwaggerConfig"));
            services.AddSingleton<IValidateOptions<SwaggerConfiguration>, SwaggerConfigurationValidation>();
            var swaggerConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<SwaggerConfiguration>>().Value;
            services.AddSingleton<ISwaggerConfiguration>(swaggerConfiguration);

            services.Configure<ApplicationInsightsServiceConfiguration>(config.GetSection("ApplicationInsightsConfig"));
            services.AddSingleton<IValidateOptions<ApplicationInsightsServiceConfiguration>, ApplicationInsightsServiceConfigurationValidation>();
            var applicationInsightsServiceConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<ApplicationInsightsServiceConfiguration>>().Value;
            services.AddSingleton<IApplicationInsightsServiceConfiguration>(applicationInsightsServiceConfiguration);

            services.Configure<StorageServiceConfiguration>(config.GetSection("BlobStorageConfig"));
            services.AddSingleton<IValidateOptions<StorageServiceConfiguration>, StorageServiceConfigurationValidation>();
            var storageServiceConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<StorageServiceConfiguration>>().Value;
            services.AddSingleton<IStorageServiceConfiguration>(storageServiceConfiguration);

            services.Configure<EventBusConfiguration>(config.GetSection("ServiceBusConfig"));
            services.AddSingleton<IValidateOptions<EventBusConfiguration>, EventBusConfigurationValidation>();
            var eventBusConfigurationConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<EventBusConfiguration>>().Value;
            services.AddSingleton<IEventBusConfiguration>(eventBusConfigurationConfiguration);

            services.Configure<CosmosDbServiceConfiguration>(config.GetSection("CosmosDbConfig"));
            services.AddSingleton<IValidateOptions<CosmosDbServiceConfiguration>, CosmosDbDataServiceConfigurationValidation>();
            var cosmosDbDataServiceConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<CosmosDbServiceConfiguration>>().Value;
            services.AddSingleton<ICosmosDbServiceConfiguration>(cosmosDbDataServiceConfiguration);

            services.Configure<SqlDbServiceConfiguration>(config.GetSection("SqlDbConfig"));
            services.AddSingleton<IValidateOptions<SqlDbServiceConfiguration>, SqlDbDataServiceConfigurationValidation>();
            var sqlDbServiceConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<SqlDbServiceConfiguration>>().Value;
            services.AddSingleton<ISqlDbServiceConfiguration>(sqlDbServiceConfiguration);

            services.Configure<AzureAdB2cServiceConfiguration>(config.GetSection("AzureAdB2CConfig"));
            services.AddSingleton<IValidateOptions<AzureAdB2cServiceConfiguration>, AzureAdB2cServiceConfigurationValidation>();
            var azureAdB2cServiceConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<AzureAdB2cServiceConfiguration>>().Value;
            services.AddSingleton<IAzureAdB2cServiceConfiguration>(azureAdB2cServiceConfiguration);

            return services;
        }
    }
}
