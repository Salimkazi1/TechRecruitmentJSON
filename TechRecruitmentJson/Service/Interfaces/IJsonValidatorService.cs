using TechRecruitmentJson.Models;

namespace TechRecruitmentJson.Service.Interfaces
{
    public interface IJsonValidatorService
    {
        ValidateResponse Validate(string? jsonTovalidate, string? dataModelShema);
    }
}
