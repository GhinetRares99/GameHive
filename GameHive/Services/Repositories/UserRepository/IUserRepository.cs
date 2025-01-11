// <copyright file="IUserRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.UserRepository;

using GameHive.Models;

/// <summary>
/// Represents an interface for the repository for the <see cref="User"/> class.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Find a user by its email address.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <returns>A task representing the asynchronous retrieval of the user's information.</returns>
    Task<User?> FindUserByEmail(string email);

    /// <summary>
    /// Find a user by its username.
    /// </summary>
    /// <param name="username">The user's username.</param>
    /// <returns>A task representing the asynchronous retrieval of the user's information.</returns>
    Task<User?> FindUserByUsername(string username);
}