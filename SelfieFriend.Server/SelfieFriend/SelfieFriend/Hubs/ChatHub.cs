using Microsoft.AspNet.SignalR;

namespace SelfieFriend.Hubs
{
    public class ChatHub : Hub
    {
        public void PushChatMessageToClients(string message)
        {
            Clients.Others.addChatMessage(message);
        }
    }
}