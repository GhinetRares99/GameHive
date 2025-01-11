// <copyright file="IEntity.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Interfaces;

/// <summary>
/// Represents an interface for entities with an identifier.
/// </summary>
public interface IEntity
{
    /// <summary>
    /// Gets or sets the identifier of the entity.
    /// </summary>
    string Id { get; set; }
}