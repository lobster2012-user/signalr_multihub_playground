using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace multihub_server
{
    public class MultiHubCallerClientsToConcrete<TMulti, TTo> : IHubCallerClients<TTo>
        where TMulti : TTo
    {
        private readonly IHubCallerClients<TMulti> _src;

        public MultiHubCallerClientsToConcrete(IHubCallerClients<TMulti> src)
        {
            _src = src;
        }

        public TTo Caller => _src.Caller;

        public TTo Others => _src.Others;

        public TTo All => _src.All;

        public TTo AllExcept(IReadOnlyList<string> excludedConnectionIds)
        {
            return _src.AllExcept(excludedConnectionIds);
        }

        public TTo Client(string connectionId)
        {
            return _src.Client(connectionId);
        }

        public TTo Clients(IReadOnlyList<string> connectionIds)
        {
            return _src.Clients(connectionIds);
        }

        public TTo Group(string groupName)
        {
            return _src.Group(groupName);
        }

        public TTo GroupExcept(string groupName, IReadOnlyList<string> excludedConnectionIds)
        {
            return _src.GroupExcept(groupName, excludedConnectionIds);
        }

        public TTo Groups(IReadOnlyList<string> groupNames)
        {
            return _src.Groups(groupNames);
        }

        public TTo OthersInGroup(string groupName)
        {
            return _src.OthersInGroup(groupName);
        }

        public TTo User(string userId)
        {
            return _src.User(userId);
        }

        public TTo Users(IReadOnlyList<string> userIds)
        {
            return _src.Users(userIds);
        }
    }

}
