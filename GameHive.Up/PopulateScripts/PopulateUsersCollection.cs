namespace GameHive.Up.PopulateScripts;

using GameHive.Helpers;
using GameHive.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class PopulateUsersCollection
{
    public static async Task Populate(IMongoDatabase database)
    {
        var collection = database.GetCollection<User>("User");

        var documents = new List<User>
        {
            new()
            {
                Id = "000000000000000000000000",
                Email = "test.client@gmail.com",
                Password = Hasher.HashPassword("testpasswordclient"),
                Username = "Clnt",
                CountryOfResidence = "Romania",
                Role = "Client",
                Status = "Active",
                Balance = 100,
                ProfilePic = "Default.jpg"
            },
            new()
            {
                Id = "000000000000000000000001",
                Email = "test.admin@gmail.com",
                Password = Hasher.HashPassword("testpasswordadmin"),
                Username = "Adm",
                CountryOfResidence = "Romania",
                Role = "Admin",
                Status = "Active",
                Balance = 200,
                ProfilePic = "Default.jpg"
            },
        };

        await collection.InsertManyAsync(documents);
    }
}

