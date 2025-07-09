namespace ExpenseTracker.Models
{
    public class TransactionModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public bool IsIncome { get; set; } // true = ingreso, false = gasto
    }
}