namespace bfloresEP_S5.Views;

public partial class vResumen : ContentPage
{
    private string nombre;
    private string apellido;
    private string? va;
    private string fechaSeleccionada;
    private string? ciudad;
    private double montoInicial;
    private double cuotaMensual;
    private double pagoTotal;

    public vResumen(string usuario)
	{
		InitializeComponent();
        lblUsuario.Text = "USUARIO CONECTADO " + usuario;
    }

    public vResumen(string usuario, string nombre, string apellido, string? va, string fechaSeleccionada, string? ciudad, double montoInicial, double cuotaMensual, double pagoTotal) : this(usuario)
    {
        this.nombre = nombre;
        this.apellido = apellido;
        this.va = va;
        this.fechaSeleccionada = fechaSeleccionada;
        this.ciudad = ciudad;
        this.montoInicial = montoInicial;
        this.cuotaMensual = cuotaMensual;
        this.pagoTotal = pagoTotal;
    }

    private void btnCerrarSesion_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new vLogin());
    }
}