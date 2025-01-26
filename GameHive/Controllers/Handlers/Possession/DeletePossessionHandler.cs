// <copyright file="DeletePossessionHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Possession;

using GameHive.Helpers;
using GameHive.Models.Requests.Possession;
using GameHive.Models.Validators.Possession;
using GameHive.Services.PossessionService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for removing a possession from the database.
/// </summary>
public class DeletePossessionHandler : BaseRequestHandler<DeletePossessionRequest>
{
    private readonly IPossessionService possessionService;
    private readonly DeletePossessionValidator deletePossessionValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeletePossessionHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="possessionService">The possession service.</param>
    /// <param name="deletePossessionValidator">The delete possession validator.</param>
    public DeletePossessionHandler(ILogger<DeletePossessionHandler> logger, IPossessionService possessionService, DeletePossessionValidator deletePossessionValidator)
        : base(logger)
    {
        this.possessionService = possessionService;
        this.deletePossessionValidator = deletePossessionValidator;
    }

    /// <summary>
    /// Handle the request to remove a possession from the database.
    /// </summary>
    /// <param name="request">The request containing the information of the possession.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(DeletePossessionRequest request)
    {
        var validationResult = await this.deletePossessionValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "possession removal");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        var result = await this.possessionService.DeletePossession(request.GameId, request.UserId);

        return this.HandleSuccess(ConstantValues.PossessionRemovedSuccessfully, result);
    }
}