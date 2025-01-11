// <copyright file="DeleteGameRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Game;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to delete a game from the database.
/// </summary>
public class DeleteGameRequest : IRequest
{
    /// <summary>
    /// Gets or sets the Id of the game.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}