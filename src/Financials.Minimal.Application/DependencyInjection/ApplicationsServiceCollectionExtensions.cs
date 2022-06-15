using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using TraderShop.Financials.TdAmeritrade.Abstractions.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Accounts.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Instruments.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Movers.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Orders.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.PriceHistory.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.WatchList.DependencyInjection;

namespace TraderShop.Financials.Application.DependencyInjection
{
    public static class ApplicationsServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection services,
            Assembly[]? assemblies = null)
        {
            var list = new List<Assembly>
            {
                typeof(ApplicationsServiceCollectionExtensions).GetTypeInfo().Assembly,
            };

            if (assemblies != null)
            {
                list.AddRange(assemblies.ToList());
            }

            services.AddMediatR(list.ToArray());

            services.AddTdAmeritradeClient();

            services.AddTdAmeritradeAccountProvider();

            services.AddTdAmeritradePriceHistoryProvider();

            services.AddTdAmeritradeWatchlistProvider();

            services.AddTdAmeritradeInstrumentProvider();

            services.AddTdAmeritradeMoverProvider();

            services.AddTdAmeritradeOrdersProvider();

            return services;
        }
    }
}