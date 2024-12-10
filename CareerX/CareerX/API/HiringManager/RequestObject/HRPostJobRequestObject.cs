namespace CareerX.API.HiringManager.RequestObject
{
    public class HRPostJobRequestObject
    {
        public string JobTitle { get; set; } = null!;

        public string JobSummary { get; set; } = null!;

        public Guid LocationId { get; set; }

        public Guid CompanyId { get; set; }

        public Guid CategoryId { get; set; }

        public Guid IndustryId { get; set; }

        public Guid PostedBy { get; set; }

        public DateTime PostedDate { get; set; }

        public Guid QualificationId { get; set; }

        public Guid SkillId { get; set; }
    }
}
