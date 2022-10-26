using ScratchCardManagement.Context;
using ScratchCardManagement.Repository.Abstraction;

namespace ScratchCardManagement.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ScratchCardDbContext _dbcontext;
        private readonly IUnitOfWork _UOW;

        public UnitOfWork(ScratchCardDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        private IScratchCardDetails _ScratchCardDetailsRepository;

        public IScratchCardDetails ScratchCardDetailsRepository
        {
            get
            {
                if (_ScratchCardDetailsRepository == null)
                {
                    _ScratchCardDetailsRepository = new ScratchCardDetailsRepository(_dbcontext,_UOW);
                }
                return _ScratchCardDetailsRepository;
            }
        }

        private IUserDetails _UserDetailsRepository;

        public IUserDetails UserDetailsRepository
        {
            get
            {
                if (_UserDetailsRepository == null)
                {
                    _UserDetailsRepository = new UserDetailsRepository(_dbcontext, _UOW);
                }
                return _UserDetailsRepository;
            }
        }

        private ITransactionDetails _TransactionDetailsRepository;

        public ITransactionDetails TransactionDetailsRepository
        {
            get
            {
                if (_TransactionDetailsRepository == null)
                {
                    _TransactionDetailsRepository = new TransactionDetailsRepository(_dbcontext, _UOW);
                }
                return _TransactionDetailsRepository;
            }
        }

        public void SaveChanges()
        {
            this._dbcontext.SaveChanges();
        }
    }
}
