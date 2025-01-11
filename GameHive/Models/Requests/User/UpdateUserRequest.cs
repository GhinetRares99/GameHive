// <copyright file="UpdateUserRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.User;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to update a user from the database.
/// </summary>
public class UpdateUserRequest : Models.User, IRequest
{
}