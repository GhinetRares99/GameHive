// <copyright file="GetUserByUsernameHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting a user from the database by username.
/// </summary>
public class GetUserByUsernameHandler : BaseRequestHandler<GetUserByUsernameRequest>
{
    private readonly IUserService userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetUserByUsernameHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service implementation.</param>
    public GetUserByUsernameHandler(ILogger<GetUserByUsernameHandler> logger, IUserService userService)
        : base(logger)
    {
        this.userService = userService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetUserByUsernameRequest request)
    {
        var result = await this.userService.GetUserByUsername(request.Username);
        return result != null
            ? this.HandleSuccess(string.Format(ConstantValues.GetSuccessful, typeof(Models.User).Name), result)
            : this.HandleNotFound(string.Format(ConstantValues.GetNotFound, typeof(Models.User).Name, request.Username));
    }
}