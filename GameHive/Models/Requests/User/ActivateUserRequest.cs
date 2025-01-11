// <copyright file="ActivateUserRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.User;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to activate a user's account.
/// </summary>
public class ActivateUserRequest : IRequest
{
    /// <summary>
    /// Gets or sets the activation token of the user.
    /// </summary>
    public string ActivationToken { get; set; } = string.Empty;
}