// <copyright file="DeletePossessionValidator.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Validators.Possession;

using FluentValidation;
using GameHive.Helpers;
using GameHive.Models.Requests.Possession;
using GameHive.Services.Repositories.GameRepository;
using GameHive.Services.Repositories.PossessionRepository;
using GameHive.Services.Repositories.UserRepository;

/// <summary>
/// Validator for the possession removal process.
/// </summary>
public class DeletePossessionValidator : AbstractValidator<DeletePossessionRequest>
{
    private readonly PossessionRepository possessionRepository;
    private readonly GameRepository gameRepository;
    private readonly UserRepository userRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeletePossessionValidator"/> class.
    /// </summary>
    /// <param name="possessionRepository">The possession repository.</param>
    /// <param name="gameRepository">The game repository.</param>
    /// <param name="userRepository">The user repository.</param>
    public DeletePossessionValidator(PossessionRepository possessionRepository, GameRepository gameRepository, UserRepository userRepository)
    {
        this.possessionRepository = possessionRepository;
        this.gameRepository = gameRepository;
        this.userRepository = userRepository;
        this.RuleFor(model => model.GameId)
            .NotEmpty().WithMessage(ConstantValues.GameIdIsRequired)
            .MustAsync(this.GameExists).WithMessage(ConstantValues.GameDoesNotExist);
        this.RuleFor(model => model.UserId)
            .NotEmpty().WithMessage(ConstantValues.UserIdIsRequired)
            .MustAsync(this.UserExists).WithMessage(ConstantValues.UserDoesNotExist);
        this.RuleFor(model => model)
            .MustAsync(this.CheckOwned).WithMessage(ConstantValues.GameNotOwned);
    }

    private async Task<bool> GameExists(string gameId, CancellationToken cancellationToken = default)
    {
        var foundGame = await this.gameRepository.GetByIdAsync(gameId);
        return foundGame != null;
    }

    private async Task<bool> UserExists(string userId, CancellationToken cancellationToken = default)
    {
        var foundUser = await this.userRepository.GetByIdAsync(userId);
        return foundUser != null;
    }

    private async Task<bool> CheckOwned(DeletePossessionRequest request, CancellationToken cancellationToken = default)
    {
        var foundPossession = await this.possessionRepository.FindPossessionByGameIdAndUserId(request.GameId, request.UserId);
        return foundPossession != null;
    }
}