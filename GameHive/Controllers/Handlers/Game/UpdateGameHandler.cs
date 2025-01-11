// <copyright file="UpdateGameHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Game;

using GameHive.Helpers;
using GameHive.Models.Requests.Game;
using GameHive.Models.Validators.Game;
using GameHive.Services.GameService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for updating a game's information.
/// </summary>
public class UpdateGameHandler : BaseRequestHandler<UpdateGameRequest>
{
    private readonly IGameService gameService;
    private readonly UpdateGameValidator updateGameValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateGameHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="gameService">The game service.</param>
    /// <param name="updateGameValidator">The update game validator.</param>
    public UpdateGameHandler(ILogger<UpdateGameHandler> logger, IGameService gameService, UpdateGameValidator updateGameValidator)
        : base(logger)
    {
        this.gameService = gameService;
        this.updateGameValidator = updateGameValidator;
    }

    /// <summary>
    /// Handle the request to update a game from the database.
    /// </summary>
    /// <param name="request">The request containing the updated information of the game.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(UpdateGameRequest request)
    {
        var validationResult = await this.updateGameValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "game update");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        return (await this.gameService.UpdateGame(request)) switch
        {
            true => this.HandleSuccess(ConstantValues.GameUpdatedSuccessfully, true),
            false => this.HandleBadRequest(ConstantValues.GameDoesNotExist, false),
        };
    }
}