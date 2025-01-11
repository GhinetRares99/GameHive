// <copyright file="MongoDbIndexConfiguration.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Configuration;

using GameHive.Models;
using GameHive.Models.Settings;
using MongoDB.Driver;

/// <summary>
/// Represents a class for configuring unique indexes in MongoDB.
/// </summary>
public class MongoDbIndexConfiguration
{
    /// <summary>
    /// Configures unique indexes for the specified MongoDB database.
    /// </summary>
    /// <param name="serviceProvider">The service provider.</param>
    /// <param name="mongoDbSettings">The MongoDB settings.</param>
    public static void Configure(IServiceProvider serviceProvider, MongoDbSettings mongoDbSettings)
    {
        var mongoClient = serviceProvider.GetService<IMongoClient>();
        var databaseName = mongoDbSettings?.DatabaseName ?? throw new ArgumentNullException(nameof(mongoDbSettings));
        var database = mongoClient?.GetDatabase(databaseName) ?? throw new Exception("Could not retrieve database");

        MongoDbIndexRegistration<User>.ConfigureIndexes(database, "Email", "Password");
        MongoDbIndexRegistration<User>.ConfigureIndexes(database, "Email");
        MongoDbIndexRegistration<User>.ConfigureIndexes(database, "Username");
        MongoDbIndexRegistration<Game>.ConfigureIndexes(database, "Name");
        MongoDbIndexRegistration<Trophy>.ConfigureIndexes(database, "Name");
        MongoDbIndexRegistration<Possession>.ConfigureIndexes(database, "UserId", "GameId");
        MongoDbIndexRegistration<EmailTemplate>.ConfigureIndexes(database, "Name");
        MongoDbIndexRegistration<Permission>.ConfigureIndexes(database, "Endpoint", "HttpMethod", "Role");
    }
}