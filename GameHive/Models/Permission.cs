// <copyright file="Permission.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models;

using GameHive.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// <summary>
/// Represents a permission for an endpoint.
/// </summary>
public class Permission : IEntity
{
    /// <summary>
    /// Gets or sets the ID of the permission.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the URL of the endpoint.
    /// </summary>
    [BsonElement("Endpoint")]
    public string Endpoint { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the HTTP method's type.
    /// </summary>
    [BsonElement("HttpMethod")]
    public string HttpMethod { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the role that can access the endpoint.
    /// </summary>
    [BsonElement("Role")]
    public string Role { get; set; } = string.Empty;
}