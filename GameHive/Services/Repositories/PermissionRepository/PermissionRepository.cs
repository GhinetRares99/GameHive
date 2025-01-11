// <copyright file="PermissionRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.PermissionRepository;

using System.Linq.Expressions;
using GameHive.Models;
using MongoDB.Driver;

/// <summary>
/// Represents a repository for <see cref="Permission"/> class.
/// </summary>
public class PermissionRepository : GenericRepository<Permission>, IPermissionRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PermissionRepository"/> class.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public PermissionRepository(IMongoDatabase database)
        : base(database)
    {
    }

    /// <summary>
    /// FInd a permission by endpoint, HTTP method and role.
    /// </summary>
    /// <param name="endpoint">The URL of the endpoint.</param>
    /// <param name="httpMethod">The HTTP method type.</param>
    /// <param name="role">The role that can access the resource.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<Permission?> FindPermissionByEndpointMethodAndRole(string endpoint, string httpMethod, string role)
    {
        Expression<Func<Permission, bool>> endpointMethodAndRoleExpression = permission =>
            permission.Endpoint.Equals(endpoint) &&
            permission.HttpMethod.Equals(httpMethod) &&
            permission.Role.Equals(role);

        var filterExpression = new FilterExpression<Permission>
        {
            Filter = endpointMethodAndRoleExpression,
        };

        return await this.GetOneFilteredAsync(filterExpression);
    }
}