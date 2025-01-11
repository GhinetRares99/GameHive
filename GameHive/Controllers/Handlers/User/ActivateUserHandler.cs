// <copyright file="ActivateUserHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Models.Validators.User;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for activating a user.
/// </summary>
public class ActivateUserHandler : BaseRequestHandler<ActivateUserRequest>
{
    private readonly IUserService userService;
    private readonly ActivateUserValidator activateUserValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="ActivateUserHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service implementation.</param>
    /// <param name="activateUserValidator">The validator for validating user activation request.</param>
    public ActivateUserHandler(ILogger<ActivateUserHandler> logger, IUserService userService, ActivateUserValidator activateUserValidator)
        : base(logger)
    {
        this.userService = userService;
        this.activateUserValidator = activateUserValidator;
    }

    /// <summary>
    /// Handle the request to activate a user.
    /// </summary>
    /// <param name="request">The request containing the user's activation token.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(ActivateUserRequest request)
    {
        var validationResult = await this.activateUserValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "Activate User");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        var result = await this.userService.ActivateUser(request.ActivationToken);
        return result
            ? this.HandleSuccess(ConstantValues.UserActivatedSuccessfully, result)
            : this.HandleBadRequest(ConstantValues.UserDoesNotExist, result);
    }
}