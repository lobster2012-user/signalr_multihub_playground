using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace multihub_server
{
    //TODO: REWRITE
    public static class CreateHubHelperExtensions
    {
        private static Type GetClientType(Type hubType)
        {
            while(hubType != null)
            {
                if (hubType.IsGenericType)
                {
                    if(hubType.GetGenericTypeDefinition() == typeof(Hub<>))
                    {
                        return hubType.GetGenericArguments()[0];
                    }
                }
                hubType = hubType.BaseType;
            }
            throw new InvalidOperationException("not found client type");
        }

        public delegate Hub CreateHubDelegate<TMulti>(MultiHubBase<TMulti> src1, MultiHubBase<TMulti> src2)
            where TMulti : class;

        private static class CreateHubHelper<THub, TClient, TMulti>
      where TMulti : class
      where TClient : class
      where THub : Hub<TClient>
        {
            public static readonly CreateHubDelegate<TMulti> CreateHub = CreateHubFunc();            

            private static CreateHubDelegate<TMulti> CreateHubFunc()
            {
                var method = typeof(MultiHubBase<TMulti>).GetMethod("CreateHubFrom", System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance).MakeGenericMethod
                        (typeof(THub), typeof(TClient), typeof(TMulti));
                return (CreateHubDelegate<TMulti>)Delegate.CreateDelegate(typeof(CreateHubDelegate<TMulti>), method);
            }
        }
        private static class CreateHubHelper<TMulti>
               where TMulti : class
        {
            public static CreateHubDelegate<TMulti> CreateHub(Type hubType)
            {
                return Functors.GetOrAdd(hubType, CreateHubFuncImpl);
            }
            private static CreateHubDelegate<TMulti> CreateHubFuncImpl(Type hubType)
            {
                var clientType = GetClientType(hubType);

                var method = typeof(CreateHubHelper<,,>)
                    .MakeGenericType(hubType, clientType, typeof(TMulti))
                    .GetField("CreateHub", System.Reflection.BindingFlags.Public |
                    System.Reflection.BindingFlags.Static).GetValue(null);

                return (CreateHubDelegate<TMulti>)method;
            }

            private static ConcurrentDictionary<Type, CreateHubDelegate<TMulti>> Functors
                 = new ConcurrentDictionary<Type, CreateHubDelegate<TMulti>>();
        }

        public static Hub CreateHub<TMulti>(this MultiHubBase<TMulti> src, Type hub)
              where TMulti : class
        {
            return CreateHubHelper<TMulti>.CreateHub(hub)(src, src);
        }

        public static THub CreateHub<THub,TMulti>(this MultiHubBase<TMulti> src)
             where TMulti : class
            where THub : Hub
        {
            return (THub)CreateHub<TMulti>(src, typeof(THub));
        }

        public static THub CreateHub<THub, TClient, TMulti>(this MultiHubBase<TMulti> src)
     where TMulti : class
      where TClient : class
      where THub : Hub<TClient>
        {
            return (THub)CreateHubHelper<THub, TClient, TMulti>.CreateHub(src, src);
        }
    }


}
