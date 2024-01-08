namespace RocketCV.Services.DTO
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class JobPositionDTO
    {
        public JobPositionDTO() { }

        public JobPositionDTO(string title, string companyName, string description, DateTime startDate,
            DateTime endDate, string city, string country, bool isCurrent, bool isRemote, bool isFreelance,
            bool isPartTime, bool isInternship, bool isVolunteer, DateTime createdDate, DateTime lastModifiedDate)
        {
            Title = title;
            CompanyName = companyName;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            City = city;
            Country = country;
            IsCurrent = isCurrent;
            IsRemote = isRemote;
            IsFreelance = isFreelance;
            IsPartTime = isPartTime;
            IsInternship = isInternship;
            IsVolunteer = isVolunteer;
            CreatedDate = createdDate;
            LastModifiedDate = lastModifiedDate;
        }

        public string? Id { get; set; }

        public string Title { get; set; }

        public string CompanyName { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }

        public bool IsCurrent { get; set; }

        public bool IsRemote { get; set; }

        public bool IsFreelance { get; set; }

        public bool IsPartTime { get; set; }

        public bool IsInternship { get; set; }

        public bool IsVolunteer { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public override string ToString()
        {
            return $"Title: {Title}, CompanyName: {CompanyName}, Description: {Description}, StartDate: {StartDate}, EndDate: {EndDate}, City: {City}, Country: {Country}, IsCurrent: {IsCurrent}, IsRemote: {IsRemote}, IsFreelance: {IsFreelance}, IsPartTime: {IsPartTime}, IsInternship: {IsInternship}, IsVolunteer: {IsVolunteer}, CreatedDate: {CreatedDate}, LastModifiedDate: {LastModifiedDate}";
        }
    }
}
