public static class ApplicationServiceProviderExtension {
    public static IServiceProvider AddCustomService(
        this IServiceProvider services,
        IConfiguration configuration
    ) {
        using var scope = services.CreateScope();

        var initializer = scope.ServiceProvider.GetRequiredService<IInitializer>();
        initializer.Initialize();

        return services;
    }
}