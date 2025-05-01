// MauiProgram.cs
using Microsoft.Extensions.Logging;
using Blitzkarten.ViewModels;
using Blitzkarten.Services;

namespace Blitzkarten
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            // Register services
            builder.Services.AddSingleton<BlitzKarteService>();

            // Register ViewModels
            builder.Services.AddSingleton<MainViewModel>();

            // Register Views
            builder.Services.AddSingleton<MainPage>();


            return builder.Build();
        }
    }
}
