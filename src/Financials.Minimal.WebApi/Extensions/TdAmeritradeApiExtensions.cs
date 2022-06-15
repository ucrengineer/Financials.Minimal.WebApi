using Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist;
using MediatR;
using System.Text.Json;

namespace Financials.Minimal.WebApi.Extensions
{
    public static class TdAmeritradeApiExtensions
    {
        public static void AddTdAmeritradeEndPoints(this WebApplication app, string accountId, JsonSerializerOptions options)
        {
            app.MapGet("/Tdameritrade/Watchlist/{watchlistId}", async (
                string watchlistId,
                IMediator _mediator,
                CancellationToken cancellationToken) =>
            {
                var (watchlist, message) = await _mediator.Send(new GetWatchlistQuery(accountId, watchlistId), cancellationToken);

                if (message == null)
                {
                    return Results.Json(watchlist, options);
                }

                return Results.BadRequest(message);
            });
        }
    }
}
