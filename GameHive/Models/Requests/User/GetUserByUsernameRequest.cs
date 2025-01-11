// <copyright file="GetUserByUsernameRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.User;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to retrieve a user's information by Username.
/// </summary>
public class GetUserByUsernameRequest : IRequest
{
    /// <summary>
    /// Gets or sets the Username of the user.
    /// </summary>
    public string Username { get; set; } = string.Empty;
}