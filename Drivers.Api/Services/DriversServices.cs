
using System.Diagnostics;
using Drivers.Api.Configurations;
using Drivers.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Drivers.Api.Services;

//[DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
public class DriversServices
{
    private readonly IMongoCollection<Drive> _DriversCollection;
    public DriversServices(
        IOptions<DatabaseSetting> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionString);
            var mongoDB = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName); 
            _DriversCollection = mongoDB.GetCollection<Drive>(databaseSettings.Value.CollectionName);
        }
        public async Task<List<Drive>> GetAsync() => await _DriversCollection.Find(_ => true).ToListAsync();
        public async Task InsertDriver(Drive driver)
        {
            await _DriversCollection.InsertOneAsync(driver);
        }
        public async Task DeleteDriver(string id)
        {
            var filter = Builders<Drive>.Filter.Eq(s=>s.Id, id);
            await _DriversCollection.DeleteOneAsync(filter);
        }
        public async Task UpdateDriver(Drive driver)
        {
            var filter = Builders<Drive>.Filter.Eq(s=>s.Id, driver.Id);
            await _DriversCollection.ReplaceOneAsync(filter,driver);
        }
         public async Task GetDriverById(string id)
        {
            var filter = Builders<Drive>.Filter.Eq(s=>s.Id, id);
            await _DriversCollection.DeleteOneAsync(filter);
        }
}
