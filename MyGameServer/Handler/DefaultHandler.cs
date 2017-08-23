using Common;
using Photon.SocketServer;

namespace MyGameServer.Handler
{
    class DefaultHandler:BaseHander
    {
        public DefaultHandler()
        {
            OpCode = OperationCode.Default;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            
        }
    }
}
