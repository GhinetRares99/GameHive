// <copyright file="GetAllUsersHandler.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Controllers.Handlers.User;

using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Represents a request handler for getting all the users from the database.
/// </summary>
public class GetAllUsersHandler : BaseRequestHandler<GetAllUsersRequest>
{
    private readonly IUserService userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetAllUsersHandler"/> class.
    /// </summary>
    /// <param name="logger">The logger instance.</param>
    /// <param name="userService">The user service implementation.</param>
    public GetAllUsersHandler(ILogger<GetAllUsersHandler> logger, IUserService userService)
        : base(logger)
    {
        this.userService = userService;
    }

    /// <summary>
    /// Handles the specific request logic.
    /// </summary>
    /// <param name="request">The request to be handled.</param>
    /// <returns>An asynchronous task that represents the operation and holds the action result.</returns>
    protected override async Task<IActionResult> HandleRequest(GetAllUsersRequest request)
    {
        var result = await this.userService.GetAllUsers();
        return result.Count != 0
           ? this.HandleSuccess(string.Format(ConstantValues.GetAllSuccessful, typeof(Models.User).Name), result)
           : this.HandleNotFound(string.Format(ConstantValues.GetAllNotFound, typeof(Models.User).Name));
    }
}