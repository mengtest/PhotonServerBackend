using System;
using Common;
using Common.Tools;
using Photon.SocketServer;

namespace MyGameServer.Handler
{
    class SyncPositionHandler:BaseHander
    {

        public SyncPositionHandler()
        {
            OpCode=OperationCode.SyncPosition;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
//            Vector3Data pos = (Vector3Data)DictTool.GetValue(operationRequest.Parameters, (byte)ParamererCode.Position);
            float x = (float)DictTool.GetValue(operationRequest.Parameters, (byte)ParamererCode.X);
            float y = (float)DictTool.GetValue(operationRequest.Parameters, (byte)ParamererCode.Y);
            float z = (float)DictTool.GetValue(operationRequest.Parameters, (byte)ParamererCode.Z);
            peer.X = x;
            peer.Y = y;
            peer.Z = z;
        }
    }
}
