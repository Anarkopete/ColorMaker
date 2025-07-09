using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using ExpenseTracker.Models;
using ExpenseTracker.Services;

namespace ExpenseTracker.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly DatabaseService _db;

        public MainViewModel()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "expense.db");
            _db = new DatabaseService(dbPath);
            Transactions = new ObservableCollection<TransactionModel>(_db.GetAll());

            AddIncomeCommand = new Command(OnAddIncome);
            AddExpenseCommand = new Command(OnAddExpense);

            Recalculate();
        }

        public decimal EntryAmount { get; set; }
        public string EntryDescription { get; set; }

        public ObservableCollection<TransactionModel> Transactions { get; }

        public decimal TotalIncome { get; private set; }
        public decimal TotalExpense { get; private set; }
        public decimal Balance => TotalIncome - TotalExpense;

        public ICommand AddIncomeCommand { get; }
        public ICommand AddExpenseCommand { get; }

        private void OnAddIncome()
            => AddTransaction(true);

        private void OnAddExpense()
            => AddTransaction(false);

        private void AddTransaction(bool isIncome)
        {
            var tx = new TransactionModel {
                Date = DateTime.Now,
                Description = EntryDescription,
                Amount = EntryAmount,
                IsIncome = isIncome
            };
            _db.AddTransaction(tx);
            Transactions.Add(tx);
            Recalculate();
        }

        private void Recalculate()
        {
            TotalIncome = 0;
            TotalExpense = 0;
            foreach(var tx in Transactions)
            {
                if(tx.IsIncome) TotalIncome += tx.Amount;
                else TotalExpense += tx.Amount;
            }
            OnPropertyChanged(nameof(TotalIncome));
            OnPropertyChanged(nameof(TotalExpense));
            OnPropertyChanged(nameof(Balance));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}