using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RocketCV.Models
{
    /// <summary>
    /// Class used in business logic to represent Job Positions.
    /// </summary>
    public class JobPosition
    {
        [BsonId]
        public ObjectId Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("companyName")]
        public string CompanyName { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }

        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }

        [BsonElement("city")]
        public string City { get; set; }

        [BsonElement("country")]
        public string Country { get; set; }

        [BsonElement("isCurrent")]
        public bool IsCurrent { get; set; }

        [BsonElement("isRemote")]
        public bool IsRemote { get; set; }

        [BsonElement("isFreelance")]
        public bool IsFreelance { get; set; }

        [BsonElement("isPartTime")]
        public bool IsPartTime { get; set; }

        [BsonElement("isInternship")]
        public bool IsInternship { get; set; }

        [BsonElement("isVolunteer")]
        public bool IsVolunteer { get; set; }
    }
}
