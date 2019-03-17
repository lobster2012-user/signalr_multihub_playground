using System;

namespace multihub_server
{
    public static class CreateHubHelperExtensions
    {
        private static class CreateHubHelper<THub, TClient, TMulti>
       where TMulti : class
        {
            public static readonly CreateHubDelegate CreateFunc = CreateHubFunc();

            public delegate THub CreateHubDelegate(MultiHubBase<TMulti> src1, MultiHubBase<TMulti> src2);

            private static CreateHubDelegate CreateHubFunc()
            {
                var method = typeof(MultiHubBase<TMulti>).GetMethod("CreateHubFrom", System.Reflection.BindingFlags.NonPublic |
                    System.Reflection.BindingFlags.Instance).MakeGenericMethod
                        (typeof(THub), typeof(TClient), typeof(TMulti));
                return (CreateHubDelegate)Delegate.CreateDelegate(typeof(CreateHubDelegate), method);
            }
        }
        public static THub CreateHub<THub,TClient,TMulti>(this MultiHubBase<TMulti> src)
              where TMulti : class
        {
            return CreateHubHelper<THub, TClient, TMulti>.CreateFunc(src, src);
        }
    }
   

}
