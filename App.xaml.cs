using Syncfusion.Maui.Scheduler;
using System.Globalization;
using System.Resources;
using AutonomIA.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AutonomIA
{
    public partial class App : Application
    {
        public static IServiceProvider Services { get; set; }

        public App(IServiceProvider serviceProvider)
        {
            InitializeComponent();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-ES");
            CultureInfo.CurrentUICulture = new CultureInfo("es-ES");
            SfSchedulerResources.ResourceManager = new ResourceManager("AutonomIA.Resources.SfScheduler", Application.Current.GetType().Assembly);
            Services = serviceProvider;

            MainPage = new NavigationPage(new MainLayout());
        }
    }
}