namespace ScratchCardManagement.Repository.Abstraction
{
    public interface IUnitOfWork
    {
        IScratchCardDetails ScratchCardDetailsRepository { get; }
        IUserDetails UserDetailsRepository { get; }
        ITransactionDetails TransactionDetailsRepository { get; }

        void SaveChanges();
    }
}
