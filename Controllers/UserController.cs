using Microsoft.AspNetCore.Mvc;
using ScratchCardManagement.Constants;
using ScratchCardManagement.Repository.Abstraction;
using ScratchCardManagement.ViewModels;

namespace ScratchCardManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        private readonly IUnitOfWork _UOW;
        private readonly IUserDetails _UserDetails;
        public UserController(IUnitOfWork UOW)
        {
            _UOW = UOW;
        }

        [HttpPost]
        public async Task<ActionResult> AddUser(UserViewModel user)
        {
            try
            {
                BaseResponse response = new BaseResponse();
                if (user == null)
                {
                    response.Data = user;
                    response.ResponseCode = HTTPConstants.BAD_REQUEST;
                    response.ResponseMessage = MessageConstants.NoRecordFound;
                    return BadRequest(response);
                }
                var userdetails = _UOW.UserDetailsRepository.GetUserByEmail(user.Email);
                if (userdetails == null)
                {
                    var result = _UOW.UserDetailsRepository.AddNewUser(user);
                    response.Data = user;
                    response.ResponseCode = HTTPConstants.OK;
                    response.ResponseMessage = MessageConstants.UserRecordAdded;
                }
                else
                {
                    response.Data = userdetails.Email;
                    response.ResponseCode = HTTPConstants.BAD_REQUEST;
                    response.ResponseMessage = MessageConstants.EmailAlreadyPresent;
                    return BadRequest(response);
                }
                return Ok(response);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetAllUsers()
        {
            List<UserViewModel> user = new List<UserViewModel>();
            user=_UOW.UserDetailsRepository.GetAllActiveUsers();

            BaseResponse response = new BaseResponse();
            
            response.Data = user;
            response.ResponseCode = HTTPConstants.OK;
            response.ResponseMessage = MessageConstants.AllActiveUsers;
            return Ok(response);
        }

        //public async Task<ActionResult> UpdateUserDetails()

    }
}
