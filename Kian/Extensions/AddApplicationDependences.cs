using FluentValidation;
using Kian.Behavior;
using Kian.Context;
using Kian.Contract.Repositories;
using Kian.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Kian.Extensions;

public static class AddApplicationDependences
{
    public static IServiceCollection AddDependences(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IUnitOFWork, UnitOfWork>();

        var assembly = Assembly.GetExecutingAssembly();
        services.AddAutoMapper(assembly);
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(assembly));


        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressMapClientErrors = true;
        });
        services.AddValidatorsFromAssembly(assembly);
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddScoped<IEmployeesRepo, EmployeesRepo>();
        return services;
    }
}
