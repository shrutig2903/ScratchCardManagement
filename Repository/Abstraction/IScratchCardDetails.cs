using ScratchCardManagement.Models;
using ScratchCardManagement.ViewModels;

namespace ScratchCardManagement.Repository.Abstraction
{
    public interface IScratchCardDetails: IRepository<ScratchCard>
    {
        public List<ScratchCard> GetUnusedCards();
        public bool GenerateCards(int number);
    }
}
