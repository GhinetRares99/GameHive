// <copyright file="EmailTemplate.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models;

using GameHive.Models.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

/// <summary>
/// Represents an email template.
/// </summary>
public class EmailTemplate : IEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the email template.
    /// </summary>
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the email template.
    /// </summary>
    [BsonElement("Name")]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the text content of the email template.
    /// </summary>
    [BsonElement("Text")]
    public string Text { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the text content of the email template.
    /// </summary>
    [BsonElement("Subject")]
    public string Subject { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the email template is in HTML format.
    /// </summary>
    [BsonElement("IsHtmlEmail")]
    public bool IsHtmlEmail { get; set; }
}