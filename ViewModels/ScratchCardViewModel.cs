﻿namespace ScratchCardManagement.ViewModels
{
    public class ScratchCardViewModel
    {
        public Guid Id { get; set; }
        public double DiscountAmount { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsScratched { get; set; }
        public bool IsActive { get; set; }
    }
}
