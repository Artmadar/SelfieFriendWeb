using System.Collections.Concurrent;
using System.Linq;
using Microsoft.AspNet.SignalR;


namespace SelfieFriend.Hubs
{
    public class OfferingHub : Hub
    {

        private static ConcurrentBag<HubUser> _users = new ConcurrentBag<HubUser>();

        public void SendOffering(string offerModel)
        {
           

            Clients.Others.offeringAdd(offerModel);
          
        }


        public void Connect(int userId)
        {
            var connectionId = Context.ConnectionId;

            if (_users.All(x => x.Id != userId))
            {
                if (_users.All(x => x.ConnectionId != connectionId))
                {
                    _users.Add(new HubUser()
                    {
                        Id = userId,
                        ConnectionId = connectionId
                    });
                }
            }
            else
            {
                var firstOrDefault = _users.FirstOrDefault(x => x.Id == userId);
                if (firstOrDefault != null)
                    firstOrDefault.ConnectionId = connectionId;
            }


        }


    }
}