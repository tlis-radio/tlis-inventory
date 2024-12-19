using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Tlis.Inventory.Application.Features.Storage;
using Tlis.Inventory.Application.PipelineBehaviors;

namespace Tlis.Inventory.Application;

public static class ApplicationModule
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(ApplicationModule).Assembly);
        });
        services.AddValidatorsFromAssembly(typeof(ApplicationModule).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<StorageUnitOfWork>();
    }
}