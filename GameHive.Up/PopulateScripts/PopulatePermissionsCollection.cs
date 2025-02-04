namespace GameHive.Up.PopulateScripts;

using GameHive.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

public static class PopulatePermissionsCollection
{
    public static async Task Populate(IMongoDatabase database)
    {
        var collection = database.GetCollection<Permission>("Permission");

        var documents = new List<Permission>
        {
            new()
            {
                Endpoint = "/api/User/recover",
                HttpMethod = "PUT",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/User/recover",
                HttpMethod = "PUT",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/User/update",
                HttpMethod = "PUT",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/User/update",
                HttpMethod = "PUT",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/User/get",
                HttpMethod = "GET",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/User/get",
                HttpMethod = "GET",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/User/getById",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/User/getAll",
                HttpMethod = "GET",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/User/getUserGames",
                HttpMethod = "GET",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/User/getUserGames",
                HttpMethod = "GET",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/User/getByUsername",
                HttpMethod = "POST",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/User/getByUsername",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/User/delete",
                HttpMethod = "DELETE",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/User/delete",
                HttpMethod = "DELETE",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/User/deleteById",
                HttpMethod = "DELETE",
                Role = "Admin"
            },

            new()
            {
                Endpoint = "/api/Game/add",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Game/getById",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Game/update",
                HttpMethod = "PUT",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Game/delete",
                HttpMethod = "DELETE",
                Role = "Admin"
            },

            new()
            {
                Endpoint = "/api/Trophy/add",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Trophy/getById",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Trophy/getByName",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Trophy/getAll",
                HttpMethod = "GET",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Trophy/update",
                HttpMethod = "PUT",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Trophy/delete",
                HttpMethod = "DELETE",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Trophy/deleteByGameId",
                HttpMethod = "DELETE",
                Role = "Admin"
            },

            new()
            {
                Endpoint = "/api/Possession/add",
                HttpMethod = "POST",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/Possession/add",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Possession/getByGameIdAndUserId",
                HttpMethod = "POST",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/Possession/getByGameIdAndUserId",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Possession/getByGameId",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Possession/getByUserId",
                HttpMethod = "POST",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/Possession/getByUserId",
                HttpMethod = "POST",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Possession/delete",
                HttpMethod = "DELETE",
                Role = "Client"
            },
            new()
            {
                Endpoint = "/api/Possession/delete",
                HttpMethod = "DELETE",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Possession/deleteByGameId",
                HttpMethod = "DELETE",
                Role = "Admin"
            },
            new()
            {
                Endpoint = "/api/Possession/deleteByUserId",
                HttpMethod = "DELETE",
                Role = "Admin"
            },
        };

        await collection.InsertManyAsync(documents);
    }
}

