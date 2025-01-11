// <copyright file="DeletePossessionsByUserIdHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Possession;

using GameHive.Helpers;
using GameHive.Models.Requests.Possession;
using GameHive.Services.PossessionService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for deleting possessions from the database by user id.
/// </summary>
public class DeletePossessionsByUserIdHandler : BaseRequestHandler<DeletePossessionsByUserIdRequest>
{
    private readonly IPossessionService possessionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeletePossessionsByUserIdHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="possessionService">The possession service implementation.</param>
    public DeletePossessionsByUserIdHandler(ILogger<DeletePossessionsByUserIdHandler> logger, IPossessionService possessionService)
        : base(logger)
    {
        this.possessionService = possessionService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(DeletePossessionsByUserIdRequest request)
    {
        return (await this.possessionService.DeletePossessionsByUserId(request.UserId)) switch
        {
            true => this.HandleSuccess(ConstantValues.TrophiesDeletedSuccessfully, true),
            false => this.HandleBadRequest(ConstantValues.FailedToDeleteTrophies, false),
        };
    }
}