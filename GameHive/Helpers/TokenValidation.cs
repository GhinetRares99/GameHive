// <copyright file="TokenValidation.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Helpers;

using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

/// <summary>
/// A class used to validate JWT tokens.
/// </summary>
public static class TokenValidation
{
    /// <summary>
    /// A function used to validate a JWT token.
    /// </summary>
    /// <param name="token">The token to be validated.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns><c>true</c> if the token is valid; otherwise, <c>false</c>.</returns>
    public static bool IsValid(string token, IConfiguration configuration)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration.GetSection(ConstantValues.IssuerSection).Value,
            ValidateAudience = true,
            ValidAudience = configuration.GetSection(ConstantValues.AudienceSection).Value,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection(ConstantValues.TokenGenerationSection).Value)),
        };

        try
        {
            tokenHandler.ValidateToken(token, validationParameters, out _);
            return true;
        }
        catch (SecurityTokenException)
        {
            return false;
        }
    }

    /// <summary>
    /// A function used to validate a JWT token for the activation process.
    /// </summary>
    /// <param name="activationToken">The activation token to be validated.</param>
    /// <param name="configuration">The configuration.</param>
    /// <returns>A dictionary containing the claims from the token.</returns>
    public static Dictionary<string, string> IsValidActivationTokenAndReturnClaims(string activationToken, IConfiguration configuration)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = configuration.GetSection(ConstantValues.IssuerSection).Value,
            ValidateAudience = true,
            ValidAudience = configuration.GetSection(ConstantValues.AudienceSection).Value,
            ValidateLifetime = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection(ConstantValues.ActivationTokenGenerationSection).Value)),
        };

        var claimsPrincipal = tokenHandler.ValidateToken(activationToken, validationParameters, out _);
        var claimsDictionary = claimsPrincipal.Claims.ToDictionary(c => c.Type, c => c.Value);

        return claimsDictionary;
    }
}