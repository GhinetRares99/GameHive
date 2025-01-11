// <copyright file="Trophy.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models;

using GameHive.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// <summary>
/// Represents an in-game game.
/// </summary>
public class Trophy : IEntity
{
    /// <summary>
    /// Gets or sets the ID of the trophy.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ID of the associated game.
    /// </summary>
    public string GameId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the trophy.
    /// </summary>
    [BsonElement("Name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the trophy.
    /// </summary>
    [BsonElement("Description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the icon url of the trophy.
    /// </summary>
    [BsonElement("IconUrl")]
    public string IconUrl { get; set; } = string.Empty;
}