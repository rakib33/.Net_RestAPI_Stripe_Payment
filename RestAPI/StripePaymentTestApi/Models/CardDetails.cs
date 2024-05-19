using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StripePaymentTestApi.Models
{
    public class CardDetails
    { 

        [Required]      
        [Display(Name ="Card Number")]
        public string CardNumber { get; set; }

        [Required]       
        [Display(Name = "Expire Month(mm)")]
        public string ExpiryMonth { get; set; }


        [Required]
        [Display(Name = "Expire Year(yy)")]
        public string ExpiryYear { get; set; }

        [Required]
        [Display(Name = "Account Name")]
        public string NameOnCard { get; set; }

        [Required]      
        [Display(Name = "Card Security Code")]        
        public string CardSecurityCode { get; set; }
    }
}
