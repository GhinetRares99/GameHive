// <copyright file="ServiceConfiguration.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Configuration;

using System.Text;
using FluentValidation.AspNetCore;
using GameHive.Controllers.Handlers.Game;
using GameHive.Controllers.Handlers.Possession;
using GameHive.Controllers.Handlers.Trophy;
using GameHive.Controllers.Handlers.User;
using GameHive.Helpers;
using GameHive.Models;
using GameHive.Models.Requests.Possession;
using GameHive.Models.Settings;
using GameHive.Models.Validators.Game;
using GameHive.Models.Validators.Possession;
using GameHive.Models.Validators.Trophy;
using GameHive.Models.Validators.User;
using GameHive.Services.GameService;
using GameHive.Services.PermissionService;
using GameHive.Services.PossessionService;
using GameHive.Services.Repositories.EmailTemplateRepository;
using GameHive.Services.Repositories.GameRepository;
using GameHive.Services.Repositories.Interfaces;
using GameHive.Services.Repositories.PermissionRepository;
using GameHive.Services.Repositories.PossessionRepository;
using GameHive.Services.Repositories.TrophyRepository;
using GameHive.Services.Repositories.UserRepository;
using GameHive.Services.TrophyService;
using GameHive.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.IdentityModel.Tokens;

/// <summary>
/// Provides a helper class for configuring services.
/// </summary>
public class ServiceConfiguration
{
    /// <summary>
    /// Configures the services.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configuration">The configuration.</param>
    public static void Configure(IServiceCollection services, IConfiguration configuration)
    {
        // Basic Service Configurations
        services.AddControllers();
        services.AddHttpContextAccessor();
        services.AddEndpointsApiExplorer();
        services.AddSingleton(configuration);

        // HealthCheck
        services.AddHealthChecks()
            .AddCheck("Self", () => HealthCheckResult.Healthy("Application core is healthy."));

        // Fluent Validation Configurations
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        // Repository
        services.AddSingleton<IGenericRepository<User>, UserRepository>();
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<UserRepository>();
        services.AddSingleton<IGenericRepository<Permission>, PermissionRepository>();
        services.AddSingleton<IPermissionRepository, PermissionRepository>();
        services.AddSingleton<PermissionRepository>();
        services.AddSingleton<IGenericRepository<Game>, GameRepository>();
        services.AddSingleton<IGameRepository, GameRepository>();
        services.AddSingleton<GameRepository>();
        services.AddSingleton<ITrophyRepository, TrophyRepository>();
        services.AddSingleton<TrophyRepository>();
        services.AddSingleton<IPossessionRepository, PossessionRepository>();
        services.AddSingleton<PossessionRepository>();
        services.AddSingleton<EmailTemplateRepository>();

        // Service
        services.AddSingleton<IUserService, UserService>();
        services.AddSingleton<UserService>();
        services.AddSingleton<IPermissionService, PermissionService>();
        services.AddSingleton<PermissionService>();
        services.AddSingleton<IGameService, GameService>();
        services.AddSingleton<GameService>();
        services.AddSingleton<ITrophyService, TrophyService>();
        services.AddSingleton<TrophyService>();
        services.AddSingleton<IPossessionService, PossessionService>();
        services.AddSingleton<PossessionService>();

        // Handler
        services.AddScoped<RegisterUserHandler>();
        services.AddScoped<ActivateUserHandler>();
        services.AddScoped<DeleteUserHandler>();
        services.AddScoped<LoginUserHandler>();
        services.AddScoped<GetUserByIdHandler>();
        services.AddScoped<GetUserByUsernameHandler>();
        services.AddScoped<GetUserHandler>();
        services.AddScoped<GetAllUsersHandler>();
        services.AddScoped<SendRecoverEmailHandler>();
        services.AddScoped<RecoverPasswordHandler>();
        services.AddScoped<UpdateUserHandler>();
        services.AddScoped<DeleteUserByIdHandler>();
        services.AddScoped<GetUserGamesHandler>();

        services.AddScoped<AddGameHandler>();
        services.AddScoped<GetAllGamesHandler>();
        services.AddScoped<GetGameByIdHandler>();
        services.AddScoped<GetGameByNameHandler>();
        services.AddScoped<DeleteGameHandler>();
        services.AddScoped<UpdateGameHandler>();

        services.AddScoped<AddTrophyHandler>();
        services.AddScoped<GetAllTrophiesHandler>();
        services.AddScoped<GetTrophyByIdHandler>();
        services.AddScoped<GetTrophyByNameHandler>();
        services.AddScoped<GetTrophiesByGameIdHandler>();
        services.AddScoped<DeleteTrophyHandler>();
        services.AddScoped<DeleteTrophiesByGameIdHandler>();
        services.AddScoped<UpdateTrophyHandler>();

        services.AddScoped<AddPossessionHandler>();
        services.AddScoped<GetPossessionByGameIdAndUserIdHandler>();
        services.AddScoped<GetPossessionsByGameIdHandler>();
        services.AddScoped<GetPossessionsByUserIdHandler>();
        services.AddScoped<DeletePossessionHandler>();
        services.AddScoped<DeletePossessionsByGameIdHandler>();
        services.AddScoped<DeletePossessionsByUserIdHandler>();

        // Validator
        services.AddScoped<RegisterUserValidator>();
        services.AddScoped<ActivateUserValidator>();
        services.AddScoped<LoginUserValidator>();
        services.AddScoped<RecoverPasswordValidator>();
        services.AddScoped<UpdateUserValidator>();

        services.AddScoped<AddGameValidator>();
        services.AddScoped<UpdateGameValidator>();

        services.AddScoped<AddTrophyValidator>();
        services.AddScoped<UpdateTrophyValidator>();

        services.AddScoped<AddPossessionValidator>();
        services.AddScoped<DeletePossessionValidator>();

        // Token Settings
        var tokenSettingsSection = configuration.GetSection(ConstantValues.TokenSettingsSection);
        var tokenSettings = tokenSettingsSection.Get<TokenSettings>() ?? throw new InvalidOperationException(ConstantValues.TokenSettingsNotConfigured);
        services.Configure<TokenSettings>(tokenSettingsSection);

        // Authentication Settings
        var authenticationSettingsSection = configuration.GetSection(ConstantValues.AuthenticationSettingsSection);
        var authenticationSettings = authenticationSettingsSection.Get<AuthenticationSettings>() ?? throw new InvalidOperationException(ConstantValues.AuthenticationSettingsNotConfigured);
        services.Configure<AuthenticationSettings>(authenticationSettingsSection);

        // JWT Bearer Configuration
        var authenticationIssuer = authenticationSettings.Issuer;
        var authenticationAudience = authenticationSettings.Audience;
        var tokenGenerationKeyValue = tokenSettings.TokenGenerationKeyValue;

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authenticationIssuer,

                    ValidateAudience = true,
                    ValidAudience = authenticationAudience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenGenerationKeyValue)),

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                };
            });

        // Authorization
        services.AddAuthorization();

        services.AddHttpClient();
    }
}