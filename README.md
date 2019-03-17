# signalr multihub playground

SignalR MultiHub Implementation

[SignalR Multiple hub per connection problem](https://github.com/aspnet/AspNetCore/issues/6380)

Only Server-Side.


```csharp

    /// <summary>
    /// TODO: dynamic generation 
    /// </summary>
    public class MultiHub : MultiHubBase<IMultiClient>
    {
        private Hello1Hub Hello1Hub => CreateHub<Hello1Hub>();
        private Hello2Hub Hello2Hub => CreateHub<Hello2Hub>();

        public MultiHub(ILogger<MultiHub> logger, IServiceProvider provider)
            : base(logger, provider, new[] { typeof(Hello1Hub), typeof(Hello2Hub) })
        {
        }

        [HubMethodName(nameof(Hello1Hub_OnMessage))]
        public void Hello1Hub_OnMessage(string text) => Hello1Hub.OnMessage(text);

        [HubMethodName(nameof(Hello2Hub_OnMessage))]
        public void Hello2Hub_OnMessage(string text) => Hello2Hub.OnMessage(text);
    }

```
