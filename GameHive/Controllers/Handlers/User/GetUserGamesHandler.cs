// <copyright file="GetUserGamesHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Models.Requests.User;
using GameHive.Services.GameService;
using GameHive.Services.PossessionService;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for retrieving the games owned by the user.
/// </summary>
public class GetUserGamesHandler : BaseRequestHandler<GetUserGamesRequest>
{
    private readonly IUserService userService;
    private readonly IPossessionService possessionService;
    private readonly IGameService gameService;
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetUserGamesHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service implementation.</param>
    /// <param name="possessionService">The possession service implementation.</param>
    /// <param name="gameService">The game service implementation.</param>
    /// <param name="httpContextAccessor">The HTTP context accessor.</param>
    public GetUserGamesHandler(ILogger<GetUserGamesHandler> logger, IUserService userService, IPossessionService possessionService, IGameService gameService, IHttpContextAccessor httpContextAccessor)
        : base(logger)
    {
        this.userService = userService;
        this.possessionService = possessionService;
        this.gameService = gameService;
        this.httpContextAccessor = httpContextAccessor;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetUserGamesRequest request)
    {
        var authorizationUserEmail = this.httpContextAccessor.HttpContext?.User.Identity?.Name;
        var user = await this.userService.GetUser(authorizationUserEmail!);

        var gameList = new List<Models.Game>();

        var possessions = await this.possessionService.GetPosessionsByUserId(user!.Id);
        foreach (var p in possessions)
        {
            var game = await this.gameService.GetGameById(p.GameId);
            if (game != null)
            {
                gameList.Add(game);
            }
        }

        return new JsonResult(gameList);
    }
}