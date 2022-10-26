namespace ScratchCardManagement.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public DateTime TransactionDate { get; set; }
        public double TransactionAmount { get; set; }
        public User User { get; set; }
        public ScratchCard ScratchCard { get; set; }
    }
}
