namespace ExpenseApplication.Server.WebApi;

/// <summary>
/// Provides extension methods for configuring presentation layer services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds presentation layer services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which the services are added.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddPresentationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers(options =>
            {
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                options.InvalidModelStateResponseFactory = context =>
                {
                    var validationResult = new ValidationResult();
                    foreach (var keyValuePair in context.ModelState)
                    {
                        validationResult.Errors.Add(new ValidationFailure(keyValuePair.Key,
                            string.Join("|", keyValuePair.Value.Errors.Select(li => li.ErrorMessage))));
                    }

                    throw new FluentValidationException(validationResult.Errors);
                };
            });

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo { Title = "Expense Application API", Version = "v1" });

            options.AddSecurityDefinition(name: "Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.ApiKey,
                Description = "Put the **_JWT Bearer_** token on the input below!",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Scheme = "bearer",
                BearerFormat = "JWT"
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    new string[] { }
                }
            });
        });

        return services;
    }
}