using Common;
using Common.Tools;
using MyGameServer.Manger;
using Photon.SocketServer;
using MyGameServer.Model;

namespace MyGameServer.Handler
{
    class RegisterHandler:BaseHander
    {
        public RegisterHandler()
        {
            OpCode = OperationCode.Register;
        }

        public override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters, ClientPeer peer)
        {
            string username = DictTool.GetValue(operationRequest.Parameters, (byte)ParamererCode.Username) as string;
            string password = DictTool.GetValue(operationRequest.Parameters, (byte)ParamererCode.Password) as string;

            UserManager userManger = new UserManager();
            User user = userManger.GetByUsername(username);
            OperationResponse response = new OperationResponse(operationRequest.OperationCode);
            if (user==null)
            {
                user = new User() {Username = username, Password = password};
                userManger.Add(user);
                response.ReturnCode = (short) ReturenCode.Success;
            }
            else
            {
                response.ReturnCode = (short) ReturenCode.Failed;
            }
            peer.SendOperationResponse(response, sendParameters);
        }
    }
}
