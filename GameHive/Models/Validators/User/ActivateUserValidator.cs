// <copyright file="ActivateUserValidator.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Validators.User;

using System.Security.Claims;
using FluentValidation;
using GameHive.Helpers;
using GameHive.Models.Requests.User;
using GameHive.Services.Repositories.UserRepository;

/// <summary>
/// Validator for the user activation process.
/// </summary>
public class ActivateUserValidator : AbstractValidator<ActivateUserRequest>
{
    private readonly IUserRepository userRepository;
    private readonly IConfiguration configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="ActivateUserValidator"/> class.
    /// </summary>
    /// <param name="userRepository">The repository for the User class.</param>
    /// <param name="configuration">The configuration.</param>
    public ActivateUserValidator(IUserRepository userRepository, IConfiguration configuration)
    {
        this.userRepository = userRepository;
        this.configuration = configuration;
        this.RuleFor(model => model.ActivationToken)
            .Cascade(CascadeMode.Stop)
            .MustAsync(this.MatchDbActivationToken).WithMessage(ConstantValues.ActivationTokenIncorrect)
            .MustAsync(this.NotBeActivated).WithMessage(ConstantValues.UserAlreadyActivated)
            .MustAsync(this.StillValid).WithMessage(ConstantValues.ActivationLinkExpired);
    }

    private async Task<bool> MatchDbActivationToken(ActivateUserRequest request, string activationToken, ValidationContext<ActivateUserRequest> arg3, CancellationToken arg4)
    {
        var claims = TokenValidation.IsValidActivationTokenAndReturnClaims(request.ActivationToken, this.configuration);
        var email = claims[ClaimTypes.Name];
        var foundUser = await this.userRepository.FindUserByEmail(email);
        return foundUser != null && foundUser.ActivationToken == activationToken;
    }

    private async Task<bool> NotBeActivated(ActivateUserRequest request, string activationToken, ValidationContext<ActivateUserRequest> arg3, CancellationToken arg4)
    {
        var claims = TokenValidation.IsValidActivationTokenAndReturnClaims(request.ActivationToken, this.configuration);
        var email = claims[ClaimTypes.Name];
        var foundUser = await this.userRepository.FindUserByEmail(email);
        return foundUser != null && foundUser.Status != "Active";
    }

    private async Task<bool> StillValid(ActivateUserRequest request, string activationToken, ValidationContext<ActivateUserRequest> arg3, CancellationToken arg4)
    {
        var claims = TokenValidation.IsValidActivationTokenAndReturnClaims(request.ActivationToken, this.configuration);
        var email = claims[ClaimTypes.Name];
        var foundUser = await this.userRepository.FindUserByEmail(email);
        return foundUser != null && LinkValidator.IsLinkValid(request.ActivationToken);
    }
}