using Newtonsoft.Json.Schema;

namespace TechRecruitmentJson.Models
{
    public class ValidateResponse
    {
        public bool Valid { get; set; }
        public IList<ValidationError> Errors { get; set; }
    }
}
