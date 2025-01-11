// <copyright file="TrophyService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.TrophyService;

using GameHive.Models;
using GameHive.Services.Repositories.TrophyRepository;

/// <summary>
/// Represents the service for the <see cref="Trophy"/> class.
/// </summary>
public class TrophyService : ITrophyService
{
    private readonly TrophyRepository trophyRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="TrophyService"/> class.
    /// </summary>
    /// <param name="trophyRepository">The repository for the Trophy class.</param>
    public TrophyService(TrophyRepository trophyRepository)
    {
        this.trophyRepository = trophyRepository;
    }

    /// <summary>
    /// Adds a trophy into the database.
    /// </summary>
    /// <param name="trophy">The new trophy object.</param>
    /// <returns>The trophy that has been added.</returns>
    public async Task<Trophy> AddTrophy(Trophy trophy)
    {
        var addedTrophy = await this.trophyRepository.InsertAsync(trophy);
        return addedTrophy;
    }

    /// <summary>
    /// Retrieves a trophy from the database by name.
    /// </summary>
    /// <param name="name">The name of the trophy.</param>
    /// <returns>The trophy with the specified name.</returns>
    public async Task<Trophy?> GetTrophyByName(string name)
    {
        var foundTrophy = await this.trophyRepository.FindTrophyByName(name);
        return foundTrophy;
    }

    /// <summary>
    /// Retrieves a trophy from the database by id.
    /// </summary>
    /// <param name="id">The id of the trophy.</param>
    /// <returns>The trophy with the specified id.</returns>
    public async Task<Trophy?> GetTrophyById(string id)
    {
        var foundTrophy = await this.trophyRepository.GetByIdAsync(id);
        return foundTrophy;
    }

    /// <summary>
    /// Retrieves all trophies from the database.
    /// </summary>
    /// <returns>A list of all trophies in the database.</returns>
    public async Task<List<Trophy>> GetAllTrophies()
    {
        var trophies = await this.trophyRepository.GetAllAsync();
        return trophies;
    }

    /// <summary>
    /// Retrieves all trophies from the database by game id.
    /// </summary>
    /// <param name="gameId">The id of the game.</param>
    /// <returns>A list of all trophies in the database with the specified game id.</returns>
    public async Task<List<Trophy>> GetTrophiesByGameId(string gameId)
    {
        var trophies = await this.trophyRepository.FindTrophiesByGameId(gameId);
        return trophies;
    }

    /// <summary>
    /// Updates a trophy from the database.
    /// </summary>
    /// <param name="trophy">The trophy that will be updated.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> UpdateTrophy(Trophy trophy)
    {
        var result = await this.trophyRepository.UpdateAsync(trophy);
        return result;
    }

    /// <summary>
    /// Deletes a trophy from the database.
    /// </summary>
    /// <param name="id">The id of the trophy.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteTrophy(string id)
    {
        var result = await this.trophyRepository.DeleteAsync(id);
        return result;
    }

    /// <summary>
    /// Deletes trophies from the database by game id.
    /// </summary>
    /// <param name="gameId">The id of the game.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteTrophiesByGameId(string gameId)
    {
        var result = await this.trophyRepository.RemoveTrophiesByGameId(gameId);
        return result;
    }
}