using Microsoft.Extensions.Logging;
using Syncfusion.Licensing;
using Syncfusion.Maui.Core.Hosting;
using Syncfusion.Maui.Toolkit.Hosting;

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
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
