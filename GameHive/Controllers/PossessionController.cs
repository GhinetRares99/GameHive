// <copyright file="PossessionController.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers;

using GameHive.Controllers.Handlers.Possession;
using GameHive.Models.Requests.Possession;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for operations with the <see cref="Possession"/> class.
/// </summary>
[Route("api/[controller]")]
public class PossessionController : ControllerBase
{
    /// <summary>
    /// Adds a possession object into the database.
    /// </summary>
    /// <param name="request">The add possession request.</param>
    /// <param name="addPossessionHandler">The handler for adding a new possession into the database.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddPossession(
        [FromBody] AddPossessionRequest request,
        [FromServices] AddPossessionHandler addPossessionHandler) => await addPossessionHandler.Handle(request);

    /// <summary>
    /// Retrieves a possession from the database by game id and user id.
    /// </summary>
    /// <param name="request">The get possession request.</param>
    /// <param name="getPossessionByGameIdAndUserIdHandler">The handler for getting the possession from the database.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("getByGameIdAndUserId")]
    public async Task<IActionResult> GetPossessionByGameIdAndUserId(
        [FromBody] GetPossessionByGameIdAndUserIdRequest request,
        [FromServices] GetPossessionByGameIdAndUserIdHandler getPossessionByGameIdAndUserIdHandler) => await getPossessionByGameIdAndUserIdHandler.Handle(request);

    /// <summary>
    /// Retrieves possessions from the database by game id.
    /// </summary>
    /// <param name="request">The get possessions request.</param>
    /// <param name="getPossessionsByGameIdHandler">The handler for getting the possessions from the database.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("getByGameId")]
    public async Task<IActionResult> GetPossessionsByGameId(
        [FromBody] GetPossessionsByGameIdRequest request,
        [FromServices] GetPossessionsByGameIdHandler getPossessionsByGameIdHandler) => await getPossessionsByGameIdHandler.Handle(request);

    /// <summary>
    /// Retrieves possessions from the database by user id.
    /// </summary>
    /// <param name="request">The get possessions request.</param>
    /// <param name="getPossessionsByUserIdHandler">The handler for getting the possessions from the database.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("getByUserId")]
    public async Task<IActionResult> GetPossessionsByUserId(
        [FromBody] GetPossessionsByUserIdRequest request,
        [FromServices] GetPossessionsByUserIdHandler getPossessionsByUserIdHandler) => await getPossessionsByUserIdHandler.Handle(request);

    /// <summary>
    /// Deletes possessions from the database by game id.
    /// </summary>
    /// <param name="request">The delete possessions request.</param>
    /// <param name="deletePossessionsByGameIdHandler">The handler for deleting the possessions from the database.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpDelete("deleteByGameId")]
    public async Task<IActionResult> DeletePossessionsByGameId(
        [FromBody] DeletePossessionsByGameIdRequest request,
        [FromServices] DeletePossessionsByGameIdHandler deletePossessionsByGameIdHandler) => await deletePossessionsByGameIdHandler.Handle(request);

    /// <summary>
    /// Deletes possessions from the database by user id.
    /// </summary>
    /// <param name="request">The delete possessions request.</param>
    /// <param name="deletePossessionsByUserIdHandler">The handler for deleting the possessions from the database.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpDelete("deleteByUserId")]
    public async Task<IActionResult> DeletePossessionsByUserId(
        [FromBody] DeletePossessionsByUserIdRequest request,
        [FromServices] DeletePossessionsByUserIdHandler deletePossessionsByUserIdHandler) => await deletePossessionsByUserIdHandler.Handle(request);
}