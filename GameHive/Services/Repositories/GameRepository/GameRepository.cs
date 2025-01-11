// <copyright file="GameRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.GameRepository;

using System.Linq.Expressions;
using GameHive.Models;
using MongoDB.Driver;

/// <summary>
/// Represents a repository for <see cref="Game"/> class.
/// </summary>
public class GameRepository : GenericRepository<Game>, IGameRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GameRepository"/> class.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public GameRepository(IMongoDatabase database)
        : base(database)
    {
    }

    /// <summary>
    /// Find a game by its name.
    /// </summary>
    /// <param name="name">The game's name.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<Game?> FindGameByName(string name)
    {
        Expression<Func<Game, bool>> nameExpression = game => game.Name.Equals(name);
        var filterExpression = new FilterExpression<Game>
        {
            Filter = nameExpression,
        };
        return await this.GetOneFilteredAsync(filterExpression);
    }
}