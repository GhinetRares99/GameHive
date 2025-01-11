// <copyright file="GetPossessionByGameIdAndUserIdRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Possession;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to retrieve a possesion from the database by game id and user id.
/// </summary>
public class GetPossessionByGameIdAndUserIdRequest : IRequest
{
    /// <summary>
    /// Gets or sets the game id.
    /// </summary>
    public string GameId { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the user id.
    /// </summary>
    public string UserId { get; set; } = string.Empty;
}