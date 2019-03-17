using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace multihub_server
{
    public class Hello2Hub : Hub<IHello2Client>
    {
        private readonly ILogger _logger;

        public Hello2Hub(ILogger<Hello1Hub> logger)
        {
            logger.LogDebug($"***** hello2: ctor");
            _logger = logger;
        }
        public void OnMessage(string text)
        {
            _logger.LogDebug($"***** hello2: {text}");
            this.Clients.Caller.IHello2Client_OnMessage("response:!hello2hub");
        }
        protected override void Dispose(bool disposing)
        {
            _logger.LogDebug($"***** hello2: dispose");
            base.Dispose(disposing);
        }
    }

}
