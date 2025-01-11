// <copyright file="UpdateUserHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Models.Validators.User;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for updating a user's information.
/// </summary>
public class UpdateUserHandler : BaseRequestHandler<UpdateUserRequest>
{
    private readonly IUserService userService;
    private readonly UpdateUserValidator updateUserValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateUserHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service.</param>
    /// <param name="updateUserValidator">The update user validator.</param>
    public UpdateUserHandler(ILogger<UpdateUserHandler> logger, IUserService userService, UpdateUserValidator updateUserValidator)
        : base(logger)
    {
        this.userService = userService;
        this.updateUserValidator = updateUserValidator;
    }

    /// <summary>
    /// Handle the request to update a user from the database.
    /// </summary>
    /// <param name="request">The request containing the updated information of the user.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(UpdateUserRequest request)
    {
        var validationResult = await this.updateUserValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "user update");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        return (await this.userService.UpdateUser(request)) switch
        {
            true => this.HandleSuccess(ConstantValues.UserUpdatedSuccessfully, true),
            false => this.HandleBadRequest(ConstantValues.UserDoesNotExist, false),
        };
    }
}
