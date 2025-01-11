// <copyright file="UserService.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.UserService;

using System.Security.Claims;
using GameHive.Helpers;
using GameHive.Models;
using GameHive.Models.Settings;
using GameHive.Services.Repositories.UserRepository;
using Microsoft.Extensions.Options;

/// <summary>
/// Represents the service for the <see cref="User"/> class.
/// </summary>
public class UserService : IUserService
{
    private readonly UserRepository userRepository;
    private readonly IConfiguration configuration;
    private readonly TokenSettings tokenSettings;
    private readonly AuthenticationSettings authenticationSettings;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserService"/> class.
    /// </summary>
    /// <param name="userRepository">The repository for the User class.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="tokenSettingsOptions">The token generation settings.</param>
    /// <param name="authenticationSettingsOptions">The authentication settings.</param>
    public UserService(UserRepository userRepository, IConfiguration configuration, IOptions<TokenSettings> tokenSettingsOptions, IOptions<AuthenticationSettings> authenticationSettingsOptions)
    {
        this.userRepository = userRepository;
        this.configuration = configuration;
        this.tokenSettings = tokenSettingsOptions.Value;
        this.authenticationSettings = authenticationSettingsOptions.Value;
    }

    /// <summary>
    /// Retrieves a user from the database.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <returns>The user with the specified email address.</returns>
    public async Task<User?> GetUser(string email)
    {
        var foundUser = await this.userRepository.FindUserByEmail(email);
        return foundUser;
    }

    /// <summary>
    /// Retrieves a user from the database by username.
    /// </summary>
    /// <param name="username">The user's username.</param>
    /// <returns>The user with the specified username.</returns>
    public async Task<User?> GetUserByUsername(string username)
    {
        var foundUser = await this.userRepository.FindUserByUsername(username);
        return foundUser;
    }

    /// <summary>
    /// Retrieves a user from the database by id.
    /// </summary>
    /// <param name="id">The user's id.</param>
    /// <returns>The user with the specified id.</returns>
    public async Task<User?> GetUserById(string id)
    {
        var foundUser = await this.userRepository.GetByIdAsync(id);
        return foundUser;
    }

    /// <summary>
    /// Adds a user into the database.
    /// </summary>
    /// <param name="user">The new user object.</param>
    /// <returns>The user that has been added.</returns>
    public async Task<User> RegisterUser(User user)
    {
        user.Password = Hasher.HashPassword(user.Password);
        user.Role = this.configuration.GetSection(ConstantValues.DefaultUserRoleSection).Get<string>() ?? string.Empty;
        user.Status = "Inactive";
        user.ActivationToken = GenerateToken.GenerateLinkToken(user.Email, this.tokenSettings.ActivationTokenGenerationKeyValue, this.authenticationSettings, this.configuration, ConstantValues.ActivationExpirationTimeSection);
        user.Balance = 0.00;
        var registeredUser = await this.userRepository.InsertAsync(user);

        return registeredUser;
    }

    /// <summary>
    /// Activates a user.
    /// </summary>
    /// <param name="activationToken">The user activation token.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> ActivateUser(string activationToken)
    {
        var claims = TokenValidation.IsValidActivationTokenAndReturnClaims(activationToken, this.configuration);
        var email = claims[ClaimTypes.Name];

        var foundUser = await this.userRepository.FindUserByEmail(email);
        if (foundUser == null)
        {
            return false;
        }

        foundUser.Status = "Active";
        var updated = await this.userRepository.UpdateAsync(foundUser);

        return updated;
    }

    /// <summary>
    /// Deletes a user from the database.
    /// </summary>
    /// <param name="email">The email of the user that is supposed to be deleted.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteUser(string email)
    {
        var foundUser = await this.userRepository.FindUserByEmail(email);

        if (foundUser == null)
        {
            return false;
        }

        var deleted = await this.userRepository.DeleteAsync(foundUser.Id);

        return deleted;
    }

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <returns>A list of all users in the database.</returns>
    public async Task<List<User>> GetAllUsers()
    {
        var users = await this.userRepository.GetAllAsync();
        return users;
    }

    /// <summary>
    /// Recovers the user's password.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <param name="newPassword">The user's new password.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> RecoverPassword(string email, string newPassword)
    {
        var foundUser = await this.userRepository.FindUserByEmail(email);

        if (foundUser == null)
        {
            return false;
        }

        foundUser.Password = Hasher.HashPassword(newPassword);

        var updated = await this.userRepository.UpdateAsync(foundUser);

        return updated;
    }

    /// <summary>
    /// Updates a user from the database.
    /// </summary>
    /// <param name="user">The user that will be updated.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> UpdateUser(User user)
    {
        var result = await this.userRepository.UpdateAsync(user);
        return result;
    }

    /// <summary>
    /// Deletes a user from the database by id.
    /// </summary>
    /// <param name="id">The user's id.</param>
    /// <returns><c>true</c> if the operation is successful; otherwise, <c>false</c>.</returns>
    public async Task<bool> DeleteUserById(string id)
    {
        var deleted = await this.userRepository.DeleteAsync(id);
        return deleted;
    }
}