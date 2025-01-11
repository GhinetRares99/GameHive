// <copyright file="PermissionService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.PermissionService;

using System.Security.Claims;
using GameHive.Models;
using GameHive.Services.Repositories.PermissionRepository;

/// <summary>
/// Represents the service for the <see cref="Permission"/> class.
/// </summary>
public class PermissionService : IPermissionService
{
    private readonly PermissionRepository permissionRepository;
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionService"/> class.
    /// </summary>
    /// <param name="permissionRepository">The repository for the Permission class.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public PermissionService(PermissionRepository permissionRepository, IHttpContextAccessor httpContextAccessor)
    {
        this.permissionRepository = permissionRepository;
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Find a permission in the database.
    /// </summary>
    /// <returns>The permission with the specified attributes from the context.</returns>
    public async Task<Permission?> GetPermission()
    {
        var endpoint = this.httpContextAccessor.HttpContext?.Request.Path.Value ?? string.Empty;
        var routeData = this.httpContextAccessor.HttpContext?.GetRouteData().Values;
        if (routeData != null)
        {
            foreach (var (key, obj) in routeData.Skip(2))
            {
                var value = obj?.ToString();
                endpoint = endpoint.Replace(value ?? string.Empty, "{" + key + "}");
            }
        }

        var httpMethod = this.httpContextAccessor.HttpContext?.Request.Method.ToUpper() ?? string.Empty;
        var role = this.httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Role) ?? string.Empty;

        var foundPermission = await this.permissionRepository.FindPermissionByEndpointMethodAndRole(endpoint, httpMethod, role);
        return foundPermission;
    }
}