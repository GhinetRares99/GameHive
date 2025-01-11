// <copyright file="IGameRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.GameRepository;

using GameHive.Models;

/// <summary>
/// Represents an interface for the repository for the <see cref="Game"/> class.
/// </summary>
public interface IGameRepository
{
    /// <summary>
    /// Find a game by its name.
    /// </summary>
    /// <param name="name">The game's name.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    Task<Game?> FindGameByName(string name);
}