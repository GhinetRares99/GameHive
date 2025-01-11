// <copyright file="ITrophyService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.TrophyService;

using GameHive.Models;

/// <summary>
/// An interface for the service for the <see cref="Trophy"/> class.
/// </summary>
public interface ITrophyService
{
    /// <summary>
    /// Adds a trophy into the database.
    /// </summary>
    /// <param name="trophy">The new trophy object.</param>
    /// <returns>The trophy that has been added.</returns>
    Task<Trophy> AddTrophy(Trophy trophy);

    /// <summary>
    /// Retrieves a trophy from the database by name.
    /// </summary>
    /// <param name="name">The name of the trophy.</param>
    /// <returns>The trophy with the specified name.</returns>
    Task<Trophy?> GetTrophyByName(string name);

    /// <summary>
    /// Retrieves a trophy from the database by id.
    /// </summary>
    /// <param name="id">The id of the trophy.</param>
    /// <returns>The trophy with the specified id.</returns>
    Task<Trophy?> GetTrophyById(string id);

    /// <summary>
    /// Retrieves all trophies from the database.
    /// </summary>
    /// <returns>A list of all trophies in the database.</returns>
    Task<List<Trophy>> GetAllTrophies();

    /// <summary>
    /// Retrieves all trophies from the database by game id.
    /// </summary>
    /// <param name="gameId">The id of the game.</param>
    /// <returns>A list of all trophies in the database with the specified game id.</returns>
    Task<List<Trophy>> GetTrophiesByGameId(string gameId);

    /// <summary>
    /// Updates a trophy from the database.
    /// </summary>
    /// <param name="trophy">The trophy that will be updated.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> UpdateTrophy(Trophy trophy);

    /// <summary>
    /// Deletes a trophy from the database.
    /// </summary>
    /// <param name="id">The id of the trophy.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> DeleteTrophy(string id);

    /// <summary>
    /// Deletes trophies from the database by game id.
    /// </summary>
    /// <param name="gameId">The id of the game.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> DeleteTrophiesByGameId(string gameId);
}