using System;
using Microsoft.Maui.Controls;

namespace bfloresEP_S5.Views
{
    public partial class vRegistro : ContentPage
    {
        private string usuarioConectado;
        private double cuotaMensual = 0;

        public vRegistro(string usuario)
        {
            InitializeComponent();
            usuarioConectado = usuario;
            lblUsuario.Text = "Usuario conectado: " + usuarioConectado;
        }

        private void btnPagoMensual_Clicked(object sender, EventArgs e)
        {
            // Constantes según el enunciado del examen
            const double precioUPS = 300;
            const double porcentajeInicial = 0.15; // 15%
            const double interesPorCuota = 0.05; // 5%
            const int cuotas = 3;

            // Monto inicial (15% del precio)
            double montoInicial = precioUPS * porcentajeInicial; // = 45

            if (string.IsNullOrWhiteSpace(txtMontoInicial.Text))
            {
                txtMontoInicial.Text = montoInicial.ToString();
                DisplayAlert("Aviso", $"El monto inicial debe ser el 15% del precio: ${montoInicial}", "Aceptar");
                return;
            }

            if (!double.TryParse(txtMontoInicial.Text, out double montoInicialInput))
            {
                DisplayAlert("Error", "El monto inicial debe ser un número válido", "Aceptar");
                return;
            }

            // Verificar que el monto ingresado sea igual al esperado (15% de 300)
            if (Math.Abs(montoInicialInput - montoInicial) > 0.01)
            {
                DisplayAlert("Aviso", $"El monto inicial debe ser el 15% del precio: ${montoInicial}", "Aceptar");
                txtMontoInicial.Text = montoInicial.ToString();
            }

            // Cálculo correcto según el enunciado:
            // Resto del precio después del pago inicial
            double restante = precioUPS - montoInicial; // = 255

            // Monto base por cuota sin interés
            double cuotaBase = restante / cuotas; // = 85

            // Interés por cuota (5% del costo total del UPS, NO del saldo)
            double interes = precioUPS * interesPorCuota; // = 15

            // Cuota mensual = cuota base + interés
            cuotaMensual = cuotaBase + interes; // = 85 + 15 = 100

            // Mostrar resultado
            DisplayAlert("Cuota mensual", $"Cada cuota será de: ${cuotaMensual:F2}", "Aceptar");
        }

        private async void btnResumen_Clicked(object sender, EventArgs e)
        {
            // Validaciones
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                pkVoltiamperio.SelectedIndex == -1 ||
                fecha.Date == null ||
                pkCiudad.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtMontoInicial.Text) ||
                cuotaMensual <= 0)
            {
                await DisplayAlert("Error", "Por favor, completa todos los campos y calcula la cuota mensual.", "Aceptar");
                return;
            }

            // Reunir datos
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string va = pkVoltiamperio.SelectedItem.ToString();
            string fechaSeleccionada = fecha.Date.ToString("dd/MM/yyyy");
            string ciudad = pkCiudad.SelectedItem.ToString();

            // Cálculos según las especificaciones
            double montoInicial = 300 * 0.15; // 15% de 300 = 45
            double pagoTotal = montoInicial + (cuotaMensual * 3);

            // Navegar a la página de Resumen
            await Navigation.PushAsync(new vResumen(usuarioConectado, nombre, apellido, va,
                                                   fechaSeleccionada, ciudad, montoInicial,
                                                   cuotaMensual, pagoTotal));
        }
    }
}