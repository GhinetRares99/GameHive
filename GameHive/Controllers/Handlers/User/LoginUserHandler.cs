// <copyright file="LoginUserHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Models.Settings;
using GameHive.Models.Validators.User;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

/// <summary>
/// Represents a request handler for logging in a user.
/// </summary>
public class LoginUserHandler : BaseRequestHandler<LoginUserRequest>
{
    private readonly IHttpContextAccessor httpContextAccessor;
    private readonly IUserService userService;
    private readonly LoginUserValidator loginUserValidator;
    private readonly TokenSettings tokenSettings;
    private readonly AuthenticationSettings authenticationSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginUserHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="tokenSettingsOptions">The token generation settings.</param>
    /// <param name="authenticationSettingsOptions">The authentication settings.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    /// <param name="userService">The user service implementation.</param>
    /// <param name="loginUserValidator">The validator for the login process.</param>
    public LoginUserHandler(
        ILogger<LoginUserHandler> logger,
        IOptions<TokenSettings> tokenSettingsOptions,
        IOptions<AuthenticationSettings> authenticationSettingsOptions,
        IHttpContextAccessor httpContextAccessor,
        UserService userService,
        LoginUserValidator loginUserValidator)
        : base(logger)
    {
        this.tokenSettings = tokenSettingsOptions.Value;
        this.authenticationSettings = authenticationSettingsOptions.Value;
        this.httpContextAccessor = httpContextAccessor;
        this.loginUserValidator = loginUserValidator;
        this.userService = userService;
    }

    /// <summary>
    /// Handle the request to log in the user.
    /// </summary>
    /// <param name="request">The request containing the user's email and password.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(LoginUserRequest request)
    {
        var validationResult = await this.loginUserValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "Login User");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        var foundUser = await this.userService.GetUser(request.Email);
        if (foundUser == null)
        {
            return this.HandleBadRequest(ConstantValues.IncorrectEmailOrPassword);
        }

        var token = GenerateToken.Generate(foundUser, this.tokenSettings, this.authenticationSettings);
        this.httpContextAccessor.HttpContext?.Response.Headers.Add("Authorization", "Bearer " + token);

        return this.HandleSuccess(ConstantValues.LoginSuccessful, foundUser);
    }
}