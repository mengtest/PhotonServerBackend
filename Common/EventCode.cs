namespace Common
{
    public enum EventCode:byte//区分服务器向客户端发送的事件的类型
    {
        NewPlayer,
        SyncPosition,
    }
}
