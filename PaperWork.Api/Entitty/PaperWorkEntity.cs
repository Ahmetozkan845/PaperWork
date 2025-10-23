using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaperWork.Api.Entitty
{
    [Table("HR_Feedback_Process")]
    public class PaperWorkEntity
    {
        [Key]
        [Required]
        public string PWId { get; set; } = default!;

        public string? Year { get; set; }
        public string? Month { get; set; }
        public string? FeedbackType { get; set; }
        public string? ActionDecision { get; set; }
        public string? Directorate { get; set; }
        public string? Department { get; set; }
        public string? EmployeeName { get; set; }
        public string? EmployeeRegistrationNumber { get; set; }
        public string? CBACodes { get; set; }
        public string? FeedbackChannel { get; set; }
        public string? ActionOwnerManager { get; set; }
        public string? ActionOwnerManagerRegistrationNumber { get; set; }
        public string? FeedbackDetail { get; set; }
        public string? ActionOwnerManagerFeedbackDetail { get; set; }
        public string? GettingStartedGeneralDescription { get; set; }
        public string? CreateUser { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
    }
}
