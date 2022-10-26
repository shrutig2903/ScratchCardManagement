using Microsoft.EntityFrameworkCore;
using ScratchCardManagement.Models;
using ScratchCardManagement.Repository.Abstraction;
using ScratchCardManagement.ViewModels;
using System.Linq;
using System.Security.Cryptography;

namespace ScratchCardManagement.Repository.Implementation
{
    public class ScratchCardDetailsRepository : Repository<ScratchCard>, IScratchCardDetails
    {
        private DbContext _context;
        private readonly IUnitOfWork _UOW;
        DbSet<ScratchCard> dbSet;

        public ScratchCardDetailsRepository(DbContext context, IUnitOfWork UOW) : base(context)
        {
            this._context = context;
            this._UOW = UOW;
            dbSet = context.Set<ScratchCard>();
        }

        
        public List<ScratchCard> GetUnusedCards()
        {
            try
            {
                List<ScratchCardViewModel> scv = new List<ScratchCardViewModel>();
                
                var model = this.GetAllByCondition(x => x.IsActive == true && x.IsScratched == true).ToList();

                if(model != null)
                    return model;
                else
                    return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool GenerateCards(int number)
        {
            try
            {
                Random random = new Random();
                //var discountAmt = random.Next(0, 1000);
                //DateTime expiryDate = DateTime.UtcNow.AddDays(5);
                //var newScratchCard = new List<ScratchCard>();
                int n = 0;
                for (n = 0; n < number; n++)
                {
                    ScratchCard newScratchCard = new ScratchCard
                    {
                        DiscountAmount = random.Next(0, 1000),
                        IsScratched = false,
                        ExpiryDate = DateTime.UtcNow.AddDays(5),
                        IsActive = true
                    };
                    this.Add(newScratchCard);
                    this.SaveChanges();
                }
                if (n >= number)
                    return true;
                return false;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
