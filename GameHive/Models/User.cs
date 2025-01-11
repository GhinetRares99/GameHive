// <copyright file="User.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models;

using GameHive.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// <summary>
/// Represents a user.
/// </summary>
public class User : IEntity
{
    /// <summary>
    /// Gets or sets the ID of the user.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email of the user.
    /// </summary>
    [BsonElement("Email")]
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password of the user.
    /// </summary>
    [BsonElement("Password")]
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the username.
    /// </summary>
    [BsonElement("Username")]
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user's country of residence.
    /// </summary>
    [BsonElement("CountryOfResidence")]
    public string CountryOfResidence { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the role of the user.
    /// </summary>
    [BsonElement("Role")]
    public string Role { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the account is active or not.
    /// </summary>
    [BsonElement("Status")]
    public string Status { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating the activation token of the user.
    /// </summary>
    [BsonElement("ActivationToken")]
    public string ActivationToken { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating the balance of the user.
    /// </summary>
    [BsonElement("Balance")]
    public double Balance { get; set; }

    /// <summary>
    /// Gets or sets a value indicating the profile picture of the user.
    /// </summary>
    [BsonElement("ProfilePic")]
    public string ProfilePic { get; set; } = string.Empty;
}