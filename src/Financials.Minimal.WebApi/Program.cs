using Financials.Minimal.WebApi.Extensions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;
using TraderShop.Financials.Application.DependencyInjection;
using TraderShop.Financials.TdAmeritrade.Abstractions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<TdAmeritradeOptions>(builder.Configuration.GetSection("TdAmeritradeOptions"));

builder.Services.AddApplication();
// configure json options
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.IncludeFields = true;
    options.SerializerOptions.IgnoreReadOnlyFields = true;
    options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

builder.Logging.AddConsole();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddTdAmeritradeEndPoints(options);

app.UseHttpsRedirection();

// global exception handler
app.UseExceptionHandler(appError =>
{
    appError.Run(async context =>
    {
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        context.Response.ContentType = "application/json";

        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

        if (contextFeature != null)
            await context.Response.WriteAsync(contextFeature.Error.Message);
    });
});

app.Run();