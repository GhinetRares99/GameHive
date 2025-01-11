// <copyright file="DeletePossessionsByUserIdRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Possession;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to delete possessions from the database by user id.
/// </summary>
public class DeletePossessionsByUserIdRequest : IRequest
{
    /// <summary>
    /// Gets or sets the user id.
    /// </summary>
    public string UserId { get; set; } = string.Empty;
}