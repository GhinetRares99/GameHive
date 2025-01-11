// <copyright file="LoginUserValidator.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Validators.User;

using FluentValidation;
using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.Repositories.UserRepository;

/// <summary>
/// Validator for the login process.
/// </summary>
public class LoginUserValidator : AbstractValidator<LoginUserRequest>
{
    private readonly IUserRepository userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="LoginUserValidator"/> class.
    /// </summary>
    /// <param name="userRepository">The repository for the User class.</param>
    public LoginUserValidator(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        this.RuleFor(model => model.Password).Cascade(CascadeMode.Stop)
            .MustAsync((request, password, arg3) => this.MatchDbPassword(request, password, arg3)).WithMessage(ConstantValues.IncorrectEmailOrPassword)
            .MustAsync(this.IsActivated).WithMessage(ConstantValues.UserNotActivated);
    }

    private async Task<bool> MatchDbPassword(LoginUserRequest request, string password, CancellationToken cancellationToken = default)
    {
        var foundUser = await this.userRepository.FindUserByEmail(request.Email);
        return foundUser != null && foundUser.Password == Hasher.HashPassword(password);
    }

    private async Task<bool> IsActivated(LoginUserRequest request, string password, CancellationToken cancellationToken = default)
    {
        var foundUser = await this.userRepository.FindUserByEmail(request.Email);
        return foundUser is { Status: "Active" };
    }
}