// <copyright file="RecoverPasswordRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.User;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to set a new password.
/// </summary>
public class RecoverPasswordRequest : IRequest
{
    /// <summary>
    /// Gets or sets the new password of the user.
    /// </summary>
    public string NewPassword { get; set; } = string.Empty;
}