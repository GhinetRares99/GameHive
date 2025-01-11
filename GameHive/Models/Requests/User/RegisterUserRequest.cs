// <copyright file="RegisterUserRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.User;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to add a user into the database.
/// </summary>
public class RegisterUserRequest : Models.User, IRequest
{
}