using MongoDB.Bson;
using MongoDB.Driver;
using RocketCV.Models;

namespace RocketCV.Data.Repositories
{
    public class JobPositionRepository : IJobPositionRepository
    {
        private IMongoClient _client;
        private IMongoDatabase _database;
        private IMongoCollection<JobPosition> _jobPositionsCollection;

        /// <summary>
        /// JobPositionRepository
        /// </summary>
        /// <param name="connectionString"></param>
        public JobPositionRepository(string connectionString)
        {
            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("rocketCV_DB");
            _jobPositionsCollection = _database.GetCollection<JobPosition>("JobPosition");
        }

        /// <summary>
        /// /// Checking is connection to the database established.
        /// </summary>
        /// <returns></returns>
        public bool CheckConnection()
        {
            try
            {
                _database.ListCollections();
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// InsertJobPosition
        /// </summary>
        /// <param name="jobPosition"></param>
        /// <returns></returns>
        public async Task InsertJobPosition(JobPosition jobPosition)
        {
            await _jobPositionsCollection.InsertOneAsync(jobPosition);
            Console.WriteLine("User Inserted");
        }

        /// <summary>
        /// GetAllJobPositions
        /// </summary>
        /// <returns></returns>
        public async Task<List<JobPosition>> GetAllJobPositions()
        {
            return await _jobPositionsCollection.Find(new BsonDocument()).ToListAsync();
        }

        /// <summary>
        /// GetJobPositions
        /// </summary>
        /// <param name="startingFrom"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public async Task<List<JobPosition>> GetJobPositions(int startingFrom, int count)
        {
            var result = await _jobPositionsCollection.Find(new BsonDocument())
                .Skip(startingFrom)
                .Limit(count)
                .ToListAsync();

            return result;
        }

        /// <summary>
        /// GetJobPositionsByField
        /// </summary>
        /// <param name="fieldName"></param>
        /// <param name="fieldValue"></param>
        /// <returns></returns>
        public async Task<List<JobPosition>> GetJobPositionsByField(string fieldName, string fieldValue)
        {
            var filter = Builders<JobPosition>.Filter.Eq(fieldName, fieldValue);
            var result = await _jobPositionsCollection.Find(filter).ToListAsync();

            return result;
        }

        /// <summary>
        /// GetJobPosition
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<JobPosition> GetJobPosition(ObjectId id)
        {
            var filter = Builders<JobPosition>.Filter.Eq("_id", id);
            var result = await _jobPositionsCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        /// <summary>
        /// UpdateUser
        /// </summary>
        /// <param name="id"></param>
        /// <param name="updateFieldName"></param>
        /// <param name="updateFieldValue"></param>
        /// <returns></returns>
        public async Task<bool> UpdateUser(ObjectId id, string updateFieldName, string updateFieldValue)
        {
            var filter = Builders<JobPosition>.Filter.Eq("_id", id);
            var update = Builders<JobPosition>.Update.Set(updateFieldName, updateFieldValue);

            var result = await _jobPositionsCollection.UpdateOneAsync(filter, update);

            return result.ModifiedCount != 0;
        }


        /// <summary>
        /// DeleteJobPositionById
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteJobPositionById(ObjectId id)
        {
            var filter = Builders<JobPosition>.Filter.Eq("_id", id);
            var result = await _jobPositionsCollection.DeleteOneAsync(filter);

            return result.DeletedCount != 0;
        }

        /// <summary>
        /// DeleteAllPositions
        /// </summary>
        /// <returns></returns>
        public async Task<long> DeleteAllPositions()
        {
            var filter = new BsonDocument();
            var result = await _jobPositionsCollection.DeleteManyAsync(filter);

            return result.DeletedCount;
        }
    }
}
