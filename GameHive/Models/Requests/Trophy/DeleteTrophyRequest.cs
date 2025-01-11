// <copyright file="DeleteTrophyRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Trophy;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to delete a trophy from the database.
/// </summary>
public class DeleteTrophyRequest : IRequest
{
    /// <summary>
    /// Gets or sets the Id of the trophy.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}