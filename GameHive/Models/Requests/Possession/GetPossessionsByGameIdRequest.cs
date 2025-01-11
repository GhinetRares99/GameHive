// <copyright file="GetPossessionsByGameIdRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Possession;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to get possessions from the database by game id.
/// </summary>
public class GetPossessionsByGameIdRequest : IRequest
{
    /// <summary>
    /// Gets or sets the game id.
    /// </summary>
    public string GameId { get; set; } = string.Empty;
}