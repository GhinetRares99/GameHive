// <copyright file="DeleteTrophiesByGameIdHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Trophy;

using GameHive.Helpers;
using GameHive.Models.Requests.Trophy;
using GameHive.Services.TrophyService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for deleting trophies from the database by game id.
/// </summary>
public class DeleteTrophiesByGameIdHandler : BaseRequestHandler<DeleteTrophiesByGameIdRequest>
{
    private readonly ITrophyService trophyService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteTrophiesByGameIdHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="trophyService">The trophy service implementation.</param>
    public DeleteTrophiesByGameIdHandler(ILogger<DeleteTrophiesByGameIdHandler> logger, ITrophyService trophyService)
        : base(logger)
    {
        this.trophyService = trophyService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(DeleteTrophiesByGameIdRequest request)
    {
        return (await this.trophyService.DeleteTrophiesByGameId(request.GameId)) switch
        {
           true => this.HandleSuccess(ConstantValues.TrophiesDeletedSuccessfully, true),
           false => this.HandleBadRequest(ConstantValues.FailedToDeleteTrophies, false),
        };
    }
}