// <copyright file="CorsSettings.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Settings;

/// <summary>
/// Represents a class that stores CORS Settings information.
/// </summary>
public class CorsSettings
{
    /// <summary>
    /// Gets or sets the backend URL of the application.
    /// </summary>
    public string BackendUrl { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the frontend URL of the application.
    /// </summary>
    public string FrontendUrl { get; set; } = string.Empty;
}