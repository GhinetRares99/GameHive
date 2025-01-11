// <copyright file="DeleteTrophiesByGameIdRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Trophy;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to delete trophies from the database by game id.
/// </summary>
public class DeleteTrophiesByGameIdRequest : IRequest
{
    /// <summary>
    /// Gets or sets the game id.
    /// </summary>
    public string GameId { get; set; } = string.Empty;
}