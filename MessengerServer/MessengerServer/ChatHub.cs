using Microsoft.AspNetCore.SignalR;

namespace Messenger
{
    public class ChatHub : Hub
    {
        public async Task Send(string username, string message)
        {
            await this.Clients.All.SendAsync("Receive", username, message);
        }

        //public async Task Connect()
        //{
        //    await this.Clients.All.SendAsync("Receive", message);
        //}
    }
}