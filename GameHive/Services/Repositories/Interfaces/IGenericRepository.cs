// <copyright file="IGenericRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.Interfaces;

using GameHive.Models;

/// <summary>
/// Represents a generic repository interface for performing CRUD operations on entities of type <typeparamref name="T"/>.
/// </summary>
/// <typeparam name="T">The type of the entity.</typeparam>
public interface IGenericRepository<T>
{
    /// <summary>
    /// Retrieves all entities of type <typeparamref name="T"/> from the repository.
    /// </summary>
    /// <returns>A task representing the asynchronous operation that returns a list of entities.</returns>
    Task<List<T>> GetAllAsync();

    /// <summary>
    /// Retrieves an entity of type <typeparamref name="T"/> by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <returns>A task representing the asynchronous operation that returns the entity, or null if not found.</returns>
    Task<T?> GetByIdAsync(string id);

    /// <summary>
    /// Retrieves entities of type <typeparamref name="T"/> based on the specified filter.
    /// </summary>
    /// <param name="filter">The filter to apply when querying entities.</param>
    /// <returns>A task representing the asynchronous operation that returns a list of entities.</returns>
    Task<List<T>> GetFilteredAsync(FilterExpression<T> filter);

    /// <summary>
    /// Retrieves an entity of type <typeparamref name="T" /> based on the specified filter.
    /// </summary>
    /// <param name="filter">The filter to apply when querying entities.</param>
    /// <returns>A task representing the asynchronous operation that returns a list of entities.</returns>
    Task<T?> GetOneFilteredAsync(FilterExpression<T> filter);

    /// <summary>
    /// Inserts a new entity of type <typeparamref name="T"/> into the repository.
    /// </summary>
    /// <param name="entity">The entity to be inserted.</param>
    /// <returns>A task representing the asynchronous operation that returns the inserted entity.</returns>
    Task<T> InsertAsync(T entity);

    /// <summary>
    /// Updates an existing entity of type <typeparamref name="T"/> in the repository.
    /// </summary>
    /// <param name="entity">The entity to be updated.</param>
    /// <returns>A task representing the asynchronous operation that returns a boolean indicating the success of the update operation.</returns>
    Task<bool> UpdateAsync(T entity);

    /// <summary>
    /// Deletes an entity of type <typeparamref name="T"/> from the repository by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity to be deleted.</param>
    /// <returns>A task representing the asynchronous operation that returns a boolean indicating the success of the delete operation.</returns>
    Task<bool> DeleteAsync(string id);
}