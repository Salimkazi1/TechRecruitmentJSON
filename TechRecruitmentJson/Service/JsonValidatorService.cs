using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Reflection;
using System.Text;
using TechRecruitmentJson.Models;
using TechRecruitmentJson.Service.Interfaces;

namespace TechRecruitmentJson.Service
{
    public class JsonValidatorService : IJsonValidatorService
    {
        private const string resourcesNamespace = "JsonValidator.Resources";


        public ValidateResponse Validate(string? jsonTovalidate, string? dataModelShema)
        {
            // if the caller did not provid a schema, try to get default one 
            if (dataModelShema == null)
            {
                dataModelShema = this.LoadDataModelSchema();
            }

            // Check if dataModelSchema was loaded successfully
            if (dataModelShema != null && jsonTovalidate != null)
            {
                JSchema schema = JSchema.Parse(dataModelShema);

                JObject user = JObject.Parse(jsonTovalidate);

                IList<ValidationError> errors;
                bool valid = user.IsValid(schema, out errors);

                return new ValidateResponse
                {
                    Valid = valid,
                    Errors = errors
                };
            }
            else
            {
                throw new FileNotFoundException("The DataModelSchema file was not found");
            }
        }

        private string? LoadDataModelSchema()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            StringBuilder? stringBuilder = null;

            string manifestBodyFullName = $"{resourcesNamespace}.DataModelSchemaJson.json";

            Stream? bodyTemplateStream = assembly.GetManifestResourceStream(manifestBodyFullName);

            if (bodyTemplateStream is not null)
            {
                stringBuilder = new StringBuilder();

                using StreamReader bodyTemplateReader = new StreamReader(bodyTemplateStream);
                string bodyTemplate = bodyTemplateReader.ReadToEnd();
                stringBuilder.Append(bodyTemplate);
            }

            return stringBuilder?.ToString();
        }
    }
}
