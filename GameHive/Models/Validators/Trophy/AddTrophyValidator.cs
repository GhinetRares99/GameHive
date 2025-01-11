// <copyright file="AddTrophyValidator.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Validators.Trophy;

using FluentValidation;
using GameHive.Helpers;
using GameHive.Models.Requests.Trophy;
using GameHive.Services.Repositories.GameRepository;
using GameHive.Services.Repositories.TrophyRepository;

/// <summary>
/// Validator for the trophy addition process.
/// </summary>
public class AddTrophyValidator : AbstractValidator<AddTrophyRequest>
{
    private readonly TrophyRepository trophyRepository;
    private readonly GameRepository gameRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddTrophyValidator"/> class.
    /// </summary>
    /// <param name="trophyRepository">The trophy repository.</param>
    /// <param name="gameRepository">The game repository.</param>
    public AddTrophyValidator(TrophyRepository trophyRepository, GameRepository gameRepository)
    {
        this.trophyRepository = trophyRepository;
        this.gameRepository = gameRepository;
        this.RuleFor(model => model.GameId)
            .NotEmpty().WithMessage(ConstantValues.GameIdIsRequired)
            .MustAsync(this.GameExists).WithMessage(ConstantValues.GameDoesNotExist);
        this.RuleFor(model => model.Name)
            .NotEmpty().WithMessage(ConstantValues.NameIsRequired)
            .MustAsync(this.NameIsUnique).WithMessage(ConstantValues.TrophyNameAlreadyExists);
        this.RuleFor(model => model.Description)
            .NotEmpty().WithMessage(ConstantValues.DescriptionIsRequired);
        this.RuleFor(model => model.IconUrl)
            .NotEmpty().WithMessage(ConstantValues.IconUrlIsRequired);
    }

    private async Task<bool> NameIsUnique(string name, CancellationToken cancellationToken = default)
    {
        var foundTrophy = await this.trophyRepository.FindTrophyByName(name);
        return foundTrophy == null;
    }

    private async Task<bool> GameExists(string gameId, CancellationToken cancellationToken = default)
    {
        var foundGame = await this.gameRepository.GetByIdAsync(gameId);
        return foundGame != null;
    }
}
