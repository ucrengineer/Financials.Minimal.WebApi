using Financials.Minimal.WebApi.Extensions;
using Microsoft.Extensions.Options;
using System.Text.Json;
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
    options.SerializerOptions.IgnoreReadOnlyFields = false;
});

var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);

builder.Logging.AddConsole();

var app = builder.Build();

var accountId = app.Services.GetRequiredService<IOptionsMonitor<TdAmeritradeOptions>>().CurrentValue.account_number;

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddTdAmeritradeEndPointsAsync(options);

app.UseHttpsRedirection();


app.Run();