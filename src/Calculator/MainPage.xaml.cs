using ExpenseTracker.ViewModels;
using Microsoft.Maui.Controls;  // para TabbedPage

namespace ExpenseTracker          // <- debe ser el mismo namespace
{
    public partial class MainPage : ContentPage   // <- ¡partial!
    {
        public MainPage()
        {
            InitializeComponent();   // aquí es generado tras compilar XAML
            BindingContext = new MainViewModel();
        }
         private async void OnAddTransactionClicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new NewTransactionPage());
            
            // Obtener ViewModel
            if (BindingContext is not MainViewModel vm)
                return;

            // Selección de tipo de transacción
            string tipo = await DisplayActionSheet(
                "Tipo de transacción",
                "Cancelar",
                null,
                "Ingreso",
                "Gasto");
            if (tipo == "Cancelar" || tipo == null)
                return;

            // Pedir descripción
            string desc = await DisplayPromptAsync(
                "Descripción",
                "Ingrese la descripción:");
            if (string.IsNullOrWhiteSpace(desc))
                return;

            // Pedir monto
            string montoStr = await DisplayPromptAsync(
                "Monto",
                "Ingrese el monto:",
                keyboard: Keyboard.Numeric);
            if (!decimal.TryParse(montoStr, out decimal monto))
                return;

            // Asignar datos y ejecutar comando correspondiente
            vm.EntryDescription = desc;
            vm.EntryAmount = monto;
            if (tipo == "Ingreso")
                vm.AddIncomeCommand.Execute(null);
            else
                vm.AddExpenseCommand.Execute(null);
        }
    }
}
