// <copyright file="GetUserHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting a user from the database.
/// </summary>
public class GetUserHandler : BaseRequestHandler<GetUserRequest>
{
    private readonly IUserService userService;
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetUserHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service implementation.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public GetUserHandler(ILogger<GetUserHandler> logger, IUserService userService, IHttpContextAccessor httpContextAccessor)
        : base(logger)
    {
        this.userService = userService;
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetUserRequest request)
    {
        var authorizationUserEmail = this.httpContextAccessor.HttpContext?.User.Identity?.Name;
        var result = await this.userService.GetUser(authorizationUserEmail!);
        return result != null
            ? this.HandleSuccess(string.Format(ConstantValues.GetSuccessful, typeof(Models.User).Name), result)
            : this.HandleNotFound(string.Format(ConstantValues.GetNotFound, typeof(Models.User).Name, authorizationUserEmail));
    }
}