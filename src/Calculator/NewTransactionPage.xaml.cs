using Microsoft.Maui.Controls;
using ExpenseTracker.ViewModels;   // ← importa tu ViewModel

namespace ExpenseTracker
{
    public partial class NewTransactionPage : ContentPage
    {
        public NewTransactionPage()
        {
            InitializeComponent();                  // <-- debe resolverse
            BindingContext = new NewTransactionViewModel();
        }
    }
}

