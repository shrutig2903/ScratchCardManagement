using ScratchCardManagement.Models;
using ScratchCardManagement.ViewModels;

namespace ScratchCardManagement.Repository.Abstraction
{
    public interface IUserDetails : IRepository<User>
    {

        public User GetUserByEmail(string email);
        public bool AddNewUser(UserViewModel user);
        public List<UserViewModel> GetAllActiveUsers();
    }
}
