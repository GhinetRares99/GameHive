// <copyright file="IPossessionRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.PossessionRepository;

using GameHive.Models;

/// <summary>
/// Represents an interface for the repository for the <see cref="Possession"/> class.
/// </summary>
public interface IPossessionRepository
{
    /// <summary>
    /// Finds possessions by game id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    Task<List<Possession>> FindPossessionsByGameId(string gameId);

    /// <summary>
    /// Finds possessions by user id.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    Task<List<Possession>> FindPossessionsByUserId(string userId);

    /// <summary>
    /// Deletes possessions by game id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    Task<bool> RemovePossessionsByGameId(string gameId);

    /// <summary>
    /// Deletes possessions by user id.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    Task<bool> RemovePossessionsByUserId(string userId);

    /// <summary>
    /// Find a possession by game id and user id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <param name="userId">The user id.</param>
    /// <returns>The possession with the specified attributes.</returns>
    Task<Possession?> FindPossessionByGameIdAndUserId(string gameId, string userId);
}