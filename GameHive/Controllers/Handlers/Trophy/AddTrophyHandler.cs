// <copyright file="AddTrophyHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Trophy;

using GameHive.Helpers;
using GameHive.Models.Requests.Trophy;
using GameHive.Models.Validators.Trophy;
using GameHive.Services.TrophyService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for adding a trophy into the database.
/// </summary>
public class AddTrophyHandler : BaseRequestHandler<AddTrophyRequest>
{
    private readonly ITrophyService trophyService;
    private readonly AddTrophyValidator addTrophyValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddTrophyHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="trophyService">The trophy service.</param>
    /// <param name="addTrophyValidator">The add trophy validator.</param>
    public AddTrophyHandler(ILogger<AddTrophyHandler> logger, ITrophyService trophyService, AddTrophyValidator addTrophyValidator)
        : base(logger)
    {
        this.trophyService = trophyService;
        this.addTrophyValidator = addTrophyValidator;
    }

    /// <summary>
    /// Handle the request to add a new trophy into the database.
    /// </summary>
    /// <param name="request">The request containing the information of the new trophy.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(AddTrophyRequest request)
    {
        var validationResult = await this.addTrophyValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "trophy addition");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        var addedTrophy = await this.trophyService.AddTrophy(request);

        return this.HandleSuccess(ConstantValues.TrophyAddedSuccessfully, addedTrophy);
    }
}