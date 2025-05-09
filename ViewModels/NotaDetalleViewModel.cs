using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using AutonomIA.Models;
using AutonomIA.Services;
using Microsoft.Maui.Controls;

namespace AutonomIA.ViewModels
{
    public class NotaDetalleViewModel : INotifyPropertyChanged
    {
        private readonly NotaService _notaService;
        private Nota _notaActual;

        public Nota NotaActual
        {
            get => _notaActual;
            set
            {
                if (_notaActual != value)
                {
                    _notaActual = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand GuardarCommand { get; }
        public ICommand EliminarCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NotaDetalleViewModel(NotaService notaService)
        {
            _notaService = notaService;
            GuardarCommand = new Command(OnGuardar);
            EliminarCommand = new Command(OnEliminar);
        }

        private async void OnGuardar()
        {
            if (NotaActual != null)
            {
                await _notaService.GuardarNotaAsync(NotaActual);
                await Application.Current.MainPage.Navigation.PopAsync();
            }
        }

        private async void OnEliminar()
        {
            if (NotaActual != null && NotaActual.Id != 0)
            {
                bool confirm = await Application.Current.MainPage.DisplayAlert("Confirmar", "¿Eliminar esta nota?", "Sí", "No");
                if (confirm)
                {
                    await _notaService.EliminarNotaAsync(NotaActual);
                    await Application.Current.MainPage.Navigation.PopAsync();
                }
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
