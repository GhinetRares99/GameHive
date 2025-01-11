// <copyright file="DeleteTrophyHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Trophy;

using GameHive.Helpers;
using GameHive.Models.Requests.Trophy;
using GameHive.Services.TrophyService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for deleting a trophy from the database.
/// </summary>
public class DeleteTrophyHandler : BaseRequestHandler<DeleteTrophyRequest>
{
    private readonly ITrophyService trophyService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteTrophyHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="trophyService">The trophy service implementation.</param>
    public DeleteTrophyHandler(ILogger<DeleteTrophyHandler> logger, ITrophyService trophyService)
        : base(logger)
    {
        this.trophyService = trophyService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(DeleteTrophyRequest request)
    {
        return (await this.trophyService.DeleteTrophy(request.Id)) switch
        {
            true => this.HandleSuccess(ConstantValues.TrophyDeletedSuccessfully, true),
            false => this.HandleBadRequest(ConstantValues.TrophyDoesNotExist, false),
        };
    }
}