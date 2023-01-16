namespace IntelliTect.Example.BlazorMvvm.Client.ViewModels;

public static class Dependencies
{
    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddTransient<FetchDataViewModel>();
        services.AddTransient<HexEntryViewModel>();
        services.AddTransient<TextEntryViewModel>();
        services.AddTransient<EditContactViewModel>();
        return services;
    }
}