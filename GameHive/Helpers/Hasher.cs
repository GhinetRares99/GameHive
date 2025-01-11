// <copyright file="Hasher.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Helpers;

using System.Security.Cryptography;
using System.Text;

/// <summary>
/// A class used for encryptions.
/// </summary>
public static class Hasher
{
    /// <summary>
    /// A function used to encrypt the password.
    /// </summary>
    /// <param name="password">The password that needs to be encrypted.</param>
    /// <returns>An encrypted password.</returns>
    public static string HashPassword(string password)
    {
        var hash = SHA256.Create();
        var bytes = Encoding.UTF8.GetBytes(password);
        var hashedBytes = hash.ComputeHash(bytes);
        var hashedPassword = Convert.ToBase64String(hashedBytes);

        return hashedPassword;
    }
}