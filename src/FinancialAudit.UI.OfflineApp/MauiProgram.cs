using FinancialAudit.Application;
using FinancialAudit.Infrastructure;
using FinancialAudit.Shared.DI;
using Microsoft.Extensions.Logging;

namespace FinancialAudit.UI.OfflineApp;
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
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
        builder.Services.AddBlazorWebViewDeveloperTools();
        builder.Logging.AddDebug();
#endif

        builder.Services
            .AddApplication()
            .AddInfrastructure()
            .AddAttributedServices(typeof(MauiProgram).Assembly);

        var app = builder.Build();
        return app;
    }
}
