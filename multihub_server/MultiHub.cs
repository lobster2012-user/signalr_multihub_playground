using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace multihub_server
{

    /// <summary>
    /// TODO: dynamic generate 
    /// </summary>
    public class MultiHub : MultiHubBase<IMultiClient>
    {
        private Hello1Hub Hello1Hub => CreateHub<Hello1Hub, IHello1Client>();
        private Hello2Hub Hello2Hub => CreateHub<Hello2Hub, IHello2Client>();

        public MultiHub(ILogger<MultiHub> logger, IServiceProvider provider)
            : base(logger, provider, new[] { typeof(Hello1Hub), typeof(Hello2Hub) })
        {
        }

        [HubMethodName(nameof(Hello1Hub_OnMessage))]
        public void Hello1Hub_OnMessage(string text) => Hello1Hub.OnMessage(text);

        [HubMethodName(nameof(Hello2Hub_OnMessage))]
        public void Hello2Hub_OnMessage(string text) => Hello2Hub.OnMessage(text);
    }
}
