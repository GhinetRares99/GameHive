// <copyright file="EmailTemplateRepository.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Services.Repositories.EmailTemplateRepository;

using GameHive.Models;
using MongoDB.Driver;

/// <summary>
/// Represents a repository for <see cref="EmailTemplate"/> class.
/// </summary>
public class EmailTemplateRepository : GenericRepository<EmailTemplate>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EmailTemplateRepository"/> class.
    /// </summary>
    /// <param name="database">The MongoDB database instance.</param>
    public EmailTemplateRepository(IMongoDatabase database)
        : base(database)
    {
    }
}