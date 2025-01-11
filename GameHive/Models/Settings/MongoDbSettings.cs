// <copyright file="MongoDbSettings.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Settings;

/// <summary>
/// Represents a class that stores MongoDB Settings information.
/// </summary>
public class MongoDbSettings
{
    /// <summary>
    /// Gets or sets the connection string of the MongoDB Settings.
    /// </summary>
    public string ConnectionString { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the database name of the MongoDB Settings.
    /// </summary>
    public string DatabaseName { get; set; } = string.Empty;
}