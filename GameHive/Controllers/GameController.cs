// <copyright file="GameController.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers;

using GameHive.Controllers.Handlers.Game;
using GameHive.Models.Requests.Game;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for operations with the <see cref="Game"/> class.
/// </summary>
[Route("api/[controller]")]
public class GameController : ControllerBase
{
    /// <summary>
    /// Adds a game object into the database.
    /// </summary>
    /// <param name="request">The add game request.</param>
    /// <param name="addGameHandler">The handler for adding a new game into the database.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("add")]
    public async Task<IActionResult> AddGame(
        [FromBody] AddGameRequest request,
        [FromServices] AddGameHandler addGameHandler) => await addGameHandler.Handle(request);

    /// <summary>
    /// Retrieves the game's information by id.
    /// </summary>
    /// <param name="request">The request containing the game id.</param>
    /// <param name="getGameByIdHandler">The handler for retrieving the information.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("getById")]
    public async Task<IActionResult> GetGameById(
        [FromBody] GetGameByIdRequest request,
        [FromServices] GetGameByIdHandler getGameByIdHandler) => await getGameByIdHandler.Handle(request);

    /// <summary>
    /// Retrieves the game's information by name.
    /// </summary>
    /// <param name="request">The request containing the game name.</param>
    /// <param name="getGameByNameHandler">The handler for retrieving the information.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [HttpPost("getByName")]
    public async Task<IActionResult> GetGameByName(
        [FromBody] GetGameByNameRequest request,
        [FromServices] GetGameByNameHandler getGameByNameHandler) => await getGameByNameHandler.Handle(request);

    /// <summary>
    /// Retrieves all games from the database.
    /// </summary>
    /// <param name="getAllGamesHandler">The handler for retrieving the games.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllGames(
        [FromServices] GetAllGamesHandler getAllGamesHandler) => await getAllGamesHandler.Handle(new GetAllGamesRequest());

    /// <summary>
    /// Updates a game from the database.
    /// </summary>
    /// <param name="request">The request containing the game's updated information.</param>
    /// <param name="updateGameHandler">The handler for updating the game.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateGame(
        [FromBody] UpdateGameRequest request,
        [FromServices] UpdateGameHandler updateGameHandler) => await updateGameHandler.Handle(request);

    /// <summary>
    /// Deletes a game from the database.
    /// </summary>
    /// <param name="request">The request containing the game id.</param>
    /// <param name="deleteGameHandler">The handler for deleting the game.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteGame(
        [FromBody] DeleteGameRequest request,
        [FromServices] DeleteGameHandler deleteGameHandler) => await deleteGameHandler.Handle(request);
}