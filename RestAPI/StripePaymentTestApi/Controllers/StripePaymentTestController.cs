using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StripePaymentTestApi.Models;
using StripePaymentTestApi.Services;
using StripePaymentTestApi.utils;
using System.Net;


namespace StripePaymentTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripePaymentTestController : ControllerBase
    {
        private readonly UserCreditDetailsService _userCreditDetailsService;
        public StripePaymentTestController(UserCreditDetailsService userCreditDetailsService)
        {
           _userCreditDetailsService = userCreditDetailsService;
        }
        

        [HttpPost("CreditDetails")]
        public async Task<IActionResult> CreditDetails([FromForm] CreditDetails creditDetails)
        {
            string result = await _userCreditDetailsService.SaveCreditDetailsInfoToJsonFile(creditDetails);

            if (result == ResponseStatus.Credit_Details_Save_Code)
                return StatusCode(StatusCodes.Status201Created, ResponseStatus.Credit_Details_Save_Msg);

            else if(result == ResponseStatus.Credit_Details_Save_Failed_Code)
                return StatusCode(StatusCodes.Status500InternalServerError, ResponseStatus.Credit_Details_Save_Failed_Msg);

            return BadRequest(ResponseStatus.Credit_Details_Invalid_Msg);

        }

    }
}
