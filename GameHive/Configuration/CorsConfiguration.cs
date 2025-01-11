// <copyright file="CorsConfiguration.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Configuration;

using GameHive.Models.Settings;

/// <summary>
/// Helper class for CORS configuration.
/// </summary>
public static class CorsConfiguration
{
    /// <summary>
    /// Configures the CORS settings.
    /// </summary>
    /// <param name="app">The application.</param>
    /// <param name="corsSettings">The CORS settings.</param>
    public static void Configure(IApplicationBuilder app, CorsSettings corsSettings)
    {
        app.UseCors(options =>
        {
            options.WithOrigins(corsSettings.BackendUrl, corsSettings.FrontendUrl);
            options.AllowAnyMethod();
            options.AllowAnyHeader();
            options.WithExposedHeaders("Authorization");
        });
    }
}