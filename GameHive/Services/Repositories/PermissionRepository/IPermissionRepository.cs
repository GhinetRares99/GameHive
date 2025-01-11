// <copyright file="IPermissionRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.PermissionRepository;

using GameHive.Models;

/// <summary>
/// Represents the repository for the <see cref="Permission"/> class.
/// </summary>
public interface IPermissionRepository
{
    /// <summary>
    /// FInd a permission by endpoint, HTTP method and role.
    /// </summary>
    /// <param name="endpoint">The URL of the endpoint.</param>
    /// <param name="httpMethod">The HTTP method type.</param>
    /// <param name="role">The role that can access the resource.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    Task<Permission?> FindPermissionByEndpointMethodAndRole(string endpoint, string httpMethod, string role);
}