// <copyright file="RegisterUserHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Models.Validators.User;
using GameHive.Services.Repositories.EmailTemplateRepository;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

/// <summary>
/// Represents a request handler for adding a new user into the database.
/// </summary>
public class RegisterUserHandler : BaseRequestHandler<RegisterUserRequest>
{
    private readonly RegisterUserValidator registerUserValidator;
    private readonly IConfiguration configuration;
    private readonly IUserService userService;
    private readonly EmailTemplateRepository emailTemplateRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUserHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service.</param>
    /// <param name="registerUserValidator">The registration validator.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="emailTemplateRepository">The email template repository.</param>
    public RegisterUserHandler(ILogger<RegisterUserHandler> logger, IUserService userService, RegisterUserValidator registerUserValidator, IConfiguration configuration, EmailTemplateRepository emailTemplateRepository)
        : base(logger)
    {
        this.userService = userService;
        this.registerUserValidator = registerUserValidator;
        this.configuration = configuration;
        this.emailTemplateRepository = emailTemplateRepository;
    }

    /// <summary>
    /// Handle the request to add a new user into the database.
    /// </summary>
    /// <param name="request">The request containing the new user's information.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(RegisterUserRequest request)
    {
        var validationResult = await this.registerUserValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "user registration");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        var registeredUser = await this.userService.RegisterUser(request);

        var templateParameters = new Dictionary<string, string>
        {
            { "ActivationToken", registeredUser.ActivationToken },
        };
        var parameters = JsonConvert.SerializeObject(templateParameters);

        var emailTemplateId = this.configuration.GetSection(ConstantValues.EmailSection).GetValue<string>("ActivateUserTemplateId");
        var emailTemplate = await this.emailTemplateRepository.GetByIdAsync(emailTemplateId ?? string.Empty);
        EmailDispatcher.Send(registeredUser.Email, parameters, this.configuration, emailTemplate);

        registeredUser.Id = string.Empty;
        registeredUser.Password = string.Empty;
        registeredUser.ActivationToken = string.Empty;

        return this.HandleSuccess(ConstantValues.UserRegisteredSuccessfully, registeredUser);
    }
}