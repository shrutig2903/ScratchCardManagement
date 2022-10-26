using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScratchCardManagement.Constants;
using ScratchCardManagement.Models;
using ScratchCardManagement.Repository.Abstraction;
using ScratchCardManagement.ViewModels;
using System.Data;

namespace ScratchCardManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ScratchCardDetailsController : Controller
    {
        private readonly IUnitOfWork _UOW;
        private readonly IScratchCardDetails _ScratchCardDetails;
        public ScratchCardDetailsController(IUnitOfWork UOW)
        {
            _UOW = UOW;
        }
        [HttpGet]
        public async Task<ActionResult> GetUnusedScratchCards()
        {
            var results = _UOW.ScratchCardDetailsRepository.GetAllByCondition(x => x.IsActive == true && x.IsScratched == false).ToList();
   
            BaseResponse response = new BaseResponse();
            if (results != null)
            {
                response.Data = results;
                response.ResponseCode = HTTPConstants.OK;
                response.ResponseMessage = MessageConstants.ScratchCardDetailsDetchSuccess;
            }
            else
            {
                response.Data = results;
                response.ResponseCode = HTTPConstants.BAD_REQUEST;
                response.ResponseMessage = MessageConstants.ScratchCardDetailsDetchfailure;
                return BadRequest(response);

            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<ActionResult> GenerateScratchCards(int N)
        {
            try
            {
                BaseResponse response = new BaseResponse();
                var unusedCard = _UOW.ScratchCardDetailsRepository.GetUnusedCards();
                if (unusedCard.Count >= N)
                {
                    response.Data = unusedCard.Count;
                    response.ResponseCode = HTTPConstants.BAD_REQUEST;
                    response.ResponseMessage = MessageConstants.ScratchCardCountHigh;
                    return BadRequest(response);
                }
                else
                {
                    bool result = _UOW.ScratchCardDetailsRepository.GenerateCards(N);
                    if (result == true)
                    {
                        response.Data = unusedCard.Count;
                        response.ResponseCode = HTTPConstants.OK;
                        response.ResponseMessage = MessageConstants.ScratchCardGeneratedSuccessfully;

                    }

                    else
                    {
                        response.Data = unusedCard.Count;
                        response.ResponseCode = HTTPConstants.OK;
                        response.ResponseMessage = MessageConstants.ScratchCardGenerationFailure;
                        return BadRequest(response);
                    }
                }
                return Ok(response);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
