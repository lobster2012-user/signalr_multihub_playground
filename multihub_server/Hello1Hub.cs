using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace multihub_server
{
    public class Hello1Hub : Hub<IHello1Client>
    {
        private readonly ILogger _logger;

        public Hello1Hub(ILogger<Hello1Hub> logger)
        {
            logger.LogDebug($"**** hello1: ctor");
            _logger = logger;
        }
        public void OnMessage(string text)
        {
            _logger.LogDebug($"**** hello1: {text}");
            this.Clients.Caller.IHello1Client_OnMessage("response:!hello1hub");
        }

        protected override void Dispose(bool disposing)
        {
            _logger.LogDebug($"**** hello1: dispose");
            base.Dispose(disposing);
        }
    }

}
