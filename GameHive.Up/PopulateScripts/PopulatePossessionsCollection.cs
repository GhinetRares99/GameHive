namespace GameHive.Up.PopulateScripts;

using GameHive.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class PopulatePossessionsCollection
{
    public static async Task Populate(IMongoDatabase database)
    {
        var collection = database.GetCollection<Possession>("Possession");

        var documents = new List<Possession>
        {
            new()
            {
                Id = "000000000000000000000000",
                GameId = "000000000000000000000003",
                UserId = "000000000000000000000000",
            },
            new()
            {
                Id = "000000000000000000000001",
                GameId = "000000000000000000000000",
                UserId = "000000000000000000000001",
            },
            new()
            {
                Id = "000000000000000000000002",
                GameId = "000000000000000000000001",
                UserId = "000000000000000000000001",
            },
        };

        await collection.InsertManyAsync(documents);
    }
}

