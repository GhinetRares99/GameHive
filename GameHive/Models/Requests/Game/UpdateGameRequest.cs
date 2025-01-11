// <copyright file="UpdateGameRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Game;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to update a game from the database.
/// </summary>
public class UpdateGameRequest : Models.Game, IRequest
{
}