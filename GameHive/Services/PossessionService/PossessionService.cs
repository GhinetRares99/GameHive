// <copyright file="PossessionService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.PossessionService;

using GameHive.Models;
using GameHive.Services.Repositories.PossessionRepository;

/// <summary>
/// Represents the service for the <see cref="Possession"/> class.
/// </summary>
public class PossessionService : IPossessionService
{
    private readonly PossessionRepository possessionRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="PossessionService"/> class.
    /// </summary>
    /// <param name="possessionRepository">The repository for the Possession class.</param>
    public PossessionService(PossessionRepository possessionRepository)
    {
        this.possessionRepository = possessionRepository;
    }

    /// <summary>
    /// Adds a possession into the database.
    /// </summary>
    /// <param name="possession">The new possession object.</param>
    /// <returns>The possession that has been added.</returns>
    public async Task<Possession> AddPossession(Possession possession)
    {
        var addedPossession = await this.possessionRepository.InsertAsync(possession);
        return addedPossession;
    }

    /// <summary>
    /// Retrieves a possession from the database by game id and user id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <param name="userId">The user id.</param>
    /// <returns>The possession with the specified attributes.</returns>
    public async Task<Possession?> GetPossessionByGameIdAndUserId(string gameId, string userId)
    {
        var possession = await this.possessionRepository.FindPossessionByGameIdAndUserId(gameId, userId);
        return possession;
    }

    /// <summary>
    /// Retrieves posessions from the database by game id.
    /// </summary>
    /// <param name="gameId">The id of the game.</param>
    /// <returns>A list of all posessions in the database with the specified game id.</returns>
    public async Task<List<Possession>> GetPosessionsByGameId(string gameId)
    {
        var possessions = await this.possessionRepository.FindPossessionsByGameId(gameId);
        return possessions;
    }

    /// <summary>
    /// Retrieves posessions from the database by user id.
    /// </summary>
    /// <param name="userId">The id of the user.</param>
    /// <returns>A list of all posessions in the database with the specified user id.</returns>
    public async Task<List<Possession>> GetPosessionsByUserId(string userId)
    {
        var possessions = await this.possessionRepository.FindPossessionsByUserId(userId);
        return possessions;
    }

    /// <summary>
    /// Deletes possessions from the database by game id.
    /// </summary>
    /// <param name="gameId">The id of the game.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeletePossessionsByGameId(string gameId)
    {
        var result = await this.possessionRepository.RemovePossessionsByGameId(gameId);
        return result;
    }

    /// <summary>
    /// Deletes possessions from the database by user id.
    /// </summary>
    /// <param name="userId">The id of the user.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeletePossessionsByUserId(string userId)
    {
        var result = await this.possessionRepository.RemovePossessionsByUserId(userId);
        return result;
    }

    /// <summary>
    /// Deletes a possession from the database.
    /// </summary>
    /// <param name="userId">The id of the user.</param>
    /// <param name="gameId">The id of the game.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeletePossession(string userId, string gameId)
    {
        var possessionToDelete = await this.possessionRepository.FindPossessionByGameIdAndUserId(userId, gameId);
        if (possessionToDelete == null)
        {
            return false;
        }

        var result = await this.possessionRepository.DeleteAsync(possessionToDelete.Id);
        return result;
    }
}