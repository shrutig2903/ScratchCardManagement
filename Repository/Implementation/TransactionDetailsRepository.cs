using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScratchCardManagement.Constants;
using ScratchCardManagement.Models;
using ScratchCardManagement.Repository.Abstraction;
using ScratchCardManagement.ViewModels;
using System.Data;

namespace ScratchCardManagement.Repository.Implementation
{
    public class TransactionDetailsRepository : Repository<Transaction>, ITransactionDetails
    {
        private DbContext _context;
        private readonly IUnitOfWork _UOW;
        DbSet<Transaction> dbSet;
        private ScratchCardDetailsRepository scratchCard;
        private UserDetailsRepository userDetails;

        public TransactionDetailsRepository(DbContext context, IUnitOfWork UOW) : base(context)
        {
            this._context = context;
            this._UOW = UOW;
            dbSet = context.Set<Transaction>();
            scratchCard = new ScratchCardDetailsRepository(context, UOW);
            userDetails = new UserDetailsRepository(context, UOW);
        }

        public bool AssignUsersToCard(List<UserCardviewModel> usv)
        {
            try
            {
                Transaction transaction = new Transaction();
                ScratchCard chkCard = new ScratchCard();

                foreach (var user in usv)
                {
                    if (user.userId != null)
                    {
                        chkCard = scratchCard.GetById(user.ScratchCardId);
                        if (chkCard != null)
                        {
                            chkCard.IsScratched=true;
                        }
                        if ((chkCard.ExpiryDate.CompareTo(DateTime.Now)) < 0)
                        {
                            return false;
                        }

                        transaction = new Transaction
                        {
                            TransactionAmount = user.ScratchCardAmount,
                            TransactionDate = DateTime.Now,
                            User = userDetails.GetById(user.userId),
                            ScratchCard = chkCard

                        };
                        this.Add(transaction);
                        this.SaveChanges();
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
