using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScratchCardManagement.Constants;
using ScratchCardManagement.Models;
using ScratchCardManagement.Repository.Abstraction;
using ScratchCardManagement.ViewModels;

namespace ScratchCardManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TransactionController : Controller
    {
        private readonly IUnitOfWork _UOW;
        private readonly ITransactionDetails _TransactionDetails;
        public TransactionController(IUnitOfWork UOW)
        {
            _UOW = UOW;
        }
        
        [HttpPost]
        public async Task<ActionResult> AddTransactions(List<UserCardviewModel> ucv)
        {

            BaseResponse response = new BaseResponse();

            bool result = _UOW.TransactionDetailsRepository.AssignUsersToCard(ucv);
            if(result== false)
            {
                response.Data = result;
                response.ResponseCode = HTTPConstants.BAD_REQUEST;
                response.ResponseMessage = MessageConstants.CardExpired;
                return BadRequest(response);
            }
            else
            {
                response.Data = result;
                response.ResponseCode = HTTPConstants.OK;
                response.ResponseMessage = MessageConstants.ScratchCardUsed;
            }
            return Ok(response);
            

        }
    }
}
