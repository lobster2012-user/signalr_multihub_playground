using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace multihub_server
{
    public interface IHello2Client
    {
        [HubMethodName("IHello2Client_OnMessage")]//does not work now
        Task IHello2Client_OnMessage(string text);
    }

}
