// <copyright file="IPossessionService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.PossessionService;

using GameHive.Models;

/// <summary>
/// An interface for the service for the <see cref="Possession"/> class.
/// </summary>
public interface IPossessionService
{
    /// <summary>
    /// Adds a possession into the database.
    /// </summary>
    /// <param name="possession">The new possession object.</param>
    /// <returns>The possession that has been added.</returns>
    Task<Possession> AddPossession(Possession possession);

    /// <summary>
    /// Retrieves a possession from the database by game id and user id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <param name="userId">The user id.</param>
    /// <returns>The possession with the specified attributes.</returns>
    Task<Possession?> GetPossessionByGameIdAndUserId(string gameId, string userId);

    /// <summary>
    /// Retrieves posessions from the database by game id.
    /// </summary>
    /// <param name="gameId">The id of the game.</param>
    /// <returns>A list of all posessions in the database with the specified game id.</returns>
    Task<List<Possession>> GetPosessionsByGameId(string gameId);

    /// <summary>
    /// Retrieves posessions from the database by user id.
    /// </summary>
    /// <param name="userId">The id of the user.</param>
    /// <returns>A list of all posessions in the database with the specified user id.</returns>
    Task<List<Possession>> GetPosessionsByUserId(string userId);

    /// <summary>
    /// Deletes possessions from the database by game id.
    /// </summary>
    /// <param name="gameId">The id of the game.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> DeletePossessionsByGameId(string gameId);

    /// <summary>
    /// Deletes possessions from the database by user id.
    /// </summary>
    /// <param name="userId">The id of the user.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> DeletePossessionsByUserId(string userId);

    /// <summary>
    /// Deletes a possession from the database.
    /// </summary>
    /// <param name="userId">The id of the user.</param>
    /// <param name="gameId">The id of the game.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> DeletePossession(string userId, string gameId);
}