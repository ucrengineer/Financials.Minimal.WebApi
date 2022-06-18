using TraderShop.Financials.TdAmeritrade.Accounts.Models;
using TraderShop.Financials.TdAmeritrade.Accounts.Services;

namespace Financials.Minimal.Application.Queries.TdAmeritrade.Account.Handler
{
    public class GetAccountHandler : QueryHandler<GetAccount, SecuritiesAccount>
    {
        private readonly ITdAmeritradeAccountProvider _accountProvider;
        public GetAccountHandler(ITdAmeritradeAccountProvider accountProvider)
        {
            _accountProvider = accountProvider;
        }

        public override async Task<SecuritiesAccount> ExecuteQuery(GetAccount query, CancellationToken cancellationToken)
        {
            return await _accountProvider.GetAccount(query.AccountId, query.Fields, cancellationToken);
        }
    }
}
