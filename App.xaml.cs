using Syncfusion.Maui.Scheduler;
using System.Globalization;
using System.Resources;
using AutonomIA.Views;

namespace AutonomIA
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("es-ES");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("es-ES");
            CultureInfo.CurrentUICulture = new CultureInfo("es-ES");
            SfSchedulerResources.ResourceManager = new ResourceManager("AutonomIA.Resources.SfScheduler", Application.Current.GetType().Assembly);

            MainPage = new NavigationPage(new MainLayout());
        }
    }
}