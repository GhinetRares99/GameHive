// <copyright file="IUserService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.UserService;

using GameHive.Models;

/// <summary>
/// An interface for the service for the <see cref="User"/> class.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Retrieves a user's information from the database.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <returns>The user with the specified email address.</returns>
    Task<User?> GetUser(string email);

    /// <summary>
    /// Retrieves a user from the database by username.
    /// </summary>
    /// <param name="username">The user's username.</param>
    /// <returns>The user with the specified usernames.</returns>
    Task<User?> GetUserByUsername(string username);

    /// <summary>
    /// Retrieves a user from the database by id.
    /// </summary>
    /// <param name="id">The user's id.</param>
    /// <returns>The user with the specified id.</returns>
    Task<User?> GetUserById(string id);

    /// <summary>
    /// Adds a user into the database.
    /// </summary>
    /// <param name="user">The new user object.</param>
    /// <returns>A task representing the asynchronous adding of a user.</returns>
    Task<User> RegisterUser(User user);

    /// <summary>
    /// Activates a user.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> ActivateUser(string email);

    /// <summary>
    /// Deletes a user from the database.
    /// </summary>
    /// <param name="email">The email of the user that is supposed to be deleted.</param>
    /// <returns>A task representing the asynchronous adding of a user.</returns>
    Task<bool> DeleteUser(string email);

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A list of all users in the database.</returns>
    Task<List<User>> GetAllUsers();

    /// <summary>
    /// Recovers the user's password.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <param name="newPassword">The user's new password.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> RecoverPassword(string email, string newPassword);

    /// <summary>
    /// Updates a user from the database.
    /// </summary>
    /// <param name="user">The user that will be updated.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> UpdateUser(User user);

    /// <summary>
    /// Deletes a user from the database by id.
    /// </summary>
    /// <param name="id">The user's id.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    Task<bool> DeleteUserById(string id);
}