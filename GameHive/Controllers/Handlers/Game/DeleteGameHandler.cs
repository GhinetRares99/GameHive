// <copyright file="DeleteGameHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Game;

using GameHive.Controllers.Handlers.User;
using GameHive.Helpers;
using GameHive.Models.Requests.Game;
using GameHive.Services.GameService;
using GameHive.Services.PossessionService;
using GameHive.Services.TrophyService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for deleting a game from the database.
/// </summary>
public class DeleteGameHandler : BaseRequestHandler<DeleteGameRequest>
{
    private readonly IGameService gameService;
    private readonly IPossessionService possessionService;
    private readonly ITrophyService trophyService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteGameHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="gameService">The game service implementation.</param>
    /// <param name="possessionService">The possession service implementation.</param>
    /// <param name="trophyService">The trophy service implementation.</param>
    public DeleteGameHandler(ILogger<DeleteUserHandler> logger, IGameService gameService, IPossessionService possessionService, ITrophyService trophyService)
        : base(logger)
    {
        this.gameService = gameService;
        this.possessionService = possessionService;
        this.trophyService = trophyService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(DeleteGameRequest request)
    {
        var gameDeleted = await this.gameService.DeleteGame(request.Id);
        if (gameDeleted)
        {
            await this.possessionService.DeletePossessionsByGameId(request.Id);
            await this.trophyService.DeleteTrophiesByGameId(request.Id);
            return this.HandleSuccess(ConstantValues.GameDeletedSuccessfully, true);
        }
        else
        {
            return this.HandleBadRequest(ConstantValues.GameDoesNotExist, false);
        }
    }
}