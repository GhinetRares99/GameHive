// <copyright file="MongoDbConfiguration.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Configuration;

using GameHive.Models.Settings;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;

/// <summary>
/// Provides a helper class for configuring the database settings.
/// </summary>
public class MongoDbConfiguration
{
    /// <summary>
    /// Configures the database settings.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="mongoDbSettings">The MongoDB settings.</param>
    public static void Configure(IServiceCollection services, MongoDbSettings mongoDbSettings)
    {
        var connectionString = mongoDbSettings?.ConnectionString ?? throw new ArgumentNullException(nameof(mongoDbSettings));
        services.AddSingleton<IMongoClient>(new MongoClient(connectionString));
        services.AddSingleton<IMongoDatabase>(sp =>
        {
            var client = sp.GetRequiredService<IMongoClient>();
            var databaseName = mongoDbSettings.DatabaseName ?? throw new ArgumentNullException(nameof(mongoDbSettings));
            return client.GetDatabase(databaseName);
        });
        services.AddHealthChecks()
            .AddCheck("Database", () =>
            {
                var database = services.BuildServiceProvider().GetRequiredService<IMongoDatabase>();
                try
                {
                    database.ListCollections();
                    return HealthCheckResult.Healthy("Database connection is healthy.");
                }
                catch (Exception ex)
                {
                    return HealthCheckResult.Unhealthy($"Failed to connect to the database: {ex.Message}");
                }
            });
    }
}