namespace GameHive.Up.PopulateScripts;

using GameHive.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class PopulateEmailTemplatesCollection
{
    public static async Task Populate(IMongoDatabase database)
    {
        var collection = database.GetCollection<EmailTemplate>("EmailTemplate");

        var documents = new List<EmailTemplate>
        {
            new()
            {
                Id = "658186e0f1035a32c9a20e00",
                Name = "Activate account email",
                Text = "Your activation link is: https://localhost:7022/api/User/activate?ActivationToken={ActivationToken}",
                Subject = "Activate your account",
                IsHtmlEmail = false,
            },
            new()
            {
                Id = "658186e0f1035a32c9a20e01",
                Name = "Recover password email",
                Text = "Password recovery page: https://localhost:4200/RecoverPassword?PasswordRecoveryToken={PasswordRecoveryToken}",
                Subject = "Recover your password",
                IsHtmlEmail = false,
            },
            new()
            {
                Id = "658186e0f1035a32c9a20e02",
                Name = "Purchase email",
                Text = "You have purchased {GameName} for {Price}€.",
                Subject = "Thenk you for your purchase!",
                IsHtmlEmail = false,
            },
        };

        await collection.InsertManyAsync(documents);
    }
}

