using System.Reflection;
using CreditCard.Proposals.BFF.Application.Common.Behaviors;
using CreditCard.Proposals.BFF.BackgroundServices;
using CreditCard.Proposals.BFF.Configurations.Serilog.microservices.proposals.src.Atividade02.Proposals.API.Configurations.Serilog;
using CreditCard.Proposals.BFF.CrossCutting.Mediator;
using CreditCard.Proposals.BFF.CrossCutting.Validators;
using CreditCard.Proposals.BFF.Infrastructure.Repositories;
using CreditCard.Proposals.BFF.Meters;
using FluentValidation.AspNetCore;
using MediatR;
using Prometheus;

namespace CreditCard.Proposals.BFF.Configurations;

public static class ApiConfigurations
{
    public static void ApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        var section =  configuration.GetConnectionString("Redis");
        ;
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = section;
            options.InstanceName = "SampleInstance";
        });

        ApiInjection(services, configuration);

        services.AddHostedService<ProposalStartedWorker>();
    }

    public static void UseApiConfiguration(this WebApplication app, IConfiguration configuration)
    {
        app.UseLogs(configuration);
         

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseMetricServer();
        app.UseHttpMetrics();

        app.UseHttpsRedirection();

    }

    private static void ApiInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<APIMetrics>();
        services.AddScoped<IValidatorServices, ValidatorServices>();
        services.AddScoped<IMediatorHandler, MediatorHandler>();
        services.AddScoped<ISketchProposalRepository, SketchProposalRepository>();
        services.AddFluentValidation(f => f.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(ApiConfigurations))));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(IdempotentBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(ApiConfigurations))));
    }
}