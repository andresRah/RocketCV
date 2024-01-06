using MongoDB.Bson;
using RocketCV.Models;

namespace RocketCV.Data.Repositories;

public interface IJobPositionRepository
{
    Task InsertJobPosition(JobPosition jobPosition);
    Task<List<JobPosition>> GetAllJobPositions();
    Task<List<JobPosition>> GetJobPositions(int startingFrom, int count);
    Task<List<JobPosition>> GetJobPositionsByField(string fieldName, string fieldValue);
    Task<JobPosition> GetJobPosition(ObjectId id);
    Task<bool> UpdateUser(ObjectId id, string updateFieldName, string updateFieldValue);
    Task<bool> DeleteJobPositionById(ObjectId id);
    Task<long> DeleteAllPositions();
}