﻿using FluentValidation;
using FluentValidation.Results;
using System.Runtime.Serialization;
using TraderShop.Financials.TdAmeritrade.Accounts.Models;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Account
{
    [DataContract]
    public record class GetAccount : Query<SecuritiesAccount>
    {
        [DataMember]
        public string AccountId { get; private set; }
        [DataMember]
        public string? Fields { get; private set; }
        public GetAccount(string accountId, string? fields)
        {
            AccountId = accountId;
            Fields = fields;
        }

        public override ValidationResult Validate()
        {
            return new GetAcccountQueryValidator().Validate(this);
        }
    }

    public class GetAcccountQueryValidator : AbstractValidator<GetAccount>
    {
        private string[] validFields { get; } = new string[] { "positions", "orders", "positions,orders", "orders,positions" };

        public GetAcccountQueryValidator()
        {
            RuleFor(c => c.AccountId)
            .NotEmpty().WithMessage("AccountId cannot be empty.")
            .MinimumLength(9)
            .Must(x => int.TryParse(x, out var result));


            When(x => x.Fields != null, () =>
            {
                RuleFor(c => c.Fields)
                    .Must(x => validFields.Any(y => y.Equals(x)))
                    .WithMessage("Additional fields can only be positions and/or orders");
            });
        }
    }




}
