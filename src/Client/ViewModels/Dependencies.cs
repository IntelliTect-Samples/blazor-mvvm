namespace IntelliTect.Example.BlazorMvvm.Client.ViewModels;

public static class Dependencies
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddTransient<FetchDataViewModel>();

        return services;
    }
}