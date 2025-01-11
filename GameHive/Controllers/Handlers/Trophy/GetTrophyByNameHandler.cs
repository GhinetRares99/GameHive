// <copyright file="GetTrophyByNameHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Trophy;

using GameHive.Helpers;
using GameHive.Models.Requests.Trophy;
using GameHive.Services.TrophyService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting a trophy from the database by name.
/// </summary>
public class GetTrophyByNameHandler : BaseRequestHandler<GetTrophyByNameRequest>
{
    private readonly ITrophyService trophyService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetTrophyByNameHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="trophyService">The trophy service implementation.</param>
    public GetTrophyByNameHandler(ILogger<GetTrophyByNameHandler> logger, ITrophyService trophyService)
        : base(logger)
    {
        this.trophyService = trophyService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetTrophyByNameRequest request)
    {
        var result = await this.trophyService.GetTrophyByName(request.Name);
        return result != null
            ? this.HandleSuccess(string.Format(ConstantValues.GetSuccessful, typeof(Models.Trophy).Name), result)
            : this.HandleNotFound(string.Format(ConstantValues.GetNotFound, typeof(Models.Trophy).Name, request.Name));
    }
}