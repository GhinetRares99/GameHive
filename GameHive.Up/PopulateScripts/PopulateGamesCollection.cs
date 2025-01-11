namespace GameHive.Up.PopulateScripts;

using GameHive.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;


public static class PopulateGamesCollection
{
    public static async Task Populate(IMongoDatabase database)
    {
        var collection = database.GetCollection<Game>("Game");

        var documents = new List<Game>
        {
            new()
            {
                Id = "000000000000000000000000",
                Name = "Counter Strike: Global Offensive",
                Description = "Join a team of four other players and compete in an elite environment.",
                Genre = "FPS",
                Price = 15.00,
                MinimumSupportedOS = "Windows 8",
                MinimumSupportedGraphicsCard = "GeForce 840M",
                MinimumSupportedProcessor = "Pentium 4415U",
                MinimumSupportedMemory = "8GB RAM",
                Storage = "85GB",
                PicOne = "CSGOCover.jpg",
                PicTwo = "CSGOPicTwo.jpg",
                PicThree = "CSGOPicThree.jpg",
            },
            new()
            {
                Id = "000000000000000000000001",
                Name = "Grand Theft Auto 5",
                Description = "Enter the world of Los Santos and take control of three different characters to rise in the criminal world.",
                Genre = "Open World",
                Price = 39.99,
                MinimumSupportedOS = "Windows 10",
                MinimumSupportedGraphicsCard = "GeForce GTX 1080 Max-Q",
                MinimumSupportedProcessor = "Celeron N3350",
                MinimumSupportedMemory = "4GB RAM",
                Storage = "120GB",
                PicOne = "GTA5Cover.jpg",
                PicTwo = "GTA5PicTwo.jpg",
                PicThree = "GTA5PicThree.jpg",
            },
            new()
            {
                Id = "000000000000000000000002",
                Name = "War Thunder",
                Description = "Join other players and battle with more than a thousand land, sea and air vehicles.",
                Genre = "Simulation",
                Price = 0.00,
                MinimumSupportedOS = "Windows 8",
                MinimumSupportedGraphicsCard = "GeForce GTX 1060",
                MinimumSupportedProcessor = "Celeron 110X",
                MinimumSupportedMemory = "4GB RAM",
                Storage = "40GB",
                PicOne = "WarThunderCover.jpg",
                PicTwo = "WarThunderPicTwo.jpg",
                PicThree = "WarThunderPicThree.jpg",
            },
            new()
            {
                Id = "000000000000000000000003",
                Name = "Metin 2",
                Description = "Take part in legendary adventures and vanquish the evil that has taken hold across the kingdom.",
                Genre = "MMORPG",
                Price = 0.00,
                MinimumSupportedOS = "Windows 7",
                MinimumSupportedGraphicsCard = "GeForce 9800 GTX",
                MinimumSupportedProcessor = "Pentium 3 M1A4",
                MinimumSupportedMemory = "1GB RAM",
                Storage = "10GB",
                PicOne = "Metin2Cover.jpg",
                PicTwo = "Metin2PicTwo.jpg",
                PicThree = "Metin2PicThree.jpg",
            },
        };

        await collection.InsertManyAsync(documents);
    }
}

