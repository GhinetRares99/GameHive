// <copyright file="GenericRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories;

using GameHive.Models;
using GameHive.Models.Interfaces;
using GameHive.Services.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

/// <summary>
/// Represents a base repository.
/// </summary>
/// <typeparam name="TEntity">The type of the entity.</typeparam>
public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : IEntity
{
    private readonly IMongoCollection<TEntity> collection;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{TEntity}"/> class.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    protected GenericRepository(IMongoDatabase database)
    {
        this.collection = database.GetCollection<TEntity>(typeof(TEntity).Name);
    }

    /// <summary>
    /// Retrieves all entities asynchronously.
    /// </summary>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of entities.</returns>
    public async Task<List<TEntity>> GetAllAsync()
    {
        return await this.collection.Find(_ => true).ToListAsync();
    }

    /// <summary>
    /// Retrieves an entity by its identifier asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the entity.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the entity.</returns>
    public async Task<TEntity?> GetByIdAsync(string id)
    {
        var objectId = ObjectId.Parse(id);
        var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
        return await this.collection.Find(filter).FirstOrDefaultAsync();
    }

    /// <summary>
    /// Gets entities of the specified type based on the provided filter asynchronously.
    /// </summary>
    /// <param name="filter">The filter definition.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of filtered entities.</returns>
    public async Task<List<TEntity>> GetFilteredAsync(FilterExpression<TEntity> filter)
    {
        return await this.collection.Find(filter.Filter).ToListAsync();
    }

    /// <summary>
    /// Gets an entity of the specified type based on the provided filter asynchronously.
    /// </summary>
    /// <param name="filter">The filter definition.</param>
    /// <returns>A task representing the asynchronous operation. The task result contains the list of filtered entities.</returns>
    public async Task<TEntity?> GetOneFilteredAsync(FilterExpression<TEntity> filter)
    {
        return await this.collection.Find<TEntity>(filter.Filter).FirstOrDefaultAsync<TEntity>();
    }

    /// <summary>
    /// Inserts an entity asynchronously.
    /// </summary>
    /// <param name="entity">The entity to insert.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates whether the insertion was successful.</returns>
    public async Task<TEntity> InsertAsync(TEntity entity)
    {
        await this.collection.InsertOneAsync(entity);
        return entity;
    }

    /// <summary>
    /// Updates an entity asynchronously.
    /// </summary>
    /// <param name="entity">The updated entity.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates whether the update was successful.</returns>
    public async Task<bool> UpdateAsync(TEntity entity)
    {
        var objectId = ObjectId.Parse(entity.Id);
        var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
        var result = await this.collection.ReplaceOneAsync(filter, entity);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    /// <summary>
    /// Deletes an entity asynchronously.
    /// </summary>
    /// <param name="id">The identifier of the entity to delete.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates whether the delete was successful.</returns>
    public async Task<bool> DeleteAsync(string id)
    {
        var objectId = ObjectId.Parse(id);
        var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
        var result = await this.collection.DeleteOneAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }

    /// <summary>
    /// Deletes multiple entities asynchronously.
    /// </summary>
    /// <param name="filter">The filter definition.</param>
    /// <returns>A task representing the asynchronous operation. The task result indicates whether the delete was successful.</returns>
    public async Task<bool> DeleteMultipleAsync(Expression<Func<TEntity, bool>> filter)
    {
        var result = await this.collection.DeleteManyAsync(filter);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}