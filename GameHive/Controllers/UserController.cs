// <copyright file="UserController.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers;

using GameHive.Controllers.Handlers.User;
using GameHive.Models.Requests.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for operations with the <see cref="User"/> class.
/// </summary>
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    /// <summary>
    /// Adds a user object into the database.
    /// </summary>
    /// <param name="request">The user registration request.</param>
    /// <param name="registerUserHandler">The handler for adding a new user into the database.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser(
        [FromBody] RegisterUserRequest request,
        [FromServices] RegisterUserHandler registerUserHandler) => await registerUserHandler.Handle(request);

    /// <summary>
    /// Activates a user.
    /// </summary>
    /// <param name="request">The user activation request.</param>
    /// <param name="activateUserHandler">The handler for activating a user.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [HttpGet("activate")]
    public async Task<IActionResult> ActivateUser(
        [FromQuery] ActivateUserRequest request,
        [FromServices] ActivateUserHandler activateUserHandler) => await activateUserHandler.Handle(request);

    /// <summary>
    /// Sends an email that will start the password recovery process.
    /// </summary>
    /// <param name="request">The SendRecoverEmailRequest object parameter.</param>
    /// <param name="sendRecoverEmailHandler">The handler for sending the password recovery email.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [HttpGet("sendRecoverEmail")]
    public async Task<IActionResult> SendRecoverEmail(
        [FromQuery] SendRecoverEmailRequest request,
        [FromServices] SendRecoverEmailHandler sendRecoverEmailHandler) => await sendRecoverEmailHandler.Handle(request);

    /// <summary>
    /// Connects the user to the application.
    /// </summary>
    /// <param name="request">The login request.</param>
    /// <param name="loginUserHandler">The handler for the login process.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser(
        [FromBody] LoginUserRequest request,
        [FromServices] LoginUserHandler loginUserHandler) => await loginUserHandler.Handle(request);

    /// <summary>
    /// Recovers the user's password.
    /// </summary>
    /// <param name="request">The password recovery request.</param>
    /// <param name="recoverPasswordHandler">The handler for recovering the user's password.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPut("recover")]
    public async Task<IActionResult> RecoverPassword(
        [FromBody] RecoverPasswordRequest request,
        [FromServices] RecoverPasswordHandler recoverPasswordHandler) => await recoverPasswordHandler.Handle(request);

    /// <summary>
    /// Updates the user.
    /// </summary>
    /// <param name="request">The user update request.</param>
    /// <param name="updateUserHandler">The handler for the user update process.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPut("update")]
    public async Task<IActionResult> UpdateUser(
        [FromBody] UpdateUserRequest request,
        [FromServices] UpdateUserHandler updateUserHandler) => await updateUserHandler.Handle(request);

    /// <summary>
    /// Retrieves the user's information.
    /// </summary>
    /// <param name="getUserHandler">The handler for retrieving the information.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpGet("get")]
    public async Task<IActionResult> GetUser(
        [FromServices] GetUserHandler getUserHandler) => await getUserHandler.Handle(new GetUserRequest());

    /// <summary>
    /// Retrieves the user's information by username.
    /// </summary>
    /// <param name="request">The request containing the user's username.</param>
    /// <param name="getUserByUsernameHandler">The handler for retrieving the information.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("getByUsername")]
    public async Task<IActionResult> GetUserByUsername(
        [FromBody] GetUserByUsernameRequest request,
        [FromServices] GetUserByUsernameHandler getUserByUsernameHandler) => await getUserByUsernameHandler.Handle(request);

    /// <summary>
    /// Retrieves the user's information by id.
    /// </summary>
    /// <param name="request">The request containing the user id.</param>
    /// <param name="getUserByIdHandler">The handler for retrieving the information.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpPost("getById")]
    public async Task<IActionResult> GetUserById(
        [FromBody] GetUserByIdRequest request,
        [FromServices] GetUserByIdHandler getUserByIdHandler) => await getUserByIdHandler.Handle(request);

    /// <summary>
    /// Retrieves all users from the database.
    /// </summary>
    /// <param name="getAllUsersHandler">The handler for retrieving the users.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAllUsers(
        [FromServices] GetAllUsersHandler getAllUsersHandler) => await getAllUsersHandler.Handle(new GetAllUsersRequest());

    /// <summary>
    /// Retrieves the games owned by the user.
    /// </summary>
    /// <param name="getUserGamesHandler">The handler for retrieving the games.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpGet("getUserGames")]
    public async Task<IActionResult> GetUserGames(
        [FromServices] GetUserGamesHandler getUserGamesHandler) => await getUserGamesHandler.Handle(new GetUserGamesRequest());

    /// <summary>
    /// Deletes a user from the database.
    /// </summary>
    /// <param name="deleteUserHandler">The handler for deleting the user.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser(
        [FromServices] DeleteUserHandler deleteUserHandler) => await deleteUserHandler.Handle(new DeleteUserRequest());

    /// <summary>
    /// Deletes a user from the database by id.
    /// </summary>
    /// <param name="request">The request containing the user id.</param>
    /// <param name="deleteUserByIdHandler">The handler for deleting the user.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    [Authorize]
    [HttpDelete("deleteById")]
    public async Task<IActionResult> DeleteUserById(
        [FromBody] DeleteUserByIdRequest request,
        [FromServices] DeleteUserByIdHandler deleteUserByIdHandler) => await deleteUserByIdHandler.Handle(request);
}