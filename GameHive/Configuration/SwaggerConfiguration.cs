// <copyright file="SwaggerConfiguration.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Configuration;

using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

/// <summary>
/// Provides a helper class for configuring Swagger.
/// </summary>
public class SwaggerConfiguration
{
    /// <summary>
    /// Configures Swagger services.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="title">The title of the API.</param>
    /// <param name="version">The version of the API.</param>
    /// <param name="description">The description of the API.</param>
    public static void Configure(IServiceCollection services, string title, string version, string description)
    {
        services.AddSwaggerGen();
        services.Configure<SwaggerGenOptions>(options =>
        {
            options.SwaggerDoc(version, new OpenApiInfo
            {
                Title = title,
                Version = version,
                Description = description,
            });
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "JWT Authorization header using the Bearer scheme",
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Name = "Authorization",
            });
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer",
                        },
                    },
                    new List<string>()
                },
            });
        });
    }
}
