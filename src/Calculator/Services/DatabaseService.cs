using Microsoft.Data.Sqlite;
using ExpenseTracker.Models;
using System.Collections.Generic;

namespace ExpenseTracker.Services
{
    public class DatabaseService
    {
        private readonly string _dbPath;

        public DatabaseService(string dbPath)
        {
            _dbPath = dbPath;
            Initialize();
        }

        private void Initialize()
        {
            using var conn = new SqliteConnection($"Data Source={_dbPath}");
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText =
                "CREATE TABLE IF NOT EXISTS Transactions (" +
                "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                "Date TEXT, " +
                "Description TEXT, " +
                "Amount REAL, " +
                "IsIncome INTEGER)";
            cmd.ExecuteNonQuery();
        }

        public void AddTransaction(TransactionModel tx)
        {
            using var conn = new SqliteConnection($"Data Source={_dbPath}");
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText =
                "INSERT INTO Transactions(Date, Description, Amount, IsIncome) VALUES($date, $desc, $amt, $inc)";
            cmd.Parameters.AddWithValue("$date", tx.Date.ToString("o"));
            cmd.Parameters.AddWithValue("$desc", tx.Description);
            cmd.Parameters.AddWithValue("$amt", tx.Amount);
            cmd.Parameters.AddWithValue("$inc", tx.IsIncome ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public List<TransactionModel> GetAll() {
            var list = new List<TransactionModel>();
            using var conn = new SqliteConnection($"Data Source={_dbPath}");
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Id, Date, Description, Amount, IsIncome FROM Transactions";
            using var reader = cmd.ExecuteReader();
            while(reader.Read()) {
                list.Add(new TransactionModel {
                    Id = reader.GetInt32(0),
                    Date = DateTime.Parse(reader.GetString(1)),
                    Description = reader.GetString(2),
                    Amount = reader.GetDecimal(3),
                    IsIncome = reader.GetInt32(4) == 1
                });
            }
            return list;
        }
    }
}