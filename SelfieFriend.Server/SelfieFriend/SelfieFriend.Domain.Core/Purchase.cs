
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace SelfieFriend.Domain.Core
{
    public class Purchase: BaseSelfieFriendEntity
    {
        [Key]
        [ForeignKey("Inquiry")]
        public new int Id { get; set; }

        public PurchasePhoto PurchasePhoto { get; set; }  

        public Inquiry Inquiry { get; set; }
        public bool Bought { get; set; }
    }
}
