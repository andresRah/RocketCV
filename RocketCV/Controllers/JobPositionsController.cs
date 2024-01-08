namespace RocketCV.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using RocketCV.Models;
    using RocketCV.Services;
    using RocketCV.Services.Contracts;
    using RocketCV.Services.DTO;
    using System.Net;

    [ApiVersion("1.0")]
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class JobPositionsController : Controller
    {
        /// <summary>
        /// The job position service
        /// </summary>
        private readonly IJobPositionServices _business;

        /// <summary>
        /// The logger
        /// </summary>
        private readonly ILogger<JobPositionsController> _logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="JobPositionsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="business">The business.</param>
        public JobPositionsController(ILogger<JobPositionsController> logger, IJobPositionServices business)
        {
            _logger = logger;
            _business = business;
        }

        /// <summary>
        /// Gets the job position by identifier.
        /// </summary>
        /// <param name="jobPositionId">The job position identifier.</param>
        /// <returns></returns>
        [HttpGet("{jobPositionId}")]
        [Authorize(Roles = "USER")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JobPosition))]
        public async Task<IActionResult> GetJobPositionById(string jobPositionId)
        {
            try
            {
                var result = await _business.Get(jobPositionId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetJobPositionById");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Gets the job positions.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllJobPositions")]
        [Authorize(Roles = "USER")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<JobPositionDTO>))]
        public async Task<IActionResult> GetJobPositions()
        {
            try
            {
                var result = await _business.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in GetJobPositions");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Posts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(Response<JobPositionDTO>))]
        public async Task<IActionResult> Post(JobPositionDTO request)
        {
            try
            {
                var result = await _business.Insert(request);
                return Created($"api/v1/JobPositions/{result.Data?.FirstOrDefault()?.Id}", result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Updating Job Position");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Puts the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<JobPositionDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(JobPositionDTO request)
        {
            try
            {
                var result = await _business.Update(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Updating Job Position");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Deletes the specified job position identifier.
        /// </summary>
        /// <param name="jobPositionId">The job position identifier.</param>
        /// <returns></returns>
        [HttpDelete("{jobPositionId}")]
        [Authorize(Roles = "ADMIN")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Response<JobPositionDTO>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(typeof(Response<JobPositionDTO>))]
        public async Task<IActionResult> Delete(string jobPositionId)
        {
            try
            {
                var result = await _business.Delete(jobPositionId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in Updating Job Position");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
