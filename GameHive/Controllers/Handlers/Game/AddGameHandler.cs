// <copyright file="AddGameHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Game;

using GameHive.Helpers;
using GameHive.Models.Requests.Game;
using GameHive.Models.Validators.Game;
using GameHive.Services.GameService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for adding a game into the database.
/// </summary>
public class AddGameHandler : BaseRequestHandler<AddGameRequest>
{
    private readonly IGameService gameService;
    private readonly AddGameValidator addGameValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddGameHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="gameService">The game service.</param>
    /// <param name="addGameValidator">The add game validator.</param>
    public AddGameHandler(ILogger<AddGameHandler> logger, IGameService gameService, AddGameValidator addGameValidator)
        : base(logger)
    {
        this.gameService = gameService;
        this.addGameValidator = addGameValidator;
    }

    /// <summary>
    /// Handle the request to add a new game into the database.
    /// </summary>
    /// <param name="request">The request containing the new game's information.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(AddGameRequest request)
    {
        var validationResult = await this.addGameValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "game addition");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        var addedGame = await this.gameService.AddGame(request);

        return this.HandleSuccess(ConstantValues.GameAddedSuccessfully, addedGame);
    }
}