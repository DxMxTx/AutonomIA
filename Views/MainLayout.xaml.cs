using AutonomIA.Views;
using Syncfusion.Maui.NavigationDrawer;
using Syncfusion.Maui.Toolkit.NavigationDrawer;

namespace AutonomIA.Views;

public partial class MainLayout : ContentPage
{
    public MainLayout()
    {
        InitializeComponent();
        BindingContext = this;
        headerLabel.Text = "AutonomIA";
        var page = new HomePage();
        MainContent.Content = new ContentView
        {
            Content = page.Content,
            BindingContext = page.BindingContext
        };
    }

    private void hamburgerButton_Clicked(object sender, EventArgs e)
    {
        NavigationDrawer.ToggleDrawer();
    }

    private void GoToHome(object sender, EventArgs e)
    {
        //headerLabel.Text = "AutonomIA";
        //MainContent.Content = new HomePage();
        //navigationDrawer.ToggleDrawer();
    }

    private void GoToAgenda(object sender, EventArgs e)
    {
        //headerLabel.Text = "Agenda";
        //MainContent.Content = new AgendaPage();
        //navigationDrawer.ToggleDrawer();
    }

    private void GoToNotas(object sender, EventArgs e)
    {
        headerLabel.Text = "Módulo de Notas";

        var page = App.Services.GetService<NotaListView>();
        MainContent.Content = new ContentView
        {
            Content = page.Content,
            BindingContext = page.BindingContext
        };

        NavigationDrawer.ToggleDrawer();
    }

    private void GoToClientes(object sender, EventArgs e)
    {
        //headerLabel.Text = "Clientes";
        //MainContent.Content = new ClientesPage();
        //navigationDrawer.ToggleDrawer();
    }

    private void GoToProveedores(object sender, EventArgs e)
    {
        //headerLabel.Text = "Proveedores";
        //MainContent.Content = new ProveedoresPage();
        //navigationDrawer.ToggleDrawer();
    }

    private void GoToConfiguracion(object sender, EventArgs e)
    {
        //headerLabel.Text = "Configuración";
        //MainContent.Content = new ConfiguracionPage();
        //navigationDrawer.ToggleDrawer();
    }
}
