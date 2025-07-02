namespace Calculator.Models
{
    public class TipCalculatorModel
    {
        public decimal Consumption { get; set; }
        public int NumberOfPeople { get; set; }
        public double TipPercent { get; set; } // 0–50%
    }
}