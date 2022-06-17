using Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist;
using Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Financials.Minimal.WebApi.Extensions
{
    public static class TdAmeritradeApiExtensions
    {
        public static Task AddTdAmeritradeEndPointsAsync(this WebApplication app, JsonSerializerOptions options)
        {
            app.MapGet("/Tdameritrade/Watchlist/{watchlistId}", async (
                string watchlistId,
                [FromQuery] string accountId,
                IMediator _mediator,
                CancellationToken cancellationToken) =>
            {

                var (watchlist, message) = await _mediator.Send(new GetWatchlist(accountId, watchlistId), cancellationToken);

                if (message == null)
                {
                    return Results.Json(watchlist, options);
                }

                return Results.BadRequest(message);
            });


            app.MapGet("/Tdameritrade/Watchlist/MultipleAccounts", async (
                IMediator _mediator,
                CancellationToken cancellationToken) =>
            {
                var (watchlist, message) = await _mediator.Send(new GetWatchlistsForMultipleAccounts(), cancellationToken);

                if (message == null)
                {
                    return Results.Json(watchlist, options);
                }

                return Results.BadRequest(message);
            });

            app.MapGet("/Tdameritrade/Watchlist/SingleAccount/{accountId}", async (
                string accountId,
                IMediator _mediator,
                CancellationToken cancellationToken) =>
            {
                var (watchlist, message) = await _mediator.Send(new GetWatchlistsForSingleAccounts(accountId), cancellationToken);

                if (message == null)
                {
                    return Results.Json(watchlist, options);
                }

                return Results.BadRequest(message);
            });

            app.MapPost("/TdAmeritrade/Watchlist/Create", async (
               CreateWatchlist createWatchlistCommand,
               IMediator _mediator,
               CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(createWatchlistCommand, cancellationToken);

                if (result.Result.Completed)
                {
                    return Results.Ok(result.Result.Message);
                }
                return Results.BadRequest(result.Result.Message);
            });

            app.MapDelete("/TdAmeritrade/Watchlist/Delete/{watchlistId}", async (
               string watchlistId,
               [FromQuery] string accountId,
               IMediator _mediator,
               CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(new DeleteWatchlist(accountId, watchlistId), cancellationToken);

                if (result.Item2)
                {
                    return Results.Ok(result.Item1);
                }
                return Results.BadRequest(result.Item1);
            });


            app.MapPost("/TdAmeritrade/Watchlist/Replace", async (
               ReplaceWatchlist replaceWatchlistCommand,
               IMediator _mediator,
               CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(replaceWatchlistCommand, cancellationToken);

                if (result.Item2)
                {
                    return Results.Ok(result.Item1);
                }
                return Results.BadRequest(result.Item1);
            });

            app.MapPut("/TdAmeritrade/Watchlist/Update", async (
                UpdateWatchlist updateWatchlistCommand,
                IMediator _mediator,
                CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(updateWatchlistCommand, cancellationToken);

                if (result.Item2)
                {
                    return Results.Ok(result.Item1);
                }
                return Results.BadRequest(result.Item1);
            });
            return Task.CompletedTask;
        }
    }
}
