// <copyright file="Possession.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models;

using GameHive.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// <summary>
/// Represents a link between a game and a user.
/// </summary>
public class Possession : IEntity
{
    /// <summary>
    /// Gets or sets the ID of the possession.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the id of the user.
    /// </summary>
    [BsonElement("UserId")]
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the id of the game.
    /// </summary>
    [BsonElement("GameId")]
    public string GameId { get; set; } = string.Empty;
}