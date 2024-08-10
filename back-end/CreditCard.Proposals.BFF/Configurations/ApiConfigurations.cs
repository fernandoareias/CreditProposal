using System.Reflection;
using CreditCard.Proposals.BFF.Application.Common.Behaviors;
using CreditCard.Proposals.BFF.Configurations.Serilog.microservices.proposals.src.Atividade02.Proposals.API.Configurations.Serilog;
using CreditCard.Proposals.BFF.CrossCutting.Mediator;
using CreditCard.Proposals.BFF.CrossCutting.Validators;
using FluentValidation.AspNetCore;
using MediatR;

namespace CreditCard.Proposals.BFF.Configurations;

public static class ApiConfigurations
{
    public static void ApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        ApiInjection(services, configuration);
    }

    public static void UseApiConfiguration(this WebApplication app, IConfiguration configuration)
    {
        app.UseLogs(configuration);
         

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

    }

    private static void ApiInjection(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IValidatorServices, ValidatorServices>();
        services.AddScoped<IMediatorHandler, MediatorHandler>();
        services.AddFluentValidation(f => f.RegisterValidatorsFromAssembly(Assembly.GetAssembly(typeof(ApiConfigurations))));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(ApiConfigurations))));
    }
}