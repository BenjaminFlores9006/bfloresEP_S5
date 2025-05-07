using System;
using Microsoft.Maui.Controls;

namespace bfloresEP_S5.Views
{
    public partial class vResumen : ContentPage
    {
        private string nombre;
        private string apellido;
        private string va;
        private string fechaSeleccionada;
        private string ciudad;
        private double montoInicial;
        private double cuotaMensual;
        private double pagoTotal;

        public vResumen(string usuario)
        {
            InitializeComponent();
            lblUsuario.Text = "USUARIO CONECTADO: " + usuario;
        }

        public vResumen(string usuario, string nombre, string apellido, string va, string fechaSeleccionada,
                        string ciudad, double montoInicial, double cuotaMensual, double pagoTotal)
        {
            InitializeComponent();

            this.nombre = nombre;
            this.apellido = apellido;
            this.va = va;
            this.fechaSeleccionada = fechaSeleccionada;
            this.ciudad = ciudad;
            this.montoInicial = montoInicial;
            this.cuotaMensual = cuotaMensual;
            this.pagoTotal = pagoTotal;

            // Mostrar el usuario conectado
            lblUsuario.Text = "USUARIO CONECTADO: " + usuario;

            // Mostrar los datos en los labels
            lblNombre.Text = nombre;
            lblApellido.Text = apellido;
            lblVA.Text = va;
            lblFecha.Text = fechaSeleccionada;
            lblCiudad.Text = ciudad;
            lblMontoInicial.Text = "$" + montoInicial.ToString("F2");
            lblCuotaMensual.Text = "$" + cuotaMensual.ToString("F2");
            lblPagoTotal.Text = "$" + pagoTotal.ToString("F2");
        }

        private async void btnCerrarSesion_Clicked(object sender, EventArgs e)
        {
            // Navegar de vuelta a la página de inicio de sesión
            await Navigation.PopToRootAsync();
        }
    }
}