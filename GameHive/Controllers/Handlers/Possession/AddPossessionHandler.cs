// <copyright file="AddPossessionHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Possession;

using GameHive.Helpers;
using GameHive.Models.Requests.Possession;
using GameHive.Models.Validators.Possession;
using GameHive.Services.GameService;
using GameHive.Services.PossessionService;
using GameHive.Services.Repositories.EmailTemplateRepository;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

/// <summary>
/// Represents a request handler for adding a possession into the database.
/// </summary>
public class AddPossessionHandler : BaseRequestHandler<AddPossessionRequest>
{
    private readonly IPossessionService possessionService;
    private readonly AddPossessionValidator addPossessionValidator;
    private readonly IConfiguration configuration;
    private readonly EmailTemplateRepository emailTemplateRepository;
    private readonly IUserService userService;
    private readonly IGameService gameService;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddPossessionHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="possessionService">The possession service.</param>
    /// <param name="addPossessionValidator">The add possession validator.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="emailTemplateRepository">The email template repository.</param>
    /// <param name="userService">The user service.</param>
    /// <param name="gameService">The game service.</param>
    public AddPossessionHandler(
        ILogger<AddPossessionHandler> logger,
        IPossessionService possessionService,
        AddPossessionValidator addPossessionValidator,
        IConfiguration configuration,
        EmailTemplateRepository emailTemplateRepository,
        IUserService userService,
        IGameService gameService)
        : base(logger)
    {
        this.possessionService = possessionService;
        this.addPossessionValidator = addPossessionValidator;
        this.configuration = configuration;
        this.emailTemplateRepository = emailTemplateRepository;
        this.userService = userService;
        this.gameService = gameService;
    }

    /// <summary>
    /// Handle the request to add a new possession into the database.
    /// </summary>
    /// <param name="request">The request containing the information of the new possession.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(AddPossessionRequest request)
    {
        var validationResult = await this.addPossessionValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "possession addition");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        var addedPossession = await this.possessionService.AddPossession(request);

        var user = await this.userService.GetUserById(addedPossession.UserId);
        var game = await this.gameService.GetGameById(addedPossession.GameId);

        if (user != null && game != null && game.Price > 0)
        {
            var emailTemplateId = this.configuration.GetSection(ConstantValues.EmailSection).GetValue<string>("PurchaseTemplateId");
            var emailTemplate = await this.emailTemplateRepository.GetByIdAsync(emailTemplateId ?? string.Empty);

            var templateParameters = new Dictionary<string, string>
            {
                { "GameName", game.Name },
                { "Price", game.Price.ToString() },
            };
            var parameters = JsonConvert.SerializeObject(templateParameters);

            EmailDispatcher.Send(user.Email, parameters, this.configuration, emailTemplate);
        }

        return this.HandleSuccess(ConstantValues.PossessionAddedSuccessfully, addedPossession);
    }
}