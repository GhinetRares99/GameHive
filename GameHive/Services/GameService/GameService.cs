// <copyright file="GameService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.GameService;

using GameHive.Models;
using GameHive.Services.Repositories.GameRepository;

/// <summary>
/// Represents the service for the <see cref="Game"/> class.
/// </summary>
public class GameService : IGameService
{
    private readonly GameRepository gameRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="GameService"/> class.
    /// </summary>
    /// <param name="gameRepository">The repository for the Game class.</param>
    public GameService(GameRepository gameRepository)
    {
        this.gameRepository = gameRepository;
    }

    /// <summary>
    /// Adds a game into the database.
    /// </summary>
    /// <param name="game">The new game object.</param>
    /// <returns>The game that has been added.</returns>
    public async Task<Game> AddGame(Game game)
    {
        var addedGame = await this.gameRepository.InsertAsync(game);
        return addedGame;
    }

    /// <summary>
    /// Retrieves a game from the database by name.
    /// </summary>
    /// <param name="name">The game's name.</param>
    /// <returns>The game with the specified name.</returns>
    public async Task<Game?> GetGameByName(string name)
    {
        var foundGame = await this.gameRepository.FindGameByName(name);
        return foundGame;
    }

    /// <summary>
    /// Retrieves a game from the database by id.
    /// </summary>
    /// <param name="id">The game's id.</param>
    /// <returns>The game with the specified id.</returns>
    public async Task<Game?> GetGameById(string id)
    {
        var foundGame = await this.gameRepository.GetByIdAsync(id);
        return foundGame;
    }

    /// <summary>
    /// Retrieves all games from the database.
    /// </summary>
    /// <returns>A list of all games in the database.</returns>
    public async Task<List<Game>> GetAllGames()
    {
        var games = await this.gameRepository.GetAllAsync();
        return games;
    }

    /// <summary>
    /// Updates a game from the database.
    /// </summary>
    /// <param name="game">The game that will be updated.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> UpdateGame(Game game)
    {
        var result = await this.gameRepository.UpdateAsync(game);
        return result;
    }

    /// <summary>
    /// Deletes a game from the database.
    /// </summary>
    /// <param name="id">The game's id.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteGame(string id)
    {
        var result = await this.gameRepository.DeleteAsync(id);
        return result;
    }
}