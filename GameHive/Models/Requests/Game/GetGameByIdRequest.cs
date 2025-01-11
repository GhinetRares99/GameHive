// <copyright file="GetGameByIdRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Game;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to retrieve a game's information by id.
/// </summary>
public class GetGameByIdRequest : IRequest
{
    /// <summary>
    /// Gets or sets the Id of the game.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}