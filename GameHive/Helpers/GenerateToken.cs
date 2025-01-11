// <copyright file="GenerateToken.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Helpers;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GameHive.Models;
using GameHive.Models.Settings;
using Microsoft.IdentityModel.Tokens;

/// <summary>
/// A class used to generate a JWT token for login.
/// </summary>
public static class GenerateToken
{
    /// <summary>
    /// A function that generates a JWT token for login.
    /// </summary>
    /// <param name="foundUser">The user found in the database.</param>
    /// <param name="tokenSettings">The token generation settings.</param>
    /// <param name="authenticationSettings">The authentication settings.</param>
    /// <returns>A JWT token for login.</returns>
    public static string Generate(User foundUser, TokenSettings tokenSettings, AuthenticationSettings authenticationSettings)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, foundUser.Id),
            new(ClaimTypes.Name, foundUser.Email),
            new(ClaimTypes.Role, foundUser.Role),
            new(JwtRegisteredClaimNames.Iss, authenticationSettings.Issuer),
            new(JwtRegisteredClaimNames.Aud, authenticationSettings.Audience),
        };

        var key = Encoding.UTF8.GetBytes(tokenSettings.TokenGenerationKeyValue);
        var tokenOptions = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(1),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.WriteToken(tokenOptions);

        return token;
    }

    /// <summary>
    /// A function that generates a JWT token that will be included in a link.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <param name="secretKey">The encoding key.</param>
    /// <param name="authenticationSettings">The authentication settings.</param>
    /// <param name="configuration">The configuration.</param>
    /// <param name="section">The configuration section with the appropriate expiration time.</param>
    /// <returns>The JWT token.</returns>
    public static string GenerateLinkToken(string email, string secretKey, AuthenticationSettings authenticationSettings, IConfiguration configuration, string section)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.Name, email),
            new(JwtRegisteredClaimNames.Iss, authenticationSettings.Issuer),
            new(JwtRegisteredClaimNames.Aud, authenticationSettings.Audience),
        };

        var key = Encoding.UTF8.GetBytes(secretKey);
        var linkTokenOptions = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddHours(configuration.GetSection(section).Get<int>()),
            signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature));

        var linkTokenHandler = new JwtSecurityTokenHandler();
        var linkToken = linkTokenHandler.WriteToken(linkTokenOptions);

        return linkToken;
    }
}