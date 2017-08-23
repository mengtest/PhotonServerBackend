using System.Collections.Generic;
using System.IO;
using Common;
using Photon.SocketServer;
using System.Xml.Serialization;
using log4net.Util;

namespace MyGameServer.Handler
{
    class SyncPlayerHandler:BaseHander
    {
        public SyncPlayerHandler()
        {
            OpCode = OperationCode.SyncPlayer;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            //取得所有已经登录的用户名,通知客户端
            List<string> usernameList=new List<string>();
            foreach (ClientPeer clientPeer in MyGameServer.Instance.PeerList)
            {
                if (!string.IsNullOrEmpty(clientPeer.Username) && clientPeer != peer)
                {
                    usernameList.Add(clientPeer.Username);
                }
            }
//            usernameList.Add("123");

            StringWriter sw=new StringWriter();
            XmlSerializer serializer=new XmlSerializer(typeof(List<string>));
            serializer.Serialize(sw,usernameList);
            sw.Close();
            string usernameListString = sw.ToString();

//            MyGameServer.Log.Info(usernameListString);

            Dictionary<byte,object> data=new Dictionary<byte, object>();
            data.Add((byte)ParamererCode.UsernameList, usernameListString);
            OperationResponse response=new OperationResponse(operationRequest.OperationCode);
            response.Parameters = data;
            peer.SendOperationResponse(response,sendParameters);

            //告诉其他客户端，有新的客户端加入
            foreach (ClientPeer clientPeer in MyGameServer.Instance.PeerList)
            {
                if (!string.IsNullOrEmpty(clientPeer.Username)&&clientPeer!=peer)
                {
                    EventData ed=new EventData((byte)EventCode.NewPlayer);
                    Dictionary<byte, object> data2 = new Dictionary<byte, object>();
                    data2.Add((byte)ParamererCode.Username, peer.Username);
                    ed.Parameters = data2;
                    clientPeer.SendEvent(ed, sendParameters);
                }               
            }
        }
    }
}
