using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SelfieFriend.Domain.Core
{
    public class OfferingPhoto: BaseSelfieFriendEntity
    {
        [Key]
        [ForeignKey("Offering")]
        public new int Id { get; set; }

        public Offering Offering { get; set; }

        [Required]
        public string ImagePath { get; set; }

        public int? ImageSize { get; set; }

        public double? Latitude { get; set; }

        public double? Logitude { get; set; }

       

    }
}
