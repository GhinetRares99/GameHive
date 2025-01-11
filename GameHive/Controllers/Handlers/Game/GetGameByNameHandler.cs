// <copyright file="GetGameByNameHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Game;

using GameHive.Helpers;
using GameHive.Models.Requests.Game;
using GameHive.Services.GameService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting a game from the database by name.
/// </summary>
public class GetGameByNameHandler : BaseRequestHandler<GetGameByNameRequest>
{
    private readonly IGameService gameService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetGameByNameHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="gameService">The game service implementation.</param>
    public GetGameByNameHandler(ILogger<GetGameByNameHandler> logger, IGameService gameService)
        : base(logger)
    {
        this.gameService = gameService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetGameByNameRequest request)
    {
        var result = await this.gameService.GetGameByName(request.Name);
        return result != null
            ? this.HandleSuccess(string.Format(ConstantValues.GetSuccessful, typeof(Models.Game).Name), result)
            : this.HandleNotFound(string.Format(ConstantValues.GetNotFound, typeof(Models.Game).Name, request.Name));
    }
}