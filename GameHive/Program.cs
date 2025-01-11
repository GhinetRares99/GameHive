// <copyright file="Program.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

using GameHive.Configuration;
using GameHive.Helpers;
using GameHive.Models.Settings;

var builder = WebApplication.CreateBuilder(args);

// Get the MongoDB settings
var configuration = builder.Configuration;
var mongoDbSettings = configuration.GetSection(ConstantValues.MongoDbSection).Get<MongoDbSettings>();

// Configure the database and create unique indexes
ServiceConfiguration.Configure(builder.Services, configuration);
MongoDbConfiguration.Configure(builder.Services, mongoDbSettings ?? throw new InvalidOperationException());
SwaggerConfiguration.Configure(builder.Services, "GameHive", "v1", "An application for selling video games.");

var app = builder.Build();

// Create MongoDB indexes
MongoDbIndexConfiguration.Configure(app.Services, mongoDbSettings);

// CORS
var corsSettings = configuration.GetSection(ConstantValues.CorsSettingsSection).Get<CorsSettings>();
CorsConfiguration.Configure(app, corsSettings ?? throw new InvalidOperationException());

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<IsAuthorized>();

app.MapControllers();

app.Run();
