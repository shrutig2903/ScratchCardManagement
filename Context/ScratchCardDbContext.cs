using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ScratchCardManagement.Models;

namespace ScratchCardManagement.Context
{
    public class ScratchCardDbContext :DbContext
    {
        public ScratchCardDbContext(DbContextOptions options)
            : base(options)
        {
        }

        DbSet<User> Users { get; set; }
        DbSet<Transaction> Transactions { get; set; }
        DbSet<ScratchCard> ScratchCards { get; set; }

    }
}
