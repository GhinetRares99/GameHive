// <copyright file="TrophyController.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers;

using GameHive.Controllers.Handlers.Trophy;
using GameHive.Models.Requests.Trophy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for operations with the <see cref="Trophy"/> class.
/// </summary>
[Route("api/[controller]")]
public class TrophyController : ControllerBase
{
    /// <summary>
    /// Adds a trophy object into the database.
    /// </summary>
    /// <param name="request">The add trophy request.</param>
    /// <param name="addTrophyHandler">The handler for adding a new trophy into the database.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddTrophy(
        [FromBody] AddTrophyRequest request,
        [FromServices] AddTrophyHandler addTrophyHandler) => await addTrophyHandler.Handle(request);

    /// <summary>
    /// Retrieves the information of the trophy by id.
    /// </summary>
    /// <param name="request">The request containing the trophy id.</param>
    /// <param name="getTrophyByIdHandler">The handler for retrieving the information.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("getById")]
    public async Task<IActionResult> GetTrophyById(
        [FromBody] GetTrophyByIdRequest request,
        [FromServices] GetTrophyByIdHandler getTrophyByIdHandler) => await getTrophyByIdHandler.Handle(request);

    /// <summary>
    /// Retrieves the information of the trophy by name.
    /// </summary>
    /// <param name="request">The request containing the trophy name.</param>
    /// <param name="getTrophyByNameHandler">The handler for retrieving the information.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("getByName")]
    public async Task<IActionResult> GetTrophyByName(
        [FromBody] GetTrophyByNameRequest request,
        [FromServices] GetTrophyByNameHandler getTrophyByNameHandler) => await getTrophyByNameHandler.Handle(request);

    /// <summary>
    /// Retrieves all trophies from the database.
    /// </summary>
    /// <param name="getAllTrophiesHandler">The handler for retrieving the trophies.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllTrophies(
        [FromServices] GetAllTrophiesHandler getAllTrophiesHandler) => await getAllTrophiesHandler.Handle(new GetAllTrophiesRequest());

    /// <summary>
    /// Retrieves trophies from the database by game id.
    /// </summary>
    /// <param name="request">The request containing the game id.</param>
    /// <param name="getTrophiesByGameIdHandler">The handler for retrieving the trophies.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [HttpPost("getByGameId")]
    public async Task<IActionResult> GetTrophiesByGameId(
        [FromBody] GetTrophiesByGameIdRequest request,
        [FromServices] GetTrophiesByGameIdHandler getTrophiesByGameIdHandler) => await getTrophiesByGameIdHandler.Handle(request);

    /// <summary>
    /// Updates a trophy from the database.
    /// </summary>
    /// <param name="request">The request containing the updated information of the trophy.</param>
    /// <param name="updateTrophyHandler">The handler for updating the trophy.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateTrophy(
        [FromBody] UpdateTrophyRequest request,
        [FromServices] UpdateTrophyHandler updateTrophyHandler) => await updateTrophyHandler.Handle(request);

    /// <summary>
    /// Deletes a trophy from the database.
    /// </summary>
    /// <param name="request">The request containing the trophy id.</param>
    /// <param name="deleteTrophyHandler">The handler for deleting the trophy.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteTrophy(
        [FromBody] DeleteTrophyRequest request,
        [FromServices] DeleteTrophyHandler deleteTrophyHandler) => await deleteTrophyHandler.Handle(request);

    /// <summary>
    /// Deletes trophies from the database by game id.
    /// </summary>
    /// <param name="request">The request containing the game id.</param>
    /// <param name="deleteTrophiesByGameIHandler">The handler for deleting the trophies.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpDelete("deleteByGameId")]
    public async Task<IActionResult> DeleteTrophiesByGameId(
        [FromBody] DeleteTrophiesByGameIdRequest request,
        [FromServices] DeleteTrophiesByGameIdHandler deleteTrophiesByGameIHandler) => await deleteTrophiesByGameIHandler.Handle(request);
}