using System.Collections.Generic;
using System.IO;
using Common;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net;
using log4net.Config;
using MyGameServer.Handler;
using MyGameServer.Threads;
using  Photon.SocketServer;
using LogManager = ExitGames.Logging.LogManager;

namespace MyGameServer
{
    class MyGameServer:ApplicationBase
    {
        public new static MyGameServer Instance{get; private set; }//单例
        public static readonly ILogger Log = LogManager.GetCurrentClassLogger();//用于日志输出
        public Dictionary<OperationCode,BaseHander> HandlerDict=new Dictionary<OperationCode, BaseHander>();//管理所有的handler
        public List<ClientPeer> PeerList=new List<ClientPeer>();//管理所有的client（客户端）

        private readonly SyncPositionThread _syncPositionThread=new SyncPositionThread();

        //当客户端和server连接时调用
        //返回一个PeerBase对象给Photon管理
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            Log.Info("一个客户端连接");
            ClientPeer peer=new ClientPeer(initRequest);
            PeerList.Add(peer);
            return peer;
        }

        //Photon启动后调用，用于server初始化
        protected override void Setup()
        {
            Instance = this;//单例赋值

            IniLog();//初始化日志
            IniHandler();//初始化Handler

            _syncPositionThread.Run();//启动线程

            Log.Info("SetUp完成!");
        }

        //server关闭时调用
        protected override void TearDown()
        {
            _syncPositionThread.Stop();//关闭线程
            Log.Info("服务器应用关闭");
        }

        //初始化日志
        void IniLog()
        {
            //日志配置文件初始化
            GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(ApplicationRootPath, "bin_Win64", "log");//日志存储路径
            GlobalContext.Properties["LogFileName"] = "My Game";//日志名字

            FileInfo configFileInfo = new FileInfo(Path.Combine(BinaryPath, "log4net.config"));//读取文件
            if (configFileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance);//指定log4net日志插件
                XmlConfigurator.ConfigureAndWatch(configFileInfo);//log4net读取配置文件
            }            
        }

        //初始化hanler
        void IniHandler()
        {
            LoginHandelr logingHandelr=new LoginHandelr();
            RegisterHandler registerHandler = new RegisterHandler();
            DefaultHandler defaultHandler=new DefaultHandler();
            SyncPositionHandler syncPositionHandler=new SyncPositionHandler();
            SyncPlayerHandler syncPlayerHandler=new SyncPlayerHandler();

            HandlerDict.Add(logingHandelr.OpCode,logingHandelr);
            HandlerDict.Add(registerHandler.OpCode,registerHandler);
            HandlerDict.Add(defaultHandler.OpCode,defaultHandler);
            HandlerDict.Add(syncPositionHandler.OpCode,syncPositionHandler);
            HandlerDict.Add(syncPlayerHandler.OpCode,syncPlayerHandler);
        }
    }
}
