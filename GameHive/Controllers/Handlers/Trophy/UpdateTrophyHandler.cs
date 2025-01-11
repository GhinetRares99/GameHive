// <copyright file="UpdateTrophyHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Trophy;

using GameHive.Helpers;
using GameHive.Models.Requests.Trophy;
using GameHive.Models.Validators.Trophy;
using GameHive.Services.TrophyService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for updating the information of a trophy.
/// </summary>
public class UpdateTrophyHandler : BaseRequestHandler<UpdateTrophyRequest>
{
    private readonly ITrophyService trophyService;
    private readonly UpdateTrophyValidator updateTrophyValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateTrophyHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="trophyService">The trophy service.</param>
    /// <param name="updateTrophyValidator">The update trophy validator.</param>
    public UpdateTrophyHandler(ILogger<UpdateTrophyHandler> logger, ITrophyService trophyService, UpdateTrophyValidator updateTrophyValidator)
        : base(logger)
    {
        this.trophyService = trophyService;
        this.updateTrophyValidator = updateTrophyValidator;
    }

    /// <summary>
    /// Handle the request to update a trophy from the database.
    /// </summary>
    /// <param name="request">The request containing the updated information of the game.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(UpdateTrophyRequest request)
    {
        var validationResult = await this.updateTrophyValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "trophy update");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        return (await this.trophyService.UpdateTrophy(request)) switch
        {
            true => this.HandleSuccess(ConstantValues.TrophyUpdatedSuccessfully, true),
            false => this.HandleBadRequest(ConstantValues.TrophyDoesNotExist, false),
        };
    }
}