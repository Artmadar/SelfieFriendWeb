namespace SelfieFriend.Models
{
    public class PhotoModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public string Photo { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
    }
}