// <copyright file="AddPossessionHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.Possession;

using GameHive.Helpers;
using GameHive.Models.Requests.Possession;
using GameHive.Models.Validators.Possession;
using GameHive.Services.PossessionService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for adding a possession into the database.
/// </summary>
public class AddPossessionHandler : BaseRequestHandler<AddPossessionRequest>
{
    private readonly IPossessionService possessionService;
    private readonly AddPossessionValidator addPossessionValidator;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddPossessionHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="possessionService">The possession service.</param>
    /// <param name="addPossessionValidator">The add possession validator.</param>
    public AddPossessionHandler(ILogger<AddPossessionHandler> logger, IPossessionService possessionService, AddPossessionValidator addPossessionValidator)
        : base(logger)
    {
        this.possessionService = possessionService;
        this.addPossessionValidator = addPossessionValidator;
    }

    /// <summary>
    /// Handle the request to add a new possession into the database.
    /// </summary>
    /// <param name="request">The request containing the information of the new possession.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(AddPossessionRequest request)
    {
        var validationResult = await this.addPossessionValidator.ValidateAsync(request);
        if (!validationResult.IsValid)
        {
            var message = string.Format(ConstantValues.BadRequestValidation, "possession addition");
            return this.HandleBadRequestValidation(message, validationResult.Errors);
        }

        var addedPossession = await this.possessionService.AddPossession(request);

        return this.HandleSuccess(ConstantValues.PossessionAddedSuccessfully, addedPossession);
    }
}