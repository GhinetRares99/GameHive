// <copyright file="AddGameRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Game;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to add a game into the database.
/// </summary>
public class AddGameRequest : Models.Game, IRequest
{
}