using ExpenseApplication.Server.Application.CQRS.Behaviors;
using Microsoft.IdentityModel.Tokens;

namespace ExpenseApplication.Server.Application;

/// <summary>
/// Provides extension methods for configuring dependency injection of application services.
/// </summary>
public static class DependencyInjection
{
    /// <summary>
    /// Adds application services to the specified <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="services">The service collection to which the services are added.</param>
    /// <param name="configuration">The application configuration.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddFeatureManagement();
        services.AddCustomOptions(configuration);
        services.AddCustomExceptionHandler();
        services.AddCustomValidators();
        services.AddCustomMapster();
        services.AddCustomMediatR();
        services.AddCustomServices();
        services.AddCustomCors();
        services.AddCustomJwtBearer(configuration);
        return services;
    }

    /// <summary>
    /// Adds custom options to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the options are added.</param>
    /// <param name="configuration">The application configuration.</param>
    public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(configuration);

        services.AddOptions<BearerTokensOptions>()
            .Bind(configuration.GetSection(key: "BearerTokens"))
            .Validate(
                bearerTokens => bearerTokens.AccessTokenExpirationMinutes < bearerTokens.RefreshTokenExpirationMinutes,
                "RefreshTokenExpirationMinutes is less than AccessTokenExpirationMinutes. Obtaining new tokens using the refresh token should happen only if the access token has expired.");
    }

    /// <summary>
    /// Adds a custom exception handler to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the exception handler is added.</param>
    public static void AddCustomExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<CustomExceptionHandler>();
    }

    /// <summary>
    /// Adds custom validators to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the validators are added.</param>
    public static void AddCustomValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }

    /// <summary>
    /// Adds Mapster configuration to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which Mapster is added.</param>
    public static void AddCustomMapster(this IServiceCollection services)
    {
        services.AddMapster();
        MapsterConfig.Configure();
    }

    /// <summary>
    /// Adds MediatR configuration to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which MediatR is added.</param>
    public static void AddCustomMediatR(this IServiceCollection services)
    {
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            config.AddOpenBehavior(typeof(ValidationBehavior<,>));
            config.AddOpenBehavior(typeof(LoggingBehavior<,>));
        });
    }

    /// <summary>
    /// Adds custom services to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which the custom services are added.</param>
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddScoped<IUsersService, UsersService>();
        services.AddScoped<IRolesService, RolesService>();
        services.AddSingleton<ISecurityService, SecurityService>();
        services.AddScoped<ITokenStoreService, TokenStoreService>();
        services.AddScoped<ITokenValidatorService, TokenValidatorService>();
        services.AddScoped<ITokenFactoryService, TokenFactoryService>();
    }

    /// <summary>
    /// Adds CORS configuration to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which CORS is added.</param>
    public static void AddCustomCors(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy(name: "CorsPolicy", builder
                => builder
                    .WithOrigins("https://localhost:7161", "https://localhost:7242") //Note:  The URL must be specified without a trailing slash (/).
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .SetIsOriginAllowed(host => true)
                    .AllowCredentials());
        });
    }

    /// <summary>
    /// Adds JWT Bearer authentication configuration to the service collection.
    /// </summary>
    /// <param name="services">The service collection to which JWT Bearer authentication is added.</param>
    /// <param name="configuration">The application configuration.</param>
    public static void AddCustomJwtBearer(this IServiceCollection services, IConfiguration configuration)
    {
        // Needed for custom roles.
        services.AddAuthorization(authorizationOptions =>
        {
            authorizationOptions.AddPolicy(CustomRoleConstants.Admin, policy => policy.RequireRole(CustomRoleConstants.Admin));
            authorizationOptions.AddPolicy(CustomRoleConstants.Employee, policy => policy.RequireRole(CustomRoleConstants.Employee));
            authorizationOptions.AddPolicy(CustomRoleConstants.Manager, policy => policy.RequireRole(CustomRoleConstants.Manager));
            authorizationOptions.AddPolicy(CustomRoleConstants.Accountant, policy => policy.RequireRole(CustomRoleConstants.Accountant));
        });

        // Needed for jwt auth.
        services.AddAuthentication(authenticationOptions =>
        {
            authenticationOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            authenticationOptions.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            authenticationOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(jwtBearerOptions =>
        {
            jwtBearerOptions.RequireHttpsMetadata = false;
            jwtBearerOptions.SaveToken = true;
            var bearerTokenOption = configuration.GetSection(key: "BearerTokens").Get<BearerTokensOptions>();

            if (bearerTokenOption is null)
            {
                throw new InvalidOperationException(message: "bearerTokenOption is null");
            }

            jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters
            {
                // Site that makes the token
                ValidIssuer = bearerTokenOption.Issuer,
                ValidateIssuer = true,

                // site that consumes the token
                ValidAudience = bearerTokenOption.Audience,
                ValidateAudience = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(bearerTokenOption.Key)),

                // Verify signature to avoid tampering
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true, // validate the expiration

                // Tolerance for the expiration date
                ClockSkew = TimeSpan.Zero
            };

            jwtBearerOptions.Events = new JwtBearerEvents
            {
                OnAuthenticationFailed = context =>
                {
                    var logger = context.HttpContext.RequestServices.GetRequiredService<ILoggerFactory>().CreateLogger(nameof(JwtBearerEvents));
                    logger.LogError(context?.Exception, context?.Exception?.Message);
                    return Task.CompletedTask;
                },
                OnTokenValidated = context =>
                {
                    var tokenValidatorService = context.HttpContext.RequestServices.GetRequiredService<ITokenValidatorService>();
                    return tokenValidatorService.ValidateAsync(context);
                },
                OnMessageReceived = context => Task.CompletedTask,
                OnChallenge = context => throw new UnauthorizedException("UnAuthorized!"),
                OnForbidden = context => throw new AccessDeniedException("Access Denied!")
            };
        });
    }
}