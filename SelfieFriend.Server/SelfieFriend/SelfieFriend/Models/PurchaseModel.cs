using System.ComponentModel.DataAnnotations;

namespace SelfieFriend.Models
{
    public class PurchaseModel
    {
        [Required]
        public int ApplicationId { get; set; }
        [Required]
        public string Photo { get; set; }

    }
}