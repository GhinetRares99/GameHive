// <copyright file="DeleteUserHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.PossessionService;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for deleting a user from the database.
/// </summary>
public class DeleteUserHandler : BaseRequestHandler<DeleteUserRequest>
{
    private readonly IUserService userService;
    private readonly IPossessionService possessionService;
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteUserHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service implementation.</param>
    /// <param name="possessionService">The  possession service implementation.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public DeleteUserHandler(ILogger<DeleteUserHandler> logger, IUserService userService, IHttpContextAccessor httpContextAccessor, IPossessionService possessionService)
        : base(logger)
    {
        this.userService = userService;
        this.possessionService = possessionService;
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(DeleteUserRequest request)
    {
        var authorizationUserEmail = this.httpContextAccessor.HttpContext?.User.Identity?.Name;
        var user = await this.userService.GetUser(authorizationUserEmail!);

        var deletedUser = await this.userService.DeleteUser(authorizationUserEmail!);
        if (deletedUser)
        {
            await this.possessionService.DeletePossessionsByUserId(user!.Id);
            return this.HandleSuccess(ConstantValues.UserDeletedSuccessfully, true);
        }
        else
        {
            return this.HandleBadRequest(ConstantValues.UserDoesNotExist, false);
        }
    }
}