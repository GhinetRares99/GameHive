// <copyright file="DeletePossessionRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Possession;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to delete a possession from the database.
/// </summary>
public class DeletePossessionRequest : IRequest
{
    /// <summary>
    /// Gets or sets the id of the user.
    /// </summary>
    public string UserId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the id of the game.
    /// </summary>
    public string GameId { get; set; } = string.Empty;
}