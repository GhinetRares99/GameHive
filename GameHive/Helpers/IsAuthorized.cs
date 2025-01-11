// <copyright file="IsAuthorized.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Helpers;

using GameHive.Services.PermissionService;
using Microsoft.AspNetCore.Authorization;

/// <summary>
/// A class used to check if the user is authorized to use the resource.
/// </summary>
public class IsAuthorized
{
    private readonly RequestDelegate next;
    private readonly IPermissionService permissionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="IsAuthorized"/> class.
    /// </summary>
    /// <param name="next">The next request delegate in the middleware pipeline.</param>
    /// <param name="permissionService">The permission service.</param>
    public IsAuthorized(RequestDelegate next, IPermissionService permissionService)
    {
        this.next = next;
        this.permissionService = permissionService;
    }

    /// <summary>
    /// A function used to update the date and time of the last request made by the user.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>An asynchronous task that represents the operation.</returns>
    public async Task InvokeAsync(HttpContext context)
    {
        // Retrieve the endpoint associated with the current request
        var endpoint = context.GetEndpoint();

        // Check if the endpoint has an [Authorize] attribute
        var authorizeAttribute = endpoint?.Metadata.GetMetadata<AuthorizeAttribute>();
        if (authorizeAttribute != null)
        {
            var permissionExists = await this.permissionService.GetPermission();
            if (permissionExists == null)
            {
                context.Response.StatusCode = 403;
                await context.Response.WriteAsync("Forbidden");
                return;
            }
        }

        await this.next(context);
    }
}