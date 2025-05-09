using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AutonomIA.Models;
using AutonomIA.Services;
using AutonomIA.Views;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Dispatching;

namespace AutonomIA.ViewModels
{
    public class NotaListViewModel : INotifyPropertyChanged
    {
        private readonly NotaService _notaService;

        public ObservableCollection<Nota> Notas { get; } = new();

        private Nota _notaSeleccionada;
        public Nota NotaSeleccionada
        {
            get => _notaSeleccionada;
            set
            {
                if (_notaSeleccionada != value)
                {
                    _notaSeleccionada = value;
                    OnPropertyChanged();
                    if (_notaSeleccionada != null)
                        NotaSeleccionadaCommand.Execute(_notaSeleccionada);
                }
            }
        }

        public ICommand NuevaNotaCommand { get; }
        public ICommand NotaSeleccionadaCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NotaListViewModel(NotaService notaService)
        {
            _notaService = notaService;
            NuevaNotaCommand = new Command(OnNuevaNota);
            NotaSeleccionadaCommand = new Command<Nota>(OnNotaSeleccionada);
            CargarNotas();
        }

        private async void CargarNotas()
        {
            var notas = await _notaService.ObtenerNotasAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Notas.Clear();
                foreach (var nota in notas)
                    Notas.Add(nota);
            });
        }

        private async void OnNuevaNota()
        {
            var page = App.Services.GetService<NotaDetalleView>();
            if (page?.BindingContext is NotaDetalleViewModel vm)
            {
                vm.NotaActual = new Nota();
            }

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        private async void OnNotaSeleccionada(Nota nota)
        {
            var page = App.Services.GetService<NotaDetalleView>();
            if (page?.BindingContext is NotaDetalleViewModel vm)
            {
                vm.NotaActual = nota;
            }

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
