using Microsoft.OpenApi.Models;

public static class ApplicationServiceCollectionExtension {
    public static IServiceCollection AddServiceCollection(
        this IServiceCollection services,
        ConfigurationManager configuration) {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt => {
            opt.SwaggerDoc("v1", new OpenApiInfo {
                Title = "Api списка контактов",
            });
        });
        services.AddControllers();
        var connectionString = configuration.GetConnectionString("SqliteStringConnection");
        services.AddSingleton<IStorage>(new SqliteStorage(connectionString));

        services.AddCors(
        opt => opt.AddPolicy("CorsPolicy", policy => {
            policy.AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins(configuration["client"]);
        }));
        return services;
    }
}