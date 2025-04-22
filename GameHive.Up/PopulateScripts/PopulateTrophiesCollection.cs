namespace GameHive.Up.PopulateScripts;

using GameHive.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class PopulateTrophiesCollection
{
    public static async Task Populate(IMongoDatabase database)
    {
        var collection = database.GetCollection<Trophy>("Trophy");

        var documents = new List<Trophy>
        {
            new()
            {
                Id = "000000000000000000000000",
                GameId = "000000000000000000000001",
                Name = "Masterthief",
                Description = "Steal and deliver 100 vehicles.",
                IconUrl = "DefaultTrophy.jpg",
            },
            new()
            {
                Id = "000000000000000000000001",
                GameId = "000000000000000000000000",
                Name = "Gun Mastery",
                Description = "Kill 100 enemies with each gun.",
                IconUrl = "DefaultTrophy.jpg",
            },
            new()
            {
                Id = "000000000000000000000002",
                GameId = "000000000000000000000000",
                Name = "Bomberman",
                Description = "Plant the bomb on each map.",
                IconUrl = "DefaultTrophy.jpg",
            },
            new()
            {
                Id = "000000000000000000000003",
                GameId = "000000000000000000000005",
                Name = "Legend",
                Description = "Achieve 100% completion.",
                IconUrl = "DefaultTrophy.jpg",
            },
        };

        await collection.InsertManyAsync(documents);
    }
}

