namespace Financials.Minimal.WebApi.Models
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0#custom-binding
    /// </summary>
    public class FieldsArrayDto
    {
        public string[]? QueryFields { get; set; } = null;

        public static bool TryParse(string? value, out FieldsArrayDto? queryFields)
        {
            var segments = value?.ToLower().Split(',',
                    StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            queryFields = new FieldsArrayDto { QueryFields = segments };
            return true;
        }
    }
}
