using Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist;
using Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Financials.Minimal.WebApi.Extensions
{
    public static class TdAmeritradeApiExtensions
    {
        public static void AddTdAmeritradeEndPoints(this WebApplication app, JsonSerializerOptions options)
        {
            app.MapGet("/Tdameritrade/Watchlist/{watchlistId}", async (
                string watchlistId,
                [FromQuery] string accountId,
                IMediator _mediator,
                CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(new GetWatchlist(accountId, watchlistId), cancellationToken);

                if (result.Result != null)
                {
                    return Results.Json(result.Result, options);
                }
                return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
            });

            app.MapGet("/Tdameritrade/Watchlist/MultipleAccounts", async (
                IMediator _mediator,
                CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(new GetWatchlistsForMultipleAccounts(), cancellationToken);

                if (result.Result != null)
                {
                    return Results.Json(result.Result, options);
                }
                return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
            });

            app.MapGet("/Tdameritrade/Watchlist/SingleAccount/{accountId}", async (
                string accountId,
                IMediator _mediator,
                CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(new GetWatchlistsForSingleAccounts(accountId), cancellationToken);

                if (result.Result != null)
                {
                    return Results.Json(result.Result, options);
                }
                return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
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
                return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
            });

            app.MapDelete("/TdAmeritrade/Watchlist/Delete/{watchlistId}", async (
               string watchlistId,
               [FromQuery] string accountId,
               IMediator _mediator,
               CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(new DeleteWatchlist(accountId, watchlistId), cancellationToken);

                if (result.Result.Completed)
                {
                    return Results.Ok(result.Result.Message);
                }
                return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
            });

            app.MapPost("/TdAmeritrade/Watchlist/Replace", async (
               ReplaceWatchlist replaceWatchlistCommand,
               IMediator _mediator,
               CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(replaceWatchlistCommand, cancellationToken);

                if (result.Result.Completed)
                {
                    return Results.Ok(result.Result.Message);
                }
                return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
            });

            app.MapPut("/TdAmeritrade/Watchlist/Update", async (
                UpdateWatchlist updateWatchlistCommand,
                IMediator _mediator,
                CancellationToken cancellationToken) =>
            {
                var result = await _mediator.Send(updateWatchlistCommand, cancellationToken);

                if (result.Result.Completed)
                {
                    return Results.Ok(result.Result.Message);
                }
                return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
            });
        }
    }
}
