// <copyright file="UpdateUserValidator.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Validators.User;

using FluentValidation;
using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.Repositories.UserRepository;

/// <summary>
/// Validator for the user update process.
/// </summary>
public class UpdateUserValidator : AbstractValidator<UpdateUserRequest>
{
    private readonly UserRepository userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateUserValidator"/> class.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    public UpdateUserValidator(UserRepository userRepository)
    {
        this.userRepository = userRepository;
        this.RuleFor(model => model.Email)
            .NotEmpty().WithMessage(ConstantValues.EmailIsRequired)
            .EmailAddress().WithMessage(ConstantValues.InvalidEmailFormat)
            .DependentRules(() =>
            {
                this.RuleFor(model => model)
                    .MustAsync(this.UpdatedEmailIsUnique).WithMessage(ConstantValues.UserAlreadyExists);
            });
        this.RuleFor(model => model.Password)
            .NotEmpty().WithMessage(ConstantValues.PasswordIsRequired)
            .MinimumLength(6).WithMessage(ConstantValues.PasswordMinimumLength6);
        this.RuleFor(model => model.Username)
            .NotEmpty().WithMessage(ConstantValues.UsernameIsRequired)
            .DependentRules(() =>
             {
                 this.RuleFor(model => model)
                     .MustAsync(this.UpdatedUsernameIsUnique).WithMessage(ConstantValues.UsernameIsInUse);
             });
        this.RuleFor(model => model.Balance)
            .GreaterThanOrEqualTo(0.00).WithMessage(ConstantValues.BalanceMustBeGreaterOrEqualToZero);
        this.RuleFor(model => model.ProfilePic)
            .NotEmpty().WithMessage(ConstantValues.ProfilePicIsRequired);
    }

    private async Task<bool> UpdatedEmailIsUnique(Models.User user, CancellationToken cancellationToken = default)
    {
        var foundUserById = await this.userRepository.GetByIdAsync(user.Id);
        var foundUser = await this.userRepository.FindUserByEmail(user.Email);

        if (foundUserById?.Email == user.Email && foundUserById != null)
        {
            return true;
        }

        return foundUser == null;
    }

    private async Task<bool> UpdatedUsernameIsUnique(Models.User user, CancellationToken cancellationToken = default)
    {
        var foundUserById = await this.userRepository.GetByIdAsync(user.Id);
        var foundUser = await this.userRepository.FindUserByUsername(user.Username);

        if (foundUserById?.Email == user.Email && foundUserById != null)
        {
            return true;
        }

        return foundUser == null;
    }
}