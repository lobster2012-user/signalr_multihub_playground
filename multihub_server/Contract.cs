using System;
using System.Collections.Generic;
using System.Text;

namespace multihub_server
{
    public static class HubContract
    {
        public static readonly Uri Uri = 
            new Uri("http://127.0.0.1:57654/multihub/hello?hubs=Hello1Hub,Hello2Hub");
    }
}
