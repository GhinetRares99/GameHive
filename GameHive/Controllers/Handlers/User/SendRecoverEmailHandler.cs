// <copyright file="SendRecoverEmailHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Models.Settings;
using GameHive.Services.Repositories.EmailTemplateRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

/// <summary>
/// Represents a request handler for sending a password recovery email.
/// </summary>
public class SendRecoverEmailHandler : BaseRequestHandler<SendRecoverEmailRequest>
{
    private readonly IConfiguration configuration;
    private readonly EmailTemplateRepository emailTemplateRepository;
    private readonly TokenSettings tokenSettings;
    private readonly AuthenticationSettings authenticationSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="SendRecoverEmailHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="emailTemplateRepository">The email template repository.</param>
    /// <param name="tokenSettingsOptions">The token generation settings.</param>
    /// <param name="authenticationSettingsOptions">The authentication settings.</param>
    public SendRecoverEmailHandler(ILogger<SendRecoverEmailHandler> logger, IConfiguration configuration, EmailTemplateRepository emailTemplateRepository, IOptions<TokenSettings> tokenSettingsOptions, IOptions<AuthenticationSettings> authenticationSettingsOptions)
        : base(logger)
    {
        this.configuration = configuration;
        this.emailTemplateRepository = emailTemplateRepository;
        this.tokenSettings = tokenSettingsOptions.Value;
        this.authenticationSettings = authenticationSettingsOptions.Value;
    }

    /// <summary>
    /// Handle the request to send a password recovery email.
    /// </summary>
    /// <param name="request">The request containing the user's email address.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(SendRecoverEmailRequest request)
    {
        var recoverPasswordToken = GenerateToken.GenerateLinkToken(request.Email, this.tokenSettings.PasswordRecoveryTokenGenerationKeyValue, this.authenticationSettings, this.configuration, ConstantValues.RecoverPasswordExpirationTimeSection);
        var templateParameters = new Dictionary<string, string>
        {
            { "PasswordRecoveryToken", recoverPasswordToken },
        };
        var parameters = JsonConvert.SerializeObject(templateParameters);

        var emailTemplateId = this.configuration.GetSection(ConstantValues.EmailSection).GetValue<string>("RecoverPasswordTemplateId");
        var emailTemplate = await this.emailTemplateRepository.GetByIdAsync(emailTemplateId ?? string.Empty);
        EmailDispatcher.Send(request.Email, parameters, this.configuration, emailTemplate);

        return this.HandleSuccess(ConstantValues.RecoverEmailSent);
    }
}