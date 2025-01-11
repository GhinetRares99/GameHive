// <copyright file="ITrophyRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.TrophyRepository;

using GameHive.Models;

/// <summary>
/// Represents an interface for the repository for the <see cref="Trophy"/> class.
/// </summary>
public interface ITrophyRepository
{
    /// <summary>
    /// Find a trophy by its name.
    /// </summary>
    /// <param name="name">The trophy's name.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    Task<Trophy?> FindTrophyByName(string name);

    /// <summary>
    /// Find trophies by game id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    Task<List<Trophy>> FindTrophiesByGameId(string gameId);

    /// <summary>
    /// Deletes trophies by game id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    Task<bool> RemoveTrophiesByGameId(string gameId);
}