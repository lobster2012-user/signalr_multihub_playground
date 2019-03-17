using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace multihub_server
{
    public interface IHello1Client
    {
        [HubMethodName("IHello1Client_OnMessage")] //does not work now
        Task IHello1Client_OnMessage(string text);
    }

}
