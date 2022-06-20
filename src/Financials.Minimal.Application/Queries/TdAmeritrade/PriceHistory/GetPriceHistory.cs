using Financials.Minimal.WebApi.Models;
using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.PriceHistory.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.PriceHistory;
[DataContract]
public record class GetPriceHistory : Query<Candle[]>
{
    [DataMember]
    public string Symbol { get; private set; }

    [DataMember]
    public PriceHistorySpecsDto Specs { get; private set; }

    public GetPriceHistory(string sybmol, PriceHistorySpecsDto specs)
    {
        Symbol = sybmol;
        Specs = specs;
    }

    public override ValidationResult Validate()
    {
        return new GetPriceHistoryQueryValidator().Validate(this);
    }
}

public class GetPriceHistoryQueryValidator : AbstractValidator<GetPriceHistory>
{
    public GetPriceHistoryQueryValidator()
    {
        RuleFor(x => x.Symbol)
            .NotEmpty()
            .WithMessage("Ticker must be provided.");

        RuleFor(x => x.Specs)
            .Must(x => PeriodType.TryFromName(x.PeriodType, out var result))
            .WithMessage($"Valid periodTypes are : {string.Join(",", PeriodType.List.Select(x => x.Name))} ")
            .Must(x => int.TryParse(x.Period, out var result))
            .WithMessage("Period must be a integer.")
            .Must(x => FrequencyType.TryFromName(x.FrequencyType, out var result))
            .WithMessage($"Valid frequencyTypes are : {string.Join(",", FrequencyType.List.Select(x => x.Name))} ")
            .Must(x => int.TryParse(x.Frequency, out var result))
            .WithMessage("Frequency must be a integer.")
            .Must(x => bool.TryParse(x.NeedExtendedHoursData, out var result))
            .WithMessage("Valid NeedExtendedHoursData values are true or false.")
            .Must(x => DateTimeOffset.TryParse(x.StartDate, out var result))
            .Must(x => DateTimeOffset.TryParse(x.EndDate, out var result));
    }
}