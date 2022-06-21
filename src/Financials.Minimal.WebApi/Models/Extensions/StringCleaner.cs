namespace Financials.Minimal.WebApi.Models.Extensions;
public static class StringCleaner
{
    public static string Clean(this string original)
    {
        return original.Trim()
            .Replace(" ", null)
            .ToLower();
    }
}