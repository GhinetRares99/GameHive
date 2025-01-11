// <copyright file="GetTrophyByNameRequest.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Requests.Trophy;

using GameHive.Models.Interfaces;

/// <summary>
/// Represents a request to retrieve the information of a trophy by Name.
/// </summary>
public class GetTrophyByNameRequest : IRequest
{
    /// <summary>
    /// Gets or sets the Name of the trophy.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}