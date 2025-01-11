// <copyright file="IGameService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.GameService;

using GameHive.Models;

/// <summary>
/// An interface for the service for the <see cref="Game"/> class.
/// </summary>
public interface IGameService
{
    /// <summary>
    /// Adds a game into the database.
    /// </summary>
    /// <param name="game">The new game object.</param>
    /// <returns>The game that has been added.</returns>
    Task<Game> AddGame(Game game);

    /// <summary>
    /// Retrieves a game from the database by name.
    /// </summary>
    /// <param name="name">The game's name.</param>
    /// <returns>The game with the specified name.</returns>
    Task<Game?> GetGameByName(string name);

    /// <summary>
    /// Retrieves a game from the database by id.
    /// </summary>
    /// <param name="id">The game's id.</param>
    /// <returns>The game with the specified id.</returns>
    Task<Game?> GetGameById(string id);

    /// <summary>
    /// Retrieves all games from the database.
    /// </summary>
    /// <returns>A list of all games in the database.</returns>
    Task<List<Game>> GetAllGames();

    /// <summary>
    /// Updates a game from the database.
    /// </summary>
    /// <param name="game">The game that will be updated.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> UpdateGame(Game game);

    /// <summary>
    /// Deletes a game from the database.
    /// </summary>
    /// <param name="id">The game's id.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> DeleteGame(string id);
}