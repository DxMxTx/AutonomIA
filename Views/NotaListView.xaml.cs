using AutonomIA.ViewModels;
using Microsoft.Maui.Controls;

namespace AutonomIA.Views
{
    public partial class NotaListView : ContentPage
    {
        public NotaListView(NotaListViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
