using System;
using Microsoft.Maui.Controls;

namespace bfloresEP_S5.Views
{
    public partial class vRegistro : ContentPage
    {
        private string usuarioConectado;

        public vRegistro(string usuario)
        {
            InitializeComponent();
            usuarioConectado = usuario;
            lblUsuario.Text = "Usuario conectado: " + usuarioConectado;
        }

        private double cuotaMensual = 0;

        private void btnPagoMensual_Clicked(object sender, EventArgs e)
        {
            const double precioUPS = 300;
            const double porcentajeInicial = 0.15;
            const double interesPorCuota = 0.05;
            int cuotas = 3;

            // Calcular monto inicial
            double montoInicial = precioUPS * porcentajeInicial;

            // Calcular pago por cuota con interés
            double restante = precioUPS - montoInicial;
            double cuotaBase = restante / cuotas;
            cuotaMensual = cuotaBase + (cuotaBase * interesPorCuota);

            // Mostrar resultado
            DisplayAlert("Cuota mensual", $"Cada cuota será de: {cuotaMensual:C2}", "Aceptar");
        }

        private async void btnResumen_Clicked(object sender, EventArgs e)
        {
            // Validación simple
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                pkVoltiamperio.SelectedIndex == -1 ||
                pkCiudad.SelectedIndex == -1 ||
                cuotaMensual <= 0)
            {
                await DisplayAlert("Error", "Por favor, completa todos los campos y calcula la cuota mensual.", "Aceptar");
                return;
            }

            // Reunir datos
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            string va = pkVoltiamperio.SelectedItem.ToString();
            string ciudad = pkCiudad.SelectedItem.ToString();
            string fechaSeleccionada = fecha.Date.ToString("dd/MM/yyyy");
            double montoInicial = 300 * 0.15;
            double pagoTotal = montoInicial + (cuotaMensual * 3);

            // Navegar a Resumen
            await Navigation.PushAsync(new vResumen(usuarioConectado, nombre, apellido, va, fechaSeleccionada, ciudad, montoInicial, cuotaMensual, pagoTotal));
        }
    }
}
