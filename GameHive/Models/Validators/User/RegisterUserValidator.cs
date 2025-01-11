// <copyright file="RegisterUserValidator.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Validators.User;

using FluentValidation;
using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.Repositories.UserRepository;

/// <summary>
/// Validator for the registration process.
/// </summary>
public class RegisterUserValidator : AbstractValidator<RegisterUserRequest>
{
    private readonly IUserRepository userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="RegisterUserValidator"/> class.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    public RegisterUserValidator(IUserRepository userRepository)
    {
        this.userRepository = userRepository;
        this.RuleFor(model => model.Email)
            .NotEmpty().WithMessage(ConstantValues.EmailIsRequired)
            .EmailAddress().WithMessage(ConstantValues.InvalidEmailFormat)
            .MustAsync(this.EmailIsUnique).WithMessage(ConstantValues.UserAlreadyExists);
        this.RuleFor(model => model.Password)
            .NotEmpty().WithMessage(ConstantValues.PasswordIsRequired)
            .MinimumLength(6).WithMessage(ConstantValues.PasswordMinimumLength6);
        this.RuleFor(model => model.Username)
            .NotEmpty().WithMessage(ConstantValues.UsernameIsRequired)
            .MustAsync(this.UsernameIsUnique).WithMessage(ConstantValues.UsernameIsInUse);
        this.RuleFor(model => model.Balance)
            .GreaterThanOrEqualTo(0.00).WithMessage(ConstantValues.BalanceMustBeGreaterOrEqualToZero);
        this.RuleFor(model => model.ProfilePic)
            .NotEmpty().WithMessage(ConstantValues.ProfilePicIsRequired);
    }

    private async Task<bool> EmailIsUnique(string email, CancellationToken cancellationToken = default)
    {
        var foundUser = await this.userRepository.FindUserByEmail(email);
        return foundUser == null;
    }

    private async Task<bool> UsernameIsUnique(string username, CancellationToken cancellationToken = default)
    {
        var foundUser = await this.userRepository.FindUserByUsername(username);
        return foundUser == null;
    }
}