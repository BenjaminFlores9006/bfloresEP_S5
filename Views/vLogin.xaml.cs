using System;
using Microsoft.Maui.Controls;

namespace bfloresEP_S5.Views
{
    public partial class vLogin : ContentPage
    {
        // Matriz de usuarios y contraseñas
        private Dictionary<string, string> usuarios = new Dictionary<string, string>
        {
            { "estudiante2025", "moviles" },
            { "uisrael", "2025" },
            { "sistemas", "2025_1" }
        };

        public vLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Clicked(object sender, EventArgs e)
        {
                if (usuarios.ContainsKey(txtUsuario.Text) && usuarios[txtUsuario.Text] == txtContrasena.Text)
                {
                Navigation.PushAsync(new vRegistro(txtUsuario.Text));
                }
                else
                {
                DisplayAlert("Error", "Usuario o contraseña incorrectos", "Aceptar");
                }
        }

        private void btnAcerca_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Acerca De",
                "Elaborado por Álvaro Benjamín Flores Guerrero\nDesarrollo de Aplicaciones Móviles\n8vo A",
                "Aceptar");
        }
    }
}
