// <copyright file="GetPossessionsByUserIdHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Possession;

using GameHive.Helpers;
using GameHive.Models.Requests.Possession;
using GameHive.Services.PossessionService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting possessions from the database by user id.
/// </summary>
public class GetPossessionsByUserIdHandler : BaseRequestHandler<GetPossessionsByUserIdRequest>
{
    private readonly IPossessionService possessionService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetPossessionsByUserIdHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="possessionService">The possession service implementation.</param>
    public GetPossessionsByUserIdHandler(ILogger<GetPossessionsByUserIdHandler> logger, IPossessionService possessionService)
        : base(logger)
    {
        this.possessionService = possessionService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetPossessionsByUserIdRequest request)
    {
        var result = await this.possessionService.GetPosessionsByUserId(request.UserId);
        return result.Count != 0
           ? this.HandleSuccess(string.Format(ConstantValues.GetAllSuccessful, typeof(Models.Possession).Name), result)
           : this.HandleNotFound(string.Format(ConstantValues.GetAllNotFound, typeof(Models.Possession).Name));
    }
}