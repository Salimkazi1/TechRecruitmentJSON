using System.ComponentModel.DataAnnotations;

namespace TechRecruitmentJson.Models
{
    public class ValidationRequest
    {
        [Required]
        public object Json { get; set; }
        public object? DataModelShema { get; set; }
    }
}
