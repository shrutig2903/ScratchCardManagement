using System.ComponentModel.DataAnnotations;

namespace ScratchCardManagement.ViewModels
{
    public class UserViewModel
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsActive { get; set; }
    }
}
