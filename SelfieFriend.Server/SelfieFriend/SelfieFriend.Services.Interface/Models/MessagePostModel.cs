namespace SelfieFriend.Services.Interface.Models
{
    public class MessagePostModel
    {

        public int ApplicationId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string AvatarPath { get; set; }
        public string Text { get; set; }
        public bool MyMessage { get; set; }
    }
}
