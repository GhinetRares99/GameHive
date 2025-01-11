// <copyright file="GetPossessionsByUserIdRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Possession;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to get possessions from the database by user id.
/// </summary>
public class GetPossessionsByUserIdRequest : IRequest
{
    /// <summary>
    /// Gets or sets the user id.
    /// </summary>
    public string UserId { get; set; } = string.Empty;
}