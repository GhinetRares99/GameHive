// <copyright file="IPermissionService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.PermissionService;

using GameHive.Models;

/// <summary>
/// Represents an interface for the service for the <see cref="Permission"/> class.
/// </summary>
public interface IPermissionService
{
    /// <summary>
    /// Find a permission in the database.
    /// </summary>
    /// <returns>The permission with the specified attributes from the context.</returns>
    Task<Permission?> GetPermission();
}