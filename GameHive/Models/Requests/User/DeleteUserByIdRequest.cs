// <copyright file="DeleteUserByIdRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.User;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to delete a user from the database by id.
/// </summary>
public class DeleteUserByIdRequest : IRequest
{
    /// <summary>
    /// Gets or sets the Id of the user.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}
