using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ExpenseTracker.Models;

namespace ExpenseTracker.ViewModels
{
    public class NewTransactionViewModel : INotifyPropertyChanged
    {
        public string EntryDescription { get; set; }
        public decimal EntryAmount     { get; set; }
        public DateTime EntryDate      { get; set; } = DateTime.Today;
        public bool IsIncome           { get; set; }

        public ICommand SaveCommand   { get; }
        public ICommand CancelCommand { get; }

        public NewTransactionViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
        }

        private async void OnSave()
        {
            // guarda la transacción en DB (puedes inyectar DatabaseService aquí)
            // luego, cierra la página:
            await Shell.Current.GoToAsync("..");
        }

        private async void OnCancel()
        {
            await Shell.Current.GoToAsync("..");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string n = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(n));
    }
}
