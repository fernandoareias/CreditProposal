using CreditCard.Proposals.BFF.Commands;
using CreditCard.Proposals.BFF.Commands.Views;
using CreditCard.Proposals.BFF.Configurations;
using CreditCard.Proposals.BFF.Configurations.Serilog.microservices.proposals.src.Atividade02.Proposals.API.Configurations.Serilog;
using CreditCard.Proposals.BFF.CrossCutting.Mediator;
using CreditCard.Proposals.BFF.DTOs.Requests;
using CreditCard.Proposals.BFF.DTOs.Responses;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
builder.Host.AddLogs(builder.Configuration, "bff-creditcard");
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.ApiConfiguration(builder.Configuration);

var app = builder.Build();
app.UseApiConfiguration(builder.Configuration);

app.MapPost("/proposals/init", async (
        [FromHeader(Name = "x-idempotent-id")] Guid idempotentId, 
        [FromHeader(Name = "x-correlation-id")] Guid correlationId,
        [FromBody] ProposalsInitRequest request,
        IMediatorHandler mediatorHandler) =>
    {
        var response =
            await mediatorHandler.Send(new InitProposalCommand(request.Document, idempotentId, correlationId));
        
        return Results.Ok(response);
    })
    .WithName("Init proposal")
    .WithOpenApi();

app.Run();
