using AutonomIA.ViewModels;
using Microsoft.Maui.Controls;
using Syncfusion.Maui.DataForm;

namespace AutonomIA.Views
{
    public partial class NotaDetalleView : ContentPage
    {
        public NotaDetalleView(NotaDetalleViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;

            DataForm.GenerateDataFormItem += OnGenerateDataFormItem;
        }
        private void OnGenerateDataFormItem(object sender, GenerateDataFormItemEventArgs e)
        {
            if (e.DataFormItem == null)
                return;


            // Cambiar nombre de los campos
            if (e.DataFormItem.FieldName == "Id")
            {
                e.DataFormItem.LabelText = "Identificador";
                //e.DataFormItem.IsReadOnly = true;
            }

            if (e.DataFormItem.FieldName == "FechaCreacion")
            {
                e.DataFormItem.LabelText = "Fecha Creación";
                e.DataFormItem.IsReadOnly = true;
            }

            // Fuente para la etiqueta
            e.DataFormItem.LabelTextStyle = new DataFormTextStyle
            {
                FontFamily = "Normal",
                FontSize = 16,
                //FontAttributes = FontAttributes.Bold,
                TextColor = Colors.Black
            };

            // Fuente para el editor (input)
            e.DataFormItem.EditorTextStyle = new DataFormTextStyle
            {
                FontFamily = "Normal",
                FontSize = 16,
                //FontAttributes = FontAttributes.None,
                TextColor = Colors.Black
            };

            // Fuente para mensaje de error
            e.DataFormItem.ErrorLabelTextStyle = new DataFormTextStyle
            {
                FontFamily = "Normal",
                FontSize = 12,
                //FontAttributes = FontAttributes.Italic,
                TextColor = Colors.Red
            };

            // Fuente para mensaje válido
            e.DataFormItem.ValidMessageLabelTextStyle = new DataFormTextStyle
            {
                FontFamily = "Normal",
                FontSize = 12,
                //FontAttributes = FontAttributes.None,
                TextColor = Colors.Green
            };
        }
    }
}
