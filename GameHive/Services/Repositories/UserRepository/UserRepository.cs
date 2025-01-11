// <copyright file="UserRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.UserRepository;

using System.Linq.Expressions;
using GameHive.Models;
using MongoDB.Driver;

/// <summary>
/// Represents a repository for <see cref="User"/> class.
/// </summary>
public class UserRepository : GenericRepository<User>, IUserRepository
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public UserRepository(IMongoDatabase database)
        : base(database)
    {
    }

    /// <summary>
    /// Find a user by its email address.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<User?> FindUserByEmail(string email)
    {
        Expression<Func<User, bool>> emailExpression = user => user.Email.Equals(email);
        var filterExpression = new FilterExpression<User>
        {
            Filter = emailExpression,
        };
        return await this.GetOneFilteredAsync(filterExpression);
    }

    /// <summary>
    /// Find a user by its username.
    /// </summary>
    /// <param name="username">The user's username.</param>
    /// <returns>A task that represents the operation and holds the action result.</returns>
    public async Task<User?> FindUserByUsername(string username)
    {
        Expression<Func<User, bool>> usernameExpression = user => user.Username.Equals(username);
        var filterExpression = new FilterExpression<User>
        {
            Filter = usernameExpression,
        };
        return await this.GetOneFilteredAsync(filterExpression);
    }
}