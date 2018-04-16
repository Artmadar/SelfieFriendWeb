
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelfieFriend.Domain.Core
{
    public class PurchasePhoto: BaseSelfieFriendEntity
    {
        [Key]
        [ForeignKey("Purchase")]
        public new int Id { get; set; }

        public Purchase Purchase { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public int? ImageSize { get; set; }

        public double? Latitude { get; set; }

        public double? Logitude { get; set; }
    }
}
