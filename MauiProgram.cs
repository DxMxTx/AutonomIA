using Microsoft.Extensions.Logging;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Toolkit.Hosting;
using AutonomIA.Data;
using AutonomIA.Models;
using AutonomIA.Services;
using AutonomIA.ViewModels;
using AutonomIA.Views;

namespace AutonomIA
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            SyncfusionLicenseProvider.RegisterLicense("Mzg0Mjc2N0AzMjM5MmUzMDJlMzAzYjMyMzkzYkJnVVRPT2hDTGNxS0hGRDg0L3NaNC9zZGpzdDN0M1UyZno2TGlXMkVvS0k9");

            var builder = MauiApp.CreateBuilder();

            builder
                .ConfigureSyncfusionCore()
                .ConfigureSyncfusionToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("MauiMaterialAssets.ttf", "MaterialAssets");
                    fonts.AddFont("Montserrat-Bold.ttf", "Titulo");
                    fonts.AddFont("Montserrat-Regular.ttf", "Normal");
                    fonts.AddFont("Montserrat-Light.ttf", "Etiquetas");
                    fonts.AddFont("Segoe UI.ttf", "SegoeUI");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "autonomia.db");
            var repo = new GenericRepository(dbPath);
            repo.CreateTableAsync<Nota>().Wait();

            // Registro de servicios
            builder.Services.AddSingleton(repo);
            builder.Services.AddSingleton<NotaService>();

            // Registro de viewmodels
            builder.Services.AddTransient<NotaListViewModel>();
            builder.Services.AddTransient<NotaDetalleViewModel>();

            // Registro de vistas
            builder.Services.AddTransient<NotaListView>();
            builder.Services.AddTransient<NotaDetalleView>();

            var app = builder.Build();
            App.Services = app.Services;
            return app;
        }
    }
}
