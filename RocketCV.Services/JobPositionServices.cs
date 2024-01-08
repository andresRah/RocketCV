using RocketCV.Utils;

namespace RocketCV.Services
{
    using RocketCV.Services.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RocketCV.Services.DTO;
    using Amazon.Runtime.Internal;
    using System.Net;
    using MongoDB.Bson;
    using RocketCV.Models;
    using System.Collections.ObjectModel;
    using RocketCV.Data.Repositories;
    using RocketCV.Utils.Resources;
    using SharpCompress.Common;

    /// <summary>
    /// JobPositionServices
    /// </summary>
    /// <seealso cref="JobPositionDTO" />
    /// <seealso cref="RocketCV.Services.Contracts.IJobPositionServices" />
    public class JobPositionServices : BusinessBase<JobPositionDTO>, IJobPositionServices
    {
        /// <summary>
        /// The repository
        /// </summary>
        private readonly IJobPositionRepository _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobPositionServices"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public JobPositionServices(IJobPositionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Gets the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<JobPosition> Get(string id)
        {
            var objectId = new ObjectId(id);
            var result = await _repository.GetJobPosition(objectId);

            return result;
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns></returns>
        public async Task<Response<JobPositionDTO>> GetAll()
        {
            try
            {
                var result = await _repository.GetAllJobPositions();

                var jobPositionsFiltered = result.Where(x => x.IsDisabled == false).Select(jobPosition =>
                    new JobPositionDTO
                    {
                        Title = jobPosition.Title,
                        CompanyName = jobPosition.CompanyName,
                        Description = jobPosition.Description,
                        StartDate = jobPosition.StartDate,
                        EndDate = jobPosition.EndDate,
                        City = jobPosition.City,
                        Country = jobPosition.Country,
                        IsCurrent = jobPosition.IsCurrent,
                        IsRemote = jobPosition.IsRemote,
                        IsFreelance = jobPosition.IsFreelance,
                        IsPartTime = jobPosition.IsPartTime,
                        IsInternship = jobPosition.IsInternship,
                        IsVolunteer = jobPosition.IsVolunteer,
                        CreatedDate = jobPosition.CreatedDate,
                        LastModifiedDate = jobPosition.LastModifiedDate
                    }).ToList();

                return ResponseSuccess(jobPositionsFiltered);
            }
            catch (Exception ex)
            {
                return ResponseFail(HttpStatusCode.InternalServerError,
                    new Collection<string>
                    {
                        ResponseMessages.InternalError,
                        ex.Message
                    }
                );
            }
        }

        /// <summary>
        /// Inserts the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<Response<JobPositionDTO>> Insert(JobPositionDTO entity)
        {
            try
            {
                if (entity.Validate().Count > 0)
                {
                    return ResponseFail(HttpStatusCode.BadRequest, new Collection<string>
                    {
                        ResponseMessages.BadRequest
                    });
                }

                // TODO: Use auto-mapper
                var jobPosition = new JobPosition
                {
                    Title = entity.Title,
                    CompanyName = entity.CompanyName,
                    Description = entity.Description,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    City = entity.City,
                    Country = entity.Country,
                    IsCurrent = entity.IsCurrent,
                    IsRemote = entity.IsRemote,
                    IsFreelance = entity.IsFreelance,
                    IsPartTime = entity.IsPartTime,
                    IsInternship = entity.IsInternship,
                    IsVolunteer = entity.IsVolunteer,
                    CreatedDate = DateTime.Now,
                    LastModifiedDate = DateTime.Now
                };

                await _repository.InsertJobPosition(jobPosition);

                return ResponseSuccess(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return ResponseFail(HttpStatusCode.InternalServerError,
                    new Collection<string>
                    {
                        ResponseMessages.InternalError,
                        ex.Message
                    }
                );
            }
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns></returns>
        public async Task<Response<JobPositionDTO>> Update(JobPositionDTO entity)
        {
            try
            {
                if (entity.Id == null)
                {
                    return ResponseFail(HttpStatusCode.BadRequest,
                        new Collection<string>
                        {
                            ResponseMessages.BadRequest
                        });
                }

                var objectId = new ObjectId(entity.Id);

                // TODO: Use auto-mapper
                var jobPosition = new JobPosition
                {
                    Title = entity.Title,
                    CompanyName = entity.CompanyName,
                    Description = entity.Description,
                    StartDate = entity.StartDate,
                    EndDate = entity.EndDate,
                    City = entity.City,
                    Country = entity.Country,
                    IsCurrent = entity.IsCurrent,
                    IsRemote = entity.IsRemote,
                    IsFreelance = entity.IsFreelance,
                    IsPartTime = entity.IsPartTime,
                    IsInternship = entity.IsInternship,
                    IsVolunteer = entity.IsVolunteer,
                    LastModifiedDate = DateTime.Now
                };

                await _repository.UpdateJobPosition(objectId, jobPosition);

                return ResponseSuccess(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return ResponseFail(HttpStatusCode.InternalServerError,
                    new Collection<string>
                    {
                        ResponseMessages.InternalError,
                        ex.Message
                    });
            }
        }

        /// <summary>
        /// Deletes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<Response<JobPositionDTO>> Delete(string id)
        {
            try
            {
                var objectId = new ObjectId(id);

                var jobPosition = await _repository.GetJobPosition(objectId);

                if (jobPosition.Id == ObjectId.Empty)
                {
                    return ResponseFail(HttpStatusCode.NotFound,
                        new Collection<string>
                                               {
                            ResponseMessages.NotFound
                        });
                }

                var status = await _repository.DeleteJobPositionById(objectId);

                return ResponseSuccess(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return ResponseFail(HttpStatusCode.InternalServerError,
                    new Collection<string>
                    {
                        ResponseMessages.InternalError,
                        ex.Message
                    });
            }
        }
    }
}
