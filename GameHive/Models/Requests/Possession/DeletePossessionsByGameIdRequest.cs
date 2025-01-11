// <copyright file="DeletePossessionsByGameIdRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Possession;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to delete possessions from the database by game id.
/// </summary>
public class DeletePossessionsByGameIdRequest : IRequest
{
    /// <summary>
    /// Gets or sets the game id.
    /// </summary>
    public string GameId { get; set; } = string.Empty;
}