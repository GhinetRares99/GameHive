// <copyright file="GetTrophiesByGameIdHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Trophy;

using GameHive.Helpers;
using GameHive.Models.Requests.Trophy;
using GameHive.Services.TrophyService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting trophies from the database by game id.
/// </summary>
public class GetTrophiesByGameIdHandler : BaseRequestHandler<GetTrophiesByGameIdRequest>
{
    private readonly ITrophyService trophyService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetTrophiesByGameIdHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="trophyService">The trophy service implementation.</param>
    public GetTrophiesByGameIdHandler(ILogger<GetTrophiesByGameIdHandler> logger, ITrophyService trophyService)
        : base(logger)
    {
        this.trophyService = trophyService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetTrophiesByGameIdRequest request)
    {
        var result = await this.trophyService.GetTrophiesByGameId(request.GameId);
        return result.Count != 0
           ? this.HandleSuccess(string.Format(ConstantValues.GetAllSuccessful, typeof(Models.Trophy).Name), result)
           : this.HandleNotFound(string.Format(ConstantValues.GetAllNotFound, typeof(Models.Trophy).Name));
    }
}