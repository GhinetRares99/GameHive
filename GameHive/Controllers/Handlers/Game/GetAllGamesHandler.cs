// <copyright file="GetAllGamesHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Game;

using GameHive.Helpers;
using GameHive.Models.Requests.Game;
using GameHive.Services.GameService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting all the games from the database.
/// </summary>
public class GetAllGamesHandler : BaseRequestHandler<GetAllGamesRequest>
{
    private readonly IGameService gameService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllGamesHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="gameService">The game service implementation.</param>
    public GetAllGamesHandler(ILogger<GetAllGamesHandler> logger, IGameService gameService)
        : base(logger)
    {
        this.gameService = gameService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetAllGamesRequest request)
    {
        var result = await this.gameService.GetAllGames();
        return result.Count != 0
           ? this.HandleSuccess(string.Format(ConstantValues.GetAllSuccessful, typeof(Models.Game).Name), result)
           : this.HandleNotFound(string.Format(ConstantValues.GetAllNotFound, typeof(Models.Game).Name));
    }
}