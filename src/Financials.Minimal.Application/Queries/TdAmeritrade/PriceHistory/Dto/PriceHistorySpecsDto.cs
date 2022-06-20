using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;

namespace Financials.Minimal.WebApi.Models;

[DataContract]
public record class PriceHistorySpecsDto
{
    public string PeriodType { get; set; }
    public string Period { get; set; }
    public string FrequencyType { get; set; }
    public string Frequency { get; set; }
    public string EndDate { get; set; }
    public string StartDate { get; set; }
    public string NeedExtendedHoursData { get; set; }

    public PriceHistorySpecsDto(string? periodType, string? period, string? frequencyType, string? frequency, string? endDate, string? startDate, string? needExtendedHoursData)
    {
        PeriodType = periodType ?? "year";
        Period = period ?? "1";
        FrequencyType = frequencyType ?? "daily";
        Frequency = frequency ?? "1";
        EndDate = endDate ?? DateTimeOffset.Now.AddDays(-1).ToString();
        StartDate = startDate ?? DateTimeOffset.Now.AddYears(-1).ToString();
        NeedExtendedHoursData = needExtendedHoursData ?? "false";
    }
}

public static class PriceHistoryDtoExtensions
{
    public static PriceHistorySpecs Map(this PriceHistorySpecsDto dto)
    {
        return new PriceHistorySpecs()
        {
            PeriodType = PeriodType.FromName(dto.PeriodType),
            Period = int.Parse(dto.Period),
            FrequecyType = FrequencyType.FromName(dto.FrequencyType),
            Frequency = int.Parse(dto.Frequency),
            StartDate = DateTimeOffset.Parse(dto.StartDate),
            EndDate = DateTimeOffset.Parse(dto.EndDate),
            NeedExtendedHoursData = bool.Parse(dto.NeedExtendedHoursData)
        };
    }


}
