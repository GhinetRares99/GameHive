// <copyright file="GetTrophyByIdRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Trophy;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to retrieve the information of a trophy by id.
/// </summary>
public class GetTrophyByIdRequest : IRequest
{
    /// <summary>
    /// Gets or sets the Id of the trophy.
    /// </summary>
    public string Id { get; set; } = string.Empty;
}