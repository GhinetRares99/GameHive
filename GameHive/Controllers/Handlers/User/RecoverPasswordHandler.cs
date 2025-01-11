// <copyright file="RecoverPasswordHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Models.Validators.User;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for recovering the user's password.
/// </summary>
public class RecoverPasswordHandler : BaseRequestHandler<RecoverPasswordRequest>
{
    private readonly IUserService userService;
    private readonly RecoverPasswordValidator recoverPasswordValidator;
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="RecoverPasswordHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service implementation.</param>
    /// <param name="recoverPasswordValidator">The validator for the password recovery process.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public RecoverPasswordHandler(ILogger<RecoverPasswordHandler> logger, IUserService userService, RecoverPasswordValidator recoverPasswordValidator, IHttpContextAccessor httpContextAccessor)
        : base(logger)
    {
        this.userService = userService;
        this.recoverPasswordValidator = recoverPasswordValidator;
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Handle the request to recover the user's password.
    /// </summary>
    /// <param name="request">The request containing the user's new password.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(RecoverPasswordRequest request)
    {
        var authorizationUserEmail = this.httpContextAccessor.HttpContext?.User.Identity?.Name;
        var validationResult = await this.recoverPasswordValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "password recover");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        return (await this.userService.RecoverPassword(authorizationUserEmail!, request.NewPassword)) switch
        {
            true => this.HandleSuccess(ConstantValues.PasswordUpdatedSuccessfully, true),
            false => this.HandleBadRequest(ConstantValues.UserDoesNotExist, false),
        };
    }
}