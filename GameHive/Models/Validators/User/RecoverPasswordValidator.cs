// <copyright file="RecoverPasswordValidator.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Validators.User;

using FluentValidation;
using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.Repositories.UserRepository;

/// <summary>
/// Validator for the password update process.
/// </summary>
public class RecoverPasswordValidator : AbstractValidator<RecoverPasswordRequest>
{
    private readonly IUserRepository userRepository;
    private readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Initializes a new instance of the <see cref="RecoverPasswordValidator"/> class.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="httpContextAccessor">The http context accessor.</param>
    public RecoverPasswordValidator(IUserRepository userRepository, IHttpContextAccessor httpContextAccessor)
    {
        this.userRepository = userRepository;
        this.httpContextAccessor = httpContextAccessor;
        this.RuleFor(model => model.NewPassword)
            .NotEmpty().WithMessage(ConstantValues.PasswordIsRequired)
            .MinimumLength(6).WithMessage(ConstantValues.PasswordMinimumLength6)
            .MustAsync(this.BeNewPassword).WithMessage(ConstantValues.NewPasswordRequired);
    }

    private async Task<bool> BeNewPassword(RecoverPasswordRequest request, string newPassword, CancellationToken arg3)
    {
        var authorizationUserEmail = this.httpContextAccessor.HttpContext?.User.Identity?.Name;
        var foundUser = await this.userRepository.FindUserByEmail(authorizationUserEmail!);
        return foundUser != null && foundUser.Password != Hasher.HashPassword(newPassword);
    }
}