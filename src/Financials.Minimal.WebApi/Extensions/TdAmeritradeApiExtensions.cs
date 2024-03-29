﻿using Financials.Minimal.Application.Commands.TdAmeritrade.Watchlist;
using Financials.Minimal.Application.Queries.TdAmeritrade.Account;
using Financials.Minimal.Application.Queries.TdAmeritrade.Instrument;
using Financials.Minimal.Application.Queries.TdAmeritrade.PriceHistory;
using Financials.Minimal.Application.Queries.TdAmeritrade.Watchlist;
using Financials.Minimal.WebApi.Models;
using Financials.Minimal.WebApi.Models.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Financials.Minimal.WebApi.Extensions;

public static class TdAmeritradeApiExtensions
{

    public static void AddTdAmeritradeEndPoints(this WebApplication app, JsonSerializerOptions options)
    {

        app.MapGet("api/Tdameritrade/PriceHistory/{symbol}", async (
            string symbol,
            [FromQuery] string? periodType,
            [FromQuery] string? period,
            [FromQuery] string? frequencyType,
            [FromQuery] string? frequency,
            [FromQuery] string? endDate,
            [FromQuery] string? startDate,
            [FromQuery] string? needExtendedHoursData,
            IMediator _mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new GetPriceHistory(symbol.Clean().ToUpper(),
                                                    new PriceHistorySpecsDto(
                                                        periodType?.Clean(),
                                                        period,
                                                        frequencyType?.Clean(),
                                                        frequency,
                                                        endDate?.Clean(),
                                                        startDate?.Clean(),
                                                        needExtendedHoursData)),
                                                    cancellationToken);

            if (result.Result != null)
            {
                return Results.Json(result.Result, options);
            }
            return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
        });

        app.MapGet("api/Tdameritrade/Instrument/Futures", async (
            IMediator _mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new GetAllFuturesInstruments(), cancellationToken);

            if (result.Result != null)
            {
                return Results.Json(result.Result, options);
            }
            return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
        });

        app.MapGet("api/Tdameritrade/Instrument/{symbol}", async (
            string symbol,
            IMediator _mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new GetInstrument(symbol.Clean()), cancellationToken);

            if (result.Result != null)
            {
                return Results.Json(result.Result, options);
            }
            return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
        });

        app.MapGet("api/Tdameritrade/Instruments/{symbols}", async (
            string symbols,
            [FromQuery] string projection,
            IMediator _mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new GetInstrumentsWithParameters(symbols.Clean(), projection.Clean()), cancellationToken);

            if (result.Result != null)
            {
                return Results.Json(result.Result, options);
            }
            return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
        });
        app.MapGet("api/Tdameritrade/Accounts", async (
            string? fields,
            IMediator _mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new GetAllAccounts(fields?.Clean()), cancellationToken);

            if (result.Result != null)
            {
                return Results.Json(result.Result, options);
            }
            return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
        });

        app.MapGet("api/Tdameritrade/Account/{accountId}", async (
            string accountId,
            string? fields,
            IMediator _mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new GetAccount(accountId, fields?.Clean()), cancellationToken);

            if (result.Result != null)
            {
                return Results.Json(result.Result, options);
            }
            return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
        });

        app.MapGet("api/Tdameritrade/Watchlist/{watchlistId}", async (
            string watchlistId,
            [FromQuery] string accountId,
            IMediator _mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new GetWatchlist(accountId.Clean(), watchlistId.Clean()), cancellationToken);

            if (result.Result != null)
            {
                return Results.Json(result.Result, options);
            }
            return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
        });

        app.MapGet("api/Tdameritrade/Watchlist/MultipleAccounts", async (
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

        app.MapGet("api/Tdameritrade/Watchlist/SingleAccount/{accountId}", async (
            string accountId,
            IMediator _mediator,
            CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new GetWatchlistsForSingleAccounts(accountId.Clean()), cancellationToken);

            if (result.Result != null)
            {
                return Results.Json(result.Result, options);
            }
            return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
        });

        app.MapPost("api/Tdameritrade/Watchlist/Create", async (
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

        app.MapPost("api/Tdameritrade/Watchlist/Replace", async (
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

        app.MapPut("api/Tdameritrade/Watchlist/Update", async (
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

        app.MapDelete("api/Tdameritrade/Watchlist/Delete/{watchlistId}", async (
           string watchlistId,
           [FromQuery] string accountId,
           IMediator _mediator,
           CancellationToken cancellationToken) =>
        {
            var result = await _mediator.Send(new DeleteWatchlist(accountId, watchlistId.Clean()), cancellationToken);

            if (result.Result.Completed)
            {
                return Results.Ok(result.Result.Message);
            }
            return Results.BadRequest(result.ValidationResult.Errors.Select(x => x.ErrorMessage));
        });
    }
}

