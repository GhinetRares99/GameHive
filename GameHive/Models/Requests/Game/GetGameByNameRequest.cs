// <copyright file="GetGameByNameRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Game;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to retrieve a game's information by Name.
/// </summary>
public class GetGameByNameRequest : IRequest
{
    /// <summary>
    /// Gets or sets the Name of the game.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}