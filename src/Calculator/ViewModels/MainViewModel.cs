using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using Calculator.Models;

namespace Calculator.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private decimal _consumption;
        private int _numberOfPeople = 1;
        private double _tipPercent;



        public MainViewModel()
        {
            SetTipCommand = new Command<string>(OnSetTip);
            DecreasePeopleCommand = new Command(() =>
            {
                if (NumberOfPeople > 1)
                    NumberOfPeople--;
            });

            IncreasePeopleCommand = new Command(() =>
            {
                NumberOfPeople++;
            });

        }

        public decimal Consumption
        {
            get => _consumption;
            set { _consumption = value; OnPropertyChanged(); Recalculate(); }
        }

        public int NumberOfPeople
        {
            get => _numberOfPeople;
            set
            {
                if (_numberOfPeople == value) return;
                _numberOfPeople = value;
                OnPropertyChanged(nameof(NumberOfPeople));
                Recalculate();
            }
        }

        public ICommand DecreasePeopleCommand { get; }
        public ICommand IncreasePeopleCommand { get; }

        
        public double TipPercent
        {
            get => _tipPercent;
            set { _tipPercent = value; OnPropertyChanged(); Recalculate(); }
        }

        public ICommand SetTipCommand { get; }

        private void OnSetTip(string param)
        {
            if (int.TryParse(param, out int pct))
                TipPercent = pct;
        }

        public double SubtotalPerPerson { get; private set; }
        public double TipPerPerson      { get; private set; }
        public double TotalPerPerson    { get; private set; }

        private void Recalculate()
        {
            SubtotalPerPerson = (double)Consumption / NumberOfPeople;
            double totalTip = (double)Consumption * TipPercent / 100.0;
            TipPerPerson = totalTip / NumberOfPeople;
            TotalPerPerson = SubtotalPerPerson + TipPerPerson;
            OnPropertyChanged(nameof(SubtotalPerPerson));
            OnPropertyChanged(nameof(TipPerPerson));
            OnPropertyChanged(nameof(TotalPerPerson));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}