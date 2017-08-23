using Common;
using Common.Tools;
using MyGameServer.Handler;
using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace MyGameServer
{
    public class ClientPeer:Photon.SocketServer.ClientPeer
    {
        public string Username;
        public float X, Y, Z;

        public ClientPeer(InitRequest initRequest) : base(initRequest)
        {
        }

        //客户端发起请求时调用，接收客户端数据
        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            BaseHander handler = DictTool.GetValue(MyGameServer.Instance.HandlerDict,
                (OperationCode)operationRequest.OperationCode);

            if (handler!=null)
            {
                handler.OnOperationRequest(operationRequest,sendParameters,this);
            }
            else
            {
                BaseHander defaultHandler = DictTool.GetValue(MyGameServer.Instance.HandlerDict, OperationCode.Default);
                defaultHandler.OnOperationRequest(operationRequest, sendParameters, this);
            }
            #region 测试代码
            //            switch (operationRequest.OperationCode)
            //            {
            //                case 1:
            //                    //接收数据
            //                    MyGameServer.Log.Info("收到一条客户端请求");
            //                    Dictionary<byte, object> data = operationRequest.Parameters;
            //                    object intValue;
            //                    data.TryGetValue(1, out intValue);
            //                    object stringValue;
            //                    data.TryGetValue(2, out stringValue);
            //                    MyGameServer.Log.Info("得到的数据为：" + intValue + " 和 " + stringValue);
            //
            //                    //响应请求
            //                    Dictionary<byte, object> data2 = new Dictionary<byte, object>();
            //                    data2.Add(1,100);
            //                    data2.Add(2,"qwetdf");
            //                    OperationResponse response = new OperationResponse(1,data2);
            //                    SendOperationResponse(response, sendParameters);
            //
            //                    //发送事件
            //                    EventData ed=new EventData(1,data2);
            //                    SendEvent(ed, sendParameters);                   
            //                    break;
            //                default:
            //                    break;
            //            }
            

            #endregion
        }

        //客户端断开连接时调用
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            MyGameServer.Instance.PeerList.Remove(this);
        }
    }
}
