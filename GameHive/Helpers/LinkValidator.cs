// <copyright file="LinkValidator.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Helpers;

using System.IdentityModel.Tokens.Jwt;

/// <summary>
/// A class used to check if a link is still valid.
/// </summary>
public static class LinkValidator
{
    /// <summary>
    /// A function used to check if the link is still valid.
    /// </summary>
    /// <param name="token">The token that needs to be checked.</param>
    /// <returns><c>true</c> or <c>false</c>.</returns>
    public static bool IsLinkValid(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();

        try
        {
            var readToken = tokenHandler.ReadToken(token) as JwtSecurityToken;
            return readToken != null && readToken.ValidTo >= DateTime.UtcNow;
        }
        catch (Exception)
        {
            return false;
        }
    }
}