// <copyright file="ConstantValues.cs" company="Ghinet Rares">
// Copyright (c) Ghinet Rares. All rights reserved.
// </copyright>

namespace GameHive.Helpers;

/// <summary>
/// A static class for constants.
/// </summary>
public static class ConstantValues
{
    // JSON values

    /// <summary>
    /// Gets the MongoDbSection constant.
    /// </summary>
    public const string MongoDbSection = "Options:MongoDB";

    /// <summary>
    /// Gets the TokenSettingsSection constant.
    /// </summary>
    public const string TokenSettingsSection = "Options:TokenSettings";

    /// <summary>
    /// Gets the AuthenticationSettingsSection constant.
    /// </summary>
    public const string AuthenticationSettingsSection = "Options:AuthenticationSettings";

    /// <summary>
    /// Gets the CorsSettingsSection constant.
    /// </summary>
    public const string CorsSettingsSection = "Options:CorsSettings";

    /// <summary>
    /// Gets the TokenGenerationSection constant.
    /// </summary>
    public const string TokenGenerationSection = "Options:TokenSettings:TokenGenerationKeyValue";

    /// <summary>
    /// Gets the ActivationTokenGenerationSection constant.
    /// </summary>
    public const string ActivationTokenGenerationSection = "Options:TokenSettings:ActivationTokenGenerationKeyValue";

    /// <summary>
    /// Gets the DefaultUserRoleSection constant.
    /// </summary>
    public const string DefaultUserRoleSection = "Options:DefaultUserRole:RoleName";

    /// <summary>
    /// Gets the IssuerSection constant.
    /// </summary>
    public const string IssuerSection = "Options:AuthenticationSettings:Issuer";

    /// <summary>
    /// Gets the AudienceSection constant.
    /// </summary>
    public const string AudienceSection = "Options:AuthenticationSettings:Audience";

    /// <summary>
    /// Gets the ActivationExpirationTimeSection constant.
    /// </summary>
    public const string ActivationExpirationTimeSection = "Options:ExpirationTimes:ActivationExpirationTime";

    /// <summary>
    /// Gets the RecoverPasswordExpirationTimeSection constant.
    /// </summary>
    public const string RecoverPasswordExpirationTimeSection = "Options:ExpirationTimes:RecoverPasswordExpirationTime";

    /// <summary>
    /// Gets the EmailSection constant.
    /// </summary>
    public const string EmailSection = "Options:Email";

    // Not configured

    /// <summary>
    /// Gets the TokenSettingsNotConfigured constant.
    /// </summary>
    public const string TokenSettingsNotConfigured = "TokenSettings is not configured.";

    /// <summary>
    /// Gets the AuthenticationSettingsNotConfigured constant.
    /// </summary>
    public const string AuthenticationSettingsNotConfigured = "AuthenticationSettings is not configured.";

    // Validation

    /// <summary>
    /// Gets the EmailIsRequired constant.
    /// </summary>
    public const string EmailIsRequired = "The email address is required!";

    /// <summary>
    /// Gets the BalanceMustBeGreaterOrEqualToZero constant.
    /// </summary>
    public const string BalanceMustBeGreaterOrEqualToZero = "The balance number must be greater than or equal to 0.";

    /// <summary>
    /// Gets the PasswordIsRequired constant.
    /// </summary>
    public const string PasswordIsRequired = "The password is required!";

    /// <summary>
    /// Gets the UsernameIsRequired constant.
    /// </summary>
    public const string UsernameIsRequired = "The username is required!";

    /// <summary>
    /// Gets the ProfilePicIsRequired constant.
    /// </summary>
    public const string ProfilePicIsRequired = "The profile picture is required!";

    /// <summary>
    /// Gets the InvalidEmailFormat constant.
    /// </summary>
    public const string InvalidEmailFormat = "The email format is invalid!";

    /// <summary>
    /// Gets the PasswordMinimumLength6 constant.
    /// </summary>
    public const string PasswordMinimumLength6 = "The password must be at least 6 characters long!";

    /// <summary>
    /// Gets the UserAlreadyExists constant.
    /// </summary>
    public const string UserAlreadyExists = "This user already exists.";

    /// <summary>
    /// Gets the UsernameIsInUse constant.
    /// </summary>
    public const string UsernameIsInUse = "This username is already in use.";

    /// <summary>
    /// Gets the UserNotActivated constant.
    /// </summary>
    public const string UserNotActivated = "The user is not activated.";

    /// <summary>
    /// Gets the NewPasswordRequired constant.
    /// </summary>
    public const string NewPasswordRequired = "A new password is required, this one is currently in use.";

    /// <summary>
    /// Gets the IncorrectEmailOrPassword constant.
    /// </summary>
    public const string IncorrectEmailOrPassword = "Email or password is incorrect.";

    /// <summary>
    /// Gets the UserAlreadyActivated constant.
    /// </summary>
    public const string UserAlreadyActivated = "The user is already activated.";

    /// <summary>
    /// Gets the ActivationLinkExpired constant.
    /// </summary>
    public const string ActivationLinkExpired = "The activation link has expired.";

    /// <summary>
    /// Gets the ActivationTokenIncorrect constant.
    /// </summary>
    public const string ActivationTokenIncorrect = "Activation token is incorrect.";

    /// <summary>
    /// Gets the NameIsRequired constant.
    /// </summary>
    public const string NameIsRequired = "The name is required!";

    /// <summary>
    /// Gets the DescriptionIsRequired constant.
    /// </summary>
    public const string DescriptionIsRequired = "The description is required!";

    /// <summary>
    /// Gets the GenreIsRequired constant.
    /// </summary>
    public const string GenreIsRequired = "The genre is required!";

    /// <summary>
    /// Gets the PriceMustBeGreaterOrEqualToZero constant.
    /// </summary>
    public const string PriceMustBeGreaterOrEqualToZero = "The price must be greater than or equal to 0.";

    /// <summary>
    /// Gets the PicOneIsRequired constant.
    /// </summary>
    public const string PicOneIsRequired = "The first picture is required!";

    /// <summary>
    /// Gets the PicTwoIsRequired constant.
    /// </summary>
    public const string PicTwoIsRequired = "The second picture is required!";

    /// <summary>
    /// Gets the PicThreeIsRequired constant.
    /// </summary>
    public const string PicThreeIsRequired = "The third picture is required!";

    /// <summary>
    /// Gets the MinimumSupportedOSIsRequired constant.
    /// </summary>
    public const string MinimumSupportedOSIsRequired = "The minimum supported OS is required!";

    /// <summary>
    /// Gets the MinimumSupportedGraphicsCardIsRequired constant.
    /// </summary>
    public const string MinimumSupportedGraphicsCardIsRequired = "The minimum supported graphics card is required!";

    /// <summary>
    /// Gets the MinimumSupportedProcessorIsRequired constant.
    /// </summary>
    public const string MinimumSupportedProcessorIsRequired = "The minimum supported processor is required!";

    /// <summary>
    /// Gets the MinimumSupportedMemoryIsRequired constant.
    /// </summary>
    public const string MinimumSupportedMemoryIsRequired = "The minimum supported memory is required!";

    /// <summary>
    /// Gets the StorageIsRequired constant.
    /// </summary>
    public const string StorageIsRequired = "The storage is required!";

    /// <summary>
    /// Gets the GameNameAlreadyExists constant.
    /// </summary>
    public const string GameNameAlreadyExists = "A game with this name already exists.";

    /// <summary>
    /// Gets the IconUrlIsRequired constant.
    /// </summary>
    public const string IconUrlIsRequired = "The icon URL is required!";

    /// <summary>
    /// Gets the GameIdIsRequired constant.
    /// </summary>
    public const string GameIdIsRequired = "The game id is required!";

    /// <summary>
    /// Gets the UserIdIsRequired constant.
    /// </summary>
    public const string UserIdIsRequired = "The user id is required!";

    /// <summary>
    /// Gets the TrophyNameAlreadyExists constant.
    /// </summary>
    public const string TrophyNameAlreadyExists = "A trophy with this name already exists.";

    /// <summary>
    /// Gets the GameOwned constant.
    /// </summary>
    public const string GameOwned = "The game is already owned.";

    // Error messages

    /// <summary>
    /// Gets the InternalServerError constant.
    /// </summary>
    public const string InternalServerError = "Internal server error.";

    /// <summary>
    /// Gets the BadRequestValidation constant.
    /// </summary>
    public const string BadRequestValidation = "Validation for {0} has failed.";

    /// <summary>
    /// Gets the GetAllNotFound constant.
    /// </summary>
    public const string GetAllNotFound = "No entities of type {0} found.";

    /// <summary>
    /// Gets the GetNotFound constant.
    /// </summary>
    public const string GetNotFound = "{0} with id {1} not found.";

    /// <summary>
    /// Gets the UserDoesNotExist constant.
    /// </summary>
    public const string UserDoesNotExist = "This user does not exist.";

    /// <summary>
    /// Gets the GameDoesNotExist constant.
    /// </summary>
    public const string GameDoesNotExist = "This game does not exist.";

    /// <summary>
    /// Gets the TrophyDoesNotExist constant.
    /// </summary>
    public const string TrophyDoesNotExist = "This trophy does not exist.";

    /// <summary>
    /// Gets the PossessionDoesNotExist constant.
    /// </summary>
    public const string PossessionDoesNotExist = "This possession does not exist.";

    /// <summary>
    /// Gets the FailedToDeleteTrophies constant.
    /// </summary>
    public const string FailedToDeleteTrophies = "Failed to delete trophies.";

    // Success messages

    /// <summary>
    /// Gets the RecoverEmailSent constant.
    /// </summary>
    public const string RecoverEmailSent = "Recover email sent.";

    /// <summary>
    /// Gets the UserRegisteredSuccessfully constant.
    /// </summary>
    public const string UserRegisteredSuccessfully = "User registered successfully.";

    /// <summary>
    /// Gets the UserUpdatedSuccessfully constant.
    /// </summary>
    public const string UserUpdatedSuccessfully = "User updated successfully.";

    /// <summary>
    /// Gets the PasswordUpdatedSuccessfully constant.
    /// </summary>
    public const string PasswordUpdatedSuccessfully = "Password updated successfully.";

    /// <summary>
    /// Gets the GameAddedSuccessfully constant.
    /// </summary>
    public const string GameAddedSuccessfully = "Game added successfully.";

    /// <summary>
    /// Gets the GameUpdatedSuccessfully constant.
    /// </summary>
    public const string GameUpdatedSuccessfully = "Game updated successfully.";

    /// <summary>
    /// Gets the TrophyAddedSuccessfully constant.
    /// </summary>
    public const string TrophyAddedSuccessfully = "Trophy added successfully.";

    /// <summary>
    /// Gets the TrophyUpdatedSuccessfully constant.
    /// </summary>
    public const string TrophyUpdatedSuccessfully = "Trophy updated successfully.";

    /// <summary>
    /// Gets the UserActivatedSuccessfully constant.
    /// </summary>
    public const string UserActivatedSuccessfully = "User activated successfully.";

    /// <summary>
    /// Gets the LoginSuccessful constant.
    /// </summary>
    public const string LoginSuccessful = "Login successful.";

    /// <summary>
    /// Gets the GetAllSuccessful constant.
    /// </summary>
    public const string GetAllSuccessful = "{0} entities retrieved successfully.";

    /// <summary>
    /// Gets the GetSuccessful constant.
    /// </summary>
    public const string GetSuccessful = "{0} retrieved successfully.";

    /// <summary>
    /// Gets the UserDeletedSuccessfully constant.
    /// </summary>
    public const string UserDeletedSuccessfully = "User deleted successfully.";

    /// <summary>
    /// Gets the GameDeletedSuccessfully constant.
    /// </summary>
    public const string GameDeletedSuccessfully = "Game deleted successfully.";

    /// <summary>
    /// Gets the TrophyDeletedSuccessfully constant.
    /// </summary>
    public const string TrophyDeletedSuccessfully = "Trophy deleted successfully.";

    /// <summary>
    /// Gets the TrophiesDeletedSuccessfully constant.
    /// </summary>
    public const string TrophiesDeletedSuccessfully = "Trophies deleted successfully.";

    /// <summary>
    /// Gets the PossessionAddedSuccessfully constant.
    /// </summary>
    public const string PossessionAddedSuccessfully = "Possession added successfully.";
}