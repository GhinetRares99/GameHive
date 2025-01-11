// <copyright file="TokenSettings.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Settings;

/// <summary>
/// A class that represents the token generation settings.
/// </summary>
public class TokenSettings
{
    /// <summary>
    /// Gets or sets the token generation key value.
    /// </summary>
    public string TokenGenerationKeyValue { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the activation token generation key value.
    /// </summary>
    public string ActivationTokenGenerationKeyValue { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password recovery token generation key value.
    /// </summary>
    public string PasswordRecoveryTokenGenerationKeyValue { get; set; } = string.Empty;
}