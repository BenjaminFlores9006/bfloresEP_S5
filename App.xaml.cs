using bfloresEP_S5.Views;

namespace bfloresEP_S5
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            return new Window(new NavigationPage(new vLogin()));
        }
    }
}