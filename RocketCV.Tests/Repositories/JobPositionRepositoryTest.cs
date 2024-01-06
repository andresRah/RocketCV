using MongoDB.Bson;

namespace RocketCV.Tests.Repositories
{
    using RocketCV.Data.Repositories;
    using RocketCV.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JobPositionRepositoryTest
    {
        private readonly IJobPositionRepository _mongoDbRepo = new JobPositionRepository("mongodb://127.0.0.1:27017");

        /// <summary>
        /// Initialize
        /// </summary>
        /// <returns></returns>
        private async Task Initialize()
        {
            var jobPosition1 = new JobPosition
            {
                Title = "C# Developer",
                CompanyName = "ABC Company",
                Description = "Software Engineer specializing in backend development. Experienced with all stages of the development cycle for dynamic web projects. Well-versed in numerous programming languages including JavaScript, SQL, and C. Stng background in project management and customer relations.",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                City = "New York",
                Country = "USA",
                IsCurrent = true,
                IsFreelance = false,
                IsInternship = false,
                IsPartTime = false,
                IsRemote = false,
                IsVolunteer = false
            };
            await _mongoDbRepo.InsertJobPosition(jobPosition1);

            var jobPosition2 = new JobPosition
            {
                Title = "Product Manager",
                CompanyName = "XYZ Corporation",
                Description = "Product Manager for the new ABC product",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                City = "San Francisco",
                Country = "USA",
                IsCurrent = true,
                IsFreelance = false,
                IsInternship = false,
                IsPartTime = false,
                IsRemote = false,
                IsVolunteer = false
            };
            await _mongoDbRepo.InsertJobPosition(jobPosition2);

            var jobPosition3 = new JobPosition
            {
                Title = "Data Analyst",
                CompanyName = "123 Industries",
                Description = "Data Analyst for the new XYC product",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                City = "London",
                Country = "UK",
                IsCurrent = true,
                IsFreelance = false,
                IsInternship = false,
                IsPartTime = false,
                IsRemote = false,
                IsVolunteer = false
            };
            await _mongoDbRepo.InsertJobPosition(jobPosition3);
        }

        /// <summary>
        /// Cleanup
        /// </summary>
        /// <returns></returns>
        private async Task Cleanup()
        {
            await _mongoDbRepo.DeleteAllPositions();
        }

        [Fact]
        public async void CheckConnection_DbAvailable_ConnectionEstablished()
        {
            await Initialize();

            var connected = _mongoDbRepo.CheckConnection();
            Assert.True(connected);

            await Cleanup();
        }

        /// <summary>
        /// Test is ignored, because it lasts 30 seconds.
        /// </summary>
        [Fact]
        public void CheckConnection_DbNotAvailable_ConnectionFailed()
        {
            var mongoDbRepo = new JobPositionRepository("mongodb://127.0.0.1:27010");
            var connected = mongoDbRepo.CheckConnection();
            Assert.False(connected);
        }

        [Fact]
        public async Task GetAllJobPositions_ReadAllJobPositions_CountIsExpected()
        {
            await Initialize();

            var jobPositions = await _mongoDbRepo.GetAllJobPositions();
            Assert.Equal(3, jobPositions.Count);

            await Cleanup();
        }

        [Fact]
        public async Task GetJobPositionByField_GetJobPositionByCompanyNameAndJobPositionExists_JobPositionReturned()
        {
            await Initialize();

            var jobPositions = await _mongoDbRepo.GetJobPositionsByField("CompanyName", "123 Industries");
            Assert.Single(jobPositions);

            await Cleanup();
        }

        [Fact]
        public async Task GetJobPositionByField_GetJobPositionByBlogAndJobPositionExists_JobPositionReturned()
        {
            await Initialize();

            var jobPositions = await _mongoDbRepo.GetJobPositionsByField("CompanyName", "123 Industries");
            Assert.Single(jobPositions);

            await Cleanup();
        }

        [Fact]
        public async Task GetJobPositionByField_GetJobPositionByNameAndJobPositionDoesNotExists_JobPositionNotReturned()
        {
            await Initialize();

            var jobPositions = await _mongoDbRepo.GetJobPositionsByField("CompanyName", "ABB Company");
            Assert.Empty(jobPositions);

            await Cleanup();
        }

        [Fact]
        public async Task GetJobPositionByField_WrongField_JobPositionNotReturned()
        {
            await Initialize();

            var jobPositions = await _mongoDbRepo.GetJobPositionsByField("badFieldName", "value");

            Assert.Empty(jobPositions);

            await Cleanup();
        }

        [Fact]
        public async Task GetJobPositionCount_JustFirstElement_Success()
        {
            await Initialize();

            var jobPositions = await _mongoDbRepo.GetJobPositions(0, 1);

            Assert.Single(jobPositions);

            await Cleanup();
        }

        [Fact]
        public async Task InsertJobPosition_JobPositionInserted_CountIsExpected()
        {
            await Initialize();

            var jobPosition = new JobPosition
            {
                Title = "PHP Developer",
                CompanyName = "ABC Company",
                Description = "Software Engineer specializing in backend development. Experienced with all stages of the development cycle for dynamic web projects. Well-versed in numerous programming languages including JavaScript, SQL, and C. Stng background in project management and customer relations.",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                City = "New York",
                Country = "USA",
                IsCurrent = true,
                IsFreelance = false,
                IsInternship = false,
                IsPartTime = false,
                IsRemote = false,
                IsVolunteer = false
            };

            var jobPositions = await _mongoDbRepo.GetAllJobPositions();
            var countBeforeInsert = jobPositions.Count;

            await _mongoDbRepo.InsertJobPosition(jobPosition);

            jobPositions = await _mongoDbRepo.GetAllJobPositions();
            Assert.Equal(countBeforeInsert + 1, jobPositions.Count);

            await Cleanup();
        }

        [Fact]
        public async Task DeleteJobPositionById_JobPositionDeleted_GoodReturnValue()
        {
            await Initialize();

            var jobPosition = new JobPosition()
            {
                Title = "Ruby Developer",
                CompanyName = "ABC Company",
                Description = "Software Engineer specializing in backend development. Experienced with all stages of the development cycle for dynamic web projects. Well-versed in numerous programming languages including JavaScript, SQL, and C. Stng background in project management and customer relations.",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                City = "New York",
                Country = "USA",
                IsCurrent = true,
                IsFreelance = false,
                IsInternship = false,
                IsPartTime = false,
                IsRemote = false,
                IsVolunteer = false
            };

            await _mongoDbRepo.InsertJobPosition(jobPosition);

            var deleteJobPosition = await _mongoDbRepo.GetJobPositionsByField("Title", jobPosition.Title);
            var result = await _mongoDbRepo.DeleteJobPositionById(deleteJobPosition.Single().Id);

            Assert.True(result);

            await Cleanup();
        }

        [Fact]
        public async Task DeleteJobPositionById_JobPositionDoesNotExist_NothingIsDeleted()
        {
            await Initialize();

            var result = await _mongoDbRepo.DeleteJobPositionById(ObjectId.Empty);

            Assert.False(result);

            await Cleanup();
        }

        [Fact]
        public async Task DeleteAllJobPositions_DeletingEverything_Success()
        {
            await Initialize();

            var result = await _mongoDbRepo.DeleteAllPositions();

            Assert.Equal(3, result);

            await Cleanup();
        }

        [Fact]
        public async Task UpdateJobPosition_UpdateTopLevelField_JobPositionModified()
        {
            await Initialize();

            var jobPositions = await _mongoDbRepo.GetJobPositionsByField("Title", "C# Developer");
            var jobPosition = jobPositions.FirstOrDefault();

            if (jobPosition == null)
            {
                Assert.True(false);
            }

            await _mongoDbRepo.UpdateJobPosition(jobPosition.Id, "Title", "Ruby and Rails Developer");

            jobPositions = await _mongoDbRepo.GetJobPositionsByField("Title", "Ruby and Rails Developer");
            jobPosition = jobPositions.FirstOrDefault();

            if (jobPosition == null)
            {
                Assert.True(false);
            }

            Assert.Equal("Ruby and Rails Developer", jobPosition.Title);

            await Cleanup();
        }

        [Fact]
        public async Task UpdateJobPosition_UpdateTopLevelField_GoodReturnValue()
        {
            await Initialize();

            var jobPositions = await _mongoDbRepo.GetJobPositionsByField("Title", "C# Developer");
            var jobPosition = jobPositions.FirstOrDefault();

            if (jobPosition == null)
            {
                Assert.True(false);
            }

            var result = await _mongoDbRepo.UpdateJobPosition(jobPosition.Id, "CompanyName", "Microsoft");

            Assert.True(result);

            await Cleanup();
        }

        [Fact]
        public async Task UpdateJobPosition_TryingToUpdateNonExistingJobPosition_GoodReturnValue()
        {
            await Initialize();

            var result = await _mongoDbRepo.UpdateJobPosition(ObjectId.Empty, "Title", "C# Developer");

            Assert.False(result);

            await Cleanup();
        }

        [Fact]
        public async Task UpdateJobPosition_ExtendingWithNewField_GoodReturnValue()
        {
            await Initialize();

            var jobPositions = await _mongoDbRepo.GetJobPositionsByField("Title", "C# Developer");
            var jobPosition = jobPositions.FirstOrDefault();

            if (jobPosition == null)
            {
                Assert.True(false);
            }

            var result = await _mongoDbRepo.UpdateJobPosition(jobPosition.Id, "Address", "Miami Address");

            Assert.True(result);

            await Cleanup();
        }
    };
}
