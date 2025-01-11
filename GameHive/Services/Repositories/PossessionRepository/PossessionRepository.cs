// <copyright file="PossessionRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.PossessionRepository;

using System.Linq.Expressions;
using GameHive.Models;
using MongoDB.Driver;

/// <summary>
/// Represents a repository for <see cref="Possession"/> class.
/// </summary>
public class PossessionRepository : GenericRepository<Possession>, IPossessionRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PossessionRepository"/> class.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public PossessionRepository(IMongoDatabase database)
        : base(database)
    {
    }

    /// <summary>
    /// Finds possessions by game id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<List<Possession>> FindPossessionsByGameId(string gameId)
    {
        Expression<Func<Possession, bool>> gameIdExpression = possession => possession.GameId.Equals(gameId);
        var filterExpression = new FilterExpression<Possession>
        {
            Filter = gameIdExpression,
        };
        return await this.GetFilteredAsync(filterExpression);
    }

    /// <summary>
    /// Finds possessions by user id.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<List<Possession>> FindPossessionsByUserId(string userId)
    {
        Expression<Func<Possession, bool>> userIdExpression = possession => possession.UserId.Equals(userId);
        var filterExpression = new FilterExpression<Possession>
        {
            Filter = userIdExpression,
        };
        return await this.GetFilteredAsync(filterExpression);
    }

    /// <summary>
    /// Deletes possessions by game id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<bool> RemovePossessionsByGameId(string gameId)
    {
        Expression<Func<Possession, bool>> gameIdExpression = possession => possession.GameId.Equals(gameId);
        return await this.DeleteMultipleAsync(gameIdExpression);
    }

    /// <summary>
    /// Deletes possessions by user id.
    /// </summary>
    /// <param name="userId">The user id.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<bool> RemovePossessionsByUserId(string userId)
    {
        Expression<Func<Possession, bool>> userIdExpression = possession => possession.UserId.Equals(userId);
        return await this.DeleteMultipleAsync(userIdExpression);
    }

    /// <summary>
    /// Find a possession by game id and user id.
    /// </summary>
    /// <param name="gameId">The game id.</param>
    /// <param name="userId">The user id.</param>
    /// <returns>The possession with the specified attributes.</returns>
    public async Task<Possession?> FindPossessionByGameIdAndUserId(string gameId, string userId)
    {
        Expression<Func<Possession, bool>> possessionGameIdAndUserIdExpression = possession =>
            possession.GameId.Equals(gameId) && possession.UserId.Equals(userId);

        var filterExpression = new FilterExpression<Possession>
        {
            Filter = possessionGameIdAndUserIdExpression,
        };

        return await this.GetOneFilteredAsync(filterExpression);
    }
}