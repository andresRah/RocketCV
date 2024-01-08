using MongoDB.Bson;
using RocketCV.Models;

namespace RocketCV.Data.Repositories;

public interface IJobPositionRepository
{
    /// <summary>
    /// Checks the connection.
    /// </summary>
    bool CheckConnection();

    /// <summary>
    /// Inserts the job position.
    /// </summary>
    /// <param name="jobPosition">The job position.</param>
    /// <returns></returns>
    Task InsertJobPosition(JobPosition jobPosition);

    /// <summary>
    /// Gets all job positions.
    /// </summary>
    /// <returns></returns>
    Task<List<JobPosition>> GetAllJobPositions();

    /// <summary>
    /// Gets the job positions.
    /// </summary>
    /// <param name="startingFrom">The starting from.</param>
    /// <param name="count">The count.</param>
    /// <returns></returns>
    Task<List<JobPosition>> GetJobPositions(int startingFrom, int count);

    /// <summary>
    /// Gets the job positions by field.
    /// </summary>
    /// <param name="fieldName">Name of the field.</param>
    /// <param name="fieldValue">The field value.</param>
    /// <returns></returns>
    Task<List<JobPosition>> GetJobPositionsByField(string fieldName, string fieldValue);

    /// <summary>
    /// Gets the job position.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<JobPosition> GetJobPosition(ObjectId id);

    /// <summary>
    /// Updates the job position
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="updateFieldName">Name of the update field.</param>
    /// <param name="updateFieldValue">The update field value.</param>
    /// <returns></returns>
    Task<bool> UpdateJobPosition(ObjectId id, string updateFieldName, string updateFieldValue);

    /// <summary>
    /// Updates the job position.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <param name="jobPosition">The job position.</param>
    /// <returns></returns>
    Task<bool> UpdateJobPosition(ObjectId id, JobPosition jobPosition);

    /// <summary>
    /// Deletes the job position by identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns></returns>
    Task<bool> DeleteJobPositionById(ObjectId id);

    /// <summary>
    /// Deletes all positions.
    /// </summary>
    /// <returns></returns>
    Task<long> DeleteAllPositions();
}