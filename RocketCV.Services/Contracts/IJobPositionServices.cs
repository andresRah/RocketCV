namespace RocketCV.Services.Contracts
{
    using RocketCV.Models;
    using RocketCV.Services.DTO;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Threading.Tasks;

    public interface IJobPositionServices
    {
        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<JobPosition> Get(string id);

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        Task<Response<JobPositionDTO>> GetAll();

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<Response<JobPositionDTO>> Insert(JobPositionDTO entity);

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        Task<Response<JobPositionDTO>> Update(JobPositionDTO entity);

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Response<JobPositionDTO>> Delete(string id);
    }
}
