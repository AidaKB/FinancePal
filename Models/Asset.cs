namespace FinancePal.Models
{
    public class Asset
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public string Name { get; set; } = null!; // بانک، طلا، سکه و ...

        public string Type { get; set; } = null!; // Bank / Gold / Coin / Cash

        public decimal Value { get; set; }

        public string Currency { get; set; } = "IRR";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
