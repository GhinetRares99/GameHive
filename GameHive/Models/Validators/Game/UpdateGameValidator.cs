// <copyright file="UpdateGameValidator.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Models.Validators.Game;

using FluentValidation;
using GameHive.Helpers;
using GameHive.Models.Requests.Game;
using GameHive.Services.Repositories.GameRepository;

/// <summary>
/// Validator for the game update process.
/// </summary>
public class UpdateGameValidator : AbstractValidator<UpdateGameRequest>
{
    private readonly GameRepository gameRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateGameValidator"/> class.
    /// </summary>
    /// <param name="gameRepository">The game repository.</param>
    public UpdateGameValidator(GameRepository gameRepository)
    {
        this.gameRepository = gameRepository;
        this.RuleFor(model => model.Name)
            .NotEmpty().WithMessage(ConstantValues.NameIsRequired)
            .DependentRules(() =>
            {
                this.RuleFor(model => model)
                    .MustAsync(this.UpdatedNameIsUnique).WithMessage(ConstantValues.GameNameAlreadyExists);
            });
        this.RuleFor(model => model.Description)
            .NotEmpty().WithMessage(ConstantValues.DescriptionIsRequired);
        this.RuleFor(model => model.Genre)
            .NotEmpty().WithMessage(ConstantValues.GenreIsRequired);
        this.RuleFor(model => model.Price)
            .GreaterThanOrEqualTo(0.00).WithMessage(ConstantValues.PriceMustBeGreaterOrEqualToZero);
        this.RuleFor(model => model.MinimumSupportedOS)
            .NotEmpty().WithMessage(ConstantValues.MinimumSupportedOSIsRequired);
        this.RuleFor(model => model.MinimumSupportedGraphicsCard)
            .NotEmpty().WithMessage(ConstantValues.MinimumSupportedGraphicsCardIsRequired);
        this.RuleFor(model => model.MinimumSupportedProcessor)
            .NotEmpty().WithMessage(ConstantValues.MinimumSupportedProcessorIsRequired);
        this.RuleFor(model => model.MinimumSupportedMemory)
            .NotEmpty().WithMessage(ConstantValues.MinimumSupportedMemoryIsRequired);
        this.RuleFor(model => model.Storage)
            .NotEmpty().WithMessage(ConstantValues.StorageIsRequired);
        this.RuleFor(model => model.PicOne)
            .NotEmpty().WithMessage(ConstantValues.PicOneIsRequired);
        this.RuleFor(model => model.PicTwo)
            .NotEmpty().WithMessage(ConstantValues.PicTwoIsRequired);
        this.RuleFor(model => model.PicThree)
            .NotEmpty().WithMessage(ConstantValues.PicThreeIsRequired);
    }

    private async Task<bool> UpdatedNameIsUnique(Models.Game game, CancellationToken cancellationToken = default)
    {
        var foundGameById = await this.gameRepository.GetByIdAsync(game.Id);
        var foundGame = await this.gameRepository.FindGameByName(game.Name);

        if (foundGameById?.Name == game.Name && foundGameById != null)
        {
            return true;
        }

        return foundGame == null;
    }
}