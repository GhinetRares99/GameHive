// <copyright file="GetGameByIdHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Game;

using GameHive.Controllers.Handlers.User;
using GameHive.Helpers;
using GameHive.Models.Requests.Game;
using GameHive.Services.GameService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting a game from the database by id.
/// </summary>
public class GetGameByIdHandler : BaseRequestHandler<GetGameByIdRequest>
{
    private readonly IGameService gameService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetGameByIdHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="gameService">The game service implementation.</param>
    public GetGameByIdHandler(ILogger<GetUserByIdHandler> logger, IGameService gameService)
        : base(logger)
    {
        this.gameService = gameService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetGameByIdRequest request)
    {
        var result = await this.gameService.GetGameById(request.Id);
        return result != null
            ? this.HandleSuccess(string.Format(ConstantValues.GetSuccessful, typeof(Models.Game).Name), result)
            : this.HandleNotFound(string.Format(ConstantValues.GetNotFound, typeof(Models.Game).Name, request.Id));
    }
}