// <copyright file="TrophyRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.TrophyRepository;

using System.Linq.Expressions;
using GameHive.Models;
using MongoDB.Driver;

/// <summary>
/// Represents a repository for <see cref="Trophy"/> class.
/// </summary>
public class TrophyRepository : GenericRepository<Trophy>, ITrophyRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TrophyRepository"/> class.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public TrophyRepository(IMongoDatabase database)
        : base(database)
    {
    }

    /// <summary>
    /// Find a trophy by its name.
    /// </summary>
    /// <param name="name">The trophy's name.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<Trophy?> FindTrophyByName(string name)
    {
        Expression<Func<Trophy, bool>> nameExpression = trophy => trophy.Name.Equals(name);
        var filterExpression = new FilterExpression<Trophy>
        {
            Filter = nameExpression,
        };
        return await this.GetOneFilteredAsync(filterExpression);
    }

    /// <summary>
    /// Find trophies by game id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<List<Trophy>> FindTrophiesByGameId(string gameId)
    {
        Expression<Func<Trophy, bool>> gameIdExpression = trophy => trophy.GameId.Equals(gameId);
        var filterExpression = new FilterExpression<Trophy>
        {
            Filter = gameIdExpression,
        };
        return await this.GetFilteredAsync(filterExpression);
    }

    /// <summary>
    /// Deletes trophies by game id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<bool> RemoveTrophiesByGameId(string gameId)
    {
        Expression<Func<Trophy, bool>> gameIdExpression = trophy => trophy.GameId.Equals(gameId);
        return await this.DeleteMultipleAsync(gameIdExpression);
    }
}