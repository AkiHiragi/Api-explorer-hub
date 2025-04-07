public static class ApplicationServiceProviderExtension {
    public static IServiceProvider AddCustomService(
        this IServiceProvider services,
        IConfiguration configuration
    ) {
        using var scope = services.CreateScope();

        var storage = scope.ServiceProvider.GetService<IStorage>();
        var dbStorage = storage as SqliteStorage;
        if (dbStorage != null) {
            var cs = configuration.GetConnectionString("SqliteStringConnection");
            new FakerInitializer(cs).Initialize();
        }

        return services;
    }
}