﻿namespace FinancePal.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Type { get; set; } = null!; // Income / Expense

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        // Navigation property
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
