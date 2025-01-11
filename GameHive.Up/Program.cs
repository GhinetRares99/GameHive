using GameHive.Helpers;
using GameHive.Models.Settings;
using GameHive.Up.PopulateScripts;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var mongoDbSettings = config.GetSection(ConstantValues.MongoDbSection).Get<MongoDbSettings>();
var client = new MongoClient(mongoDbSettings.ConnectionString);
var database = client.GetDatabase(mongoDbSettings.DatabaseName);

// Drop the database collections to start fresh
await DropDatabase(database);

// Populate collections
await PopulatePermissionsCollection.Populate(database);
await PopulateUsersCollection.Populate(database);
await PopulateEmailTemplatesCollection.Populate(database);
await PopulateGamesCollection.Populate(database);
await PopulateTrophiesCollection.Populate(database);
await PopulatePossessionsCollection.Populate(database);


Console.WriteLine("Population completed.");

async Task DropDatabase(IMongoDatabase database)
{
    var collectionNames = await database.ListCollectionNames().ToListAsync();

    foreach (var collectionName in collectionNames) await database.DropCollectionAsync(collectionName);
}
