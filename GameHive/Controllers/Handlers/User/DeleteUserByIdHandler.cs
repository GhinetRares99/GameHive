// <copyright file="DeleteUserByIdHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.PossessionService;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for deleting a user from the database by id.
/// </summary>
public class DeleteUserByIdHandler : BaseRequestHandler<DeleteUserByIdRequest>
{
    private readonly IUserService userService;
    private readonly IPossessionService possessionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteUserByIdHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service implementation.</param>
    /// <param name="possessionService">The possession service implementation.</param>
    public DeleteUserByIdHandler(ILogger<DeleteUserByIdHandler> logger, IUserService userService, IPossessionService possessionService)
        : base(logger)
    {
        this.userService = userService;
        this.possessionService = possessionService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(DeleteUserByIdRequest request)
    {
        var deletedUser = await this.userService.DeleteUserById(request.Id);
        if (deletedUser)
        {
            await this.possessionService.DeletePossessionsByUserId(request.Id);
            return this.HandleSuccess(ConstantValues.UserDeletedSuccessfully, true);
        }
        else
        {
            return this.HandleBadRequest(ConstantValues.UserDoesNotExist, false);
        }
    }
}
