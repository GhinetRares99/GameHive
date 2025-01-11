// <copyright file="GetPossessionByGameIdAndUserIdHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Possession;

using GameHive.Controllers.Handlers;
using GameHive.Helpers;
using GameHive.Services.PossessionService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting a possession from the database by game id and user id.
/// </summary>
public class GetPossessionByGameIdAndUserIdHandler : BaseRequestHandler<GetPossessionByGameIdAndUserIdRequest>
{
    private readonly IPossessionService possessionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetPossessionByGameIdAndUserIdHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="possessionService">The possession service implementation.</param>
    public GetPossessionByGameIdAndUserIdHandler(ILogger<GetPossessionByGameIdAndUserIdHandler> logger, IPossessionService possessionService)
        : base(logger)
    {
        this.possessionService = possessionService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetPossessionByGameIdAndUserIdRequest request)
    {
        var result = await this.possessionService.GetPossessionByGameIdAndUserId(request.GameId, request.UserId);
        return result != null
             ? this.HandleSuccess(string.Format(ConstantValues.GetSuccessful, typeof(Models.Possession).Name), result)
             : this.HandleNotFound(ConstantValues.PossessionDoesNotExist);
    }
}