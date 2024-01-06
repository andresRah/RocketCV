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
        private readonly JobPositionRepository _mongoDbRepo = new("mongodb://127.0.0.1:32775");

        /// <summary>
        /// Initialize
        /// </summary>
        /// <returns></returns>
        private async Task Initialize()
        {
            var user1 = new JobPosition()
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
            await _mongoDbRepo.InsertJobPosition(user1);

            var user2 = new JobPosition()
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
            await _mongoDbRepo.InsertJobPosition(user2);

            var user3 = new JobPosition()
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
            await _mongoDbRepo.InsertJobPosition(user3);
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
            var mongoDbRepo = new JobPositionRepository("mongodb://127.0.0.1:32775");
            var connected = mongoDbRepo.CheckConnection();
            Assert.False(connected);
        }
    };
}
