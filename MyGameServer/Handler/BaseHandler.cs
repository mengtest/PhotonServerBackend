using Common;
using Photon.SocketServer;

namespace MyGameServer.Handler
{
    public abstract class BaseHander
    {
        public OperationCode OpCode;

        public abstract void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters,ClientPeer peer);
    }
}
