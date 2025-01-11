// <copyright file="Game.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models;

using GameHive.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// <summary>
/// Represents a game.
/// </summary>
public class Game : IEntity
{
    /// <summary>
    /// Gets or sets the ID of the game.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the game.
    /// </summary>
    [BsonElement("Name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the game.
    /// </summary>
    [BsonElement("Description")]
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the genre of the game.
    /// </summary>
    [BsonElement("Genre")]
    public string Genre { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the price of the game.
    /// </summary>
    [BsonElement("Price")]
    public double Price { get; set; }

    /// <summary>
    /// Gets or sets the minimum supported OS.
    /// </summary>
    [BsonElement("MinimumSupportedOS")]
    public string MinimumSupportedOS { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the minimum supported graphics card.
    /// </summary>
    [BsonElement("MinimumSupportedGraphicsCard")]
    public string MinimumSupportedGraphicsCard { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the minimum supported processor.
    /// </summary>
    [BsonElement("MinimumSupportedProcessor")]
    public string MinimumSupportedProcessor { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the minimum supported Memory.
    /// </summary>
    [BsonElement("MinimumSupportedMemory")]
    public string MinimumSupportedMemory { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the storage.
    /// </summary>
    [BsonElement("Storage")]
    public string Storage { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the first picture.
    /// </summary>
    [BsonElement("PicOne")]
    public string PicOne { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the second picture.
    /// </summary>
    [BsonElement("PicTwo")]
    public string PicTwo { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the third picture.
    /// </summary>
    [BsonElement("PicThree")]
    public string PicThree { get; set; } = string.Empty;
}