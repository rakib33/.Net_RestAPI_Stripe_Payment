using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StripePaymentTestApi.Models;


namespace StripePaymentTestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripePaymentTestController : ControllerBase
    {   
        
        public StripePaymentTestController()
        {
           
        }
        

        [HttpPost("CreditDetails")]
        public async Task<IActionResult> CreditDetails([FromForm] CreditDetails creditDetails)
        {

            return  Ok();
        }

     
      
    }
}
