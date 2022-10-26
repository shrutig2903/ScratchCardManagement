using ScratchCardManagement.Models;
using ScratchCardManagement.ViewModels;

namespace ScratchCardManagement.Repository.Abstraction
{
    public interface ITransactionDetails : IRepository<Transaction>
    {
        public bool AssignUsersToCard(List<UserCardviewModel> usv);
    }
}
