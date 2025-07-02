using Microsoft.Maui.Controls;
using Calculator.ViewModels;    // ← Asegúrate de importar tu ViewModel

namespace Calculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var page = new MainPage();
            page.BindingContext = new MainViewModel();
            MainPage = page;
        }
    }
}
