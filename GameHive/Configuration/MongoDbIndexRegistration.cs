// <copyright file="MongoDbIndexRegistration.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Configuration;

using GameHive.Models.Interfaces;
using MongoDB.Driver;

/// <summary>
/// Represents a class for registering unique indexes in MongoDB for a specific document type.
/// </summary>
/// <typeparam name="TDocument">The type of the document.</typeparam>
public static class MongoDbIndexRegistration<TDocument>
    where TDocument : IEntity
{
    /// <summary>
    /// Configures the indexes for the specified MongoDB database based on the provided document type and fields.
    /// </summary>
    /// <param name="database">The MongoDB database.</param>
    /// <param name="fields">The fields to configure for indexing.</param>
    public static void ConfigureIndexes(IMongoDatabase database, params string[] fields)
    {
        var collection = database.GetCollection<TDocument>(typeof(TDocument).Name);
        CreateUniqueIndex(collection, fields);
    }

    private static void CreateUniqueIndex(IMongoCollection<TDocument> collection, params string[] fields)
    {
        var indexKeys = fields.Select(field => Builders<TDocument>.IndexKeys.Ascending(field)).ToList();
        var indexKeysDefinition = Builders<TDocument>.IndexKeys.Combine(indexKeys);
        var indexOptions = new CreateIndexOptions { Unique = true };
        var indexModel = new CreateIndexModel<TDocument>(indexKeysDefinition, indexOptions);
        collection.Indexes.CreateOne(indexModel);
    }
}