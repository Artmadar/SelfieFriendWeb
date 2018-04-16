using System.ComponentModel.DataAnnotations;

namespace SelfieFriend.Domain.Core
{
    public abstract class BaseSelfieFriendEntity
    {
        [Key]
        public int Id { get; set; }

    }
}
