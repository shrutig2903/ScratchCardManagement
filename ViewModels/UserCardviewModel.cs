using Microsoft.Extensions.Configuration.UserSecrets;

namespace ScratchCardManagement.ViewModels
{
    public class UserCardviewModel
    {
        public Guid userId { get; set; }
        public Guid ScratchCardId { get; set; }

        public double ScratchCardAmount { get; set; }
    }
}
