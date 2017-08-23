using Common;
using Common.Tools;
using MyGameServer.Manger;
using Photon.SocketServer;

namespace MyGameServer.Handler
{
    class LoginHandelr:BaseHander
    {
        public LoginHandelr()
        {
            OpCode = OperationCode.Login;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            string username = DictTool.GetValue(operationRequest.Parameters, (byte)ParamererCode.Username) as string;
            string password = DictTool.GetValue(operationRequest.Parameters, (byte)ParamererCode.Password) as string;
//            MyGameServer.Log.Info(username+"  "+password);

            UserManager userManger=new UserManager();
            bool isExit= userManger.VerifyUser(username, password);

//            MyGameServer.Log.Info(isExit);

            OperationResponse response=new OperationResponse(operationRequest.OperationCode);
            if (isExit)
            {
                response.ReturnCode = (short)ReturenCode.Success;
                peer.Username = username;
            }
            else
            {
                response.ReturnCode = (short)ReturenCode.Failed;
            }

            peer.SendOperationResponse(response, sendParameters);
        }
    }
}
