// <copyright file="SendRecoverEmailRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.User;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to send a password recover email.
/// </summary>
public class SendRecoverEmailRequest : IRequest
{
    /// <summary>
    /// Gets or sets the email of the user.
    /// </summary>
    public string Email { get; set; } = string.Empty;
}