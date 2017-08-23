using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml.Serialization;
using Common;
using Photon.SocketServer;

namespace MyGameServer.Threads
{
    public class SyncPositionThread
    {
        private Thread t;

        public void Run()
        {
            t=new Thread(UpdatePosition);
            t.IsBackground = true;
            t.Start();
        }

        public void Stop()
        {
            t.Abort();
        }

        private void UpdatePosition()
        {
            Thread.Sleep(5000);

            while (true)
            {
                
                Thread.Sleep(50);
                //进行同步                
                SendPosition();
            }           
        }

        private void SendPosition()
        {
            List<PlayerData> playerDataList = new List<PlayerData>();
            
            foreach (ClientPeer peer in MyGameServer.Instance.PeerList)
            {                
                if (!string.IsNullOrEmpty(peer.Username))
                {
                    PlayerData playerData = new PlayerData
                    {
                        Username = peer.Username,
                        Pos = new Vector3Data {X = peer.X, Y = peer.Y, Z = peer.Z}
                    };
                    playerDataList.Add(playerData);
                }
            }

            //序列化
            XmlSerializer serializer=new XmlSerializer(typeof(List<PlayerData>));
            StringWriter sw = new StringWriter();
            serializer.Serialize(sw,playerDataList);
            sw.Close();
            string playerDataListString = sw.ToString();


            //分发
            Dictionary<byte, object> data = new Dictionary<byte, object>
            {
                {(byte) ParamererCode.PlayerDataList, playerDataListString}
            };

            foreach (ClientPeer peer in MyGameServer.Instance.PeerList)
            {
                if (!string.IsNullOrEmpty(peer.Username))
                {   
                    MyGameServer.Log.Info(peer.Username);
                    EventData ed = new EventData((byte) EventCode.SyncPosition) {Parameters = data};
                    peer.SendEvent(ed, new SendParameters());
//                    MyGameServer.Log.Info(peer.Username);
                }
            }
        }
    }
}
