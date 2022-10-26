namespace ScratchCardManagement.Models
{
    public class ScratchCard
    {
        public Guid ScratchCardId { get; set; }
        public double DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsScratched { get; set; }
        public bool IsActive { get; set; }

    }
}
