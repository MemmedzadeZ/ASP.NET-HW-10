
using Microsoft.AspNetCore.SignalR;
using WebSignalRApiHW.Helpers;

namespace WebSignalRApiHW.Hubs
{
    public class MessageHub:Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Clients.All.SendAsync("ReceiveConnectInfo", "User connected");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.Others.SendAsync("RecieveDisConnectedInfo", "User disconnected");
        }

        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message + "'s Offer : ", FileHelper.Read());
        }

        public async Task CountDownStarted()
        {
            await Clients.Others.SendAsync("SecondCount");
        }
    }
}
