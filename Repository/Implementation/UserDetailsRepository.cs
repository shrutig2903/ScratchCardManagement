using Microsoft.EntityFrameworkCore;
using ScratchCardManagement.Models;
using ScratchCardManagement.Repository.Abstraction;
using ScratchCardManagement.ViewModels;
using System.Linq;
using System.Security.Cryptography;

namespace ScratchCardManagement.Repository.Implementation
{
    public class UserDetailsRepository : Repository<User>, IUserDetails
    {

            private DbContext _context;
            private readonly IUnitOfWork _UOW;
            DbSet<User> dbSet;

            public UserDetailsRepository(DbContext context, IUnitOfWork UOW) : base(context)
            {
                this._context = context;
                this._UOW = UOW;
                dbSet = context.Set<User>();
            }

        public User GetUserByEmail(string email)
        {
            var user = this.GetAllByCondition(X => X.Email.Equals(email)).FirstOrDefault();

            return user;
        }

        public bool AddNewUser(UserViewModel user)
        {
            User Newuser = new User
            {
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                IsActive = true
            };
            if(Newuser!=null)
            {
                this.Add(Newuser);
                this.SaveChanges();
                return true;
            }
            else
                return false;
            
            
        }

        public List<UserViewModel> GetAllActiveUsers()
        {
            var result = _UOW.UserDetailsRepository.GetAllByCondition(x => x.IsActive == true).ToList();

            List<UserViewModel> usv=new List<UserViewModel>();
            foreach(var user in result)
            {
                UserViewModel newusv = new UserViewModel
                {
                    UserId = user.UserId,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    IsActive = user.IsActive
                };
                usv.Add(newusv);
            }

            return usv;
        }
    }
}
