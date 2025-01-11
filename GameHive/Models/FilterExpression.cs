// <copyright file="FilterExpression.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models;

using System.Linq.Expressions;
using MongoDB.Driver;

/// <summary>
/// Represents a filter expression for querying entities of type <typeparamref name="TEntity"/>.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public class FilterExpression<TEntity>
{
    /// <summary>
    /// Gets or sets the filter expression.
    /// </summary>
    public Expression<Func<TEntity, bool>>? Filter { get; set; }

    /// <summary>
    /// Gets or sets the projection definition.
    /// </summary>
    public ProjectionDefinition<TEntity, TEntity>? Projection { get; set; }
}