// <copyright file="AuthenticationSettings.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Settings;

/// <summary>
/// A class that represents the authentication settings.
/// </summary>
public class AuthenticationSettings
{
    /// <summary>
    /// Gets or sets the issuer.
    /// </summary>
    public string Issuer { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the audience.
    /// </summary>
    public string Audience { get; set; } = string.Empty;
}