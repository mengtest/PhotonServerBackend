using System;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NHibernateConnectMysql.Manger;
using NHibernateConnectMysql.Model;

namespace NHibernateConnectMysql
{
    class Program
    {
        static void Main()
        {
//            var configuration = new Configuration();
//            configuration.Configure();//解析配置文件
//            configuration.AddAssembly("NHibernateConnectMysql");
//
//            ISessionFactory sessionFactory = null;
//            ISession session = null;
//            ITransaction iTransaction = null;
//
//            try
//            {
//                sessionFactory = configuration.BuildSessionFactory();
//                session = sessionFactory.OpenSession();//打开数据库的会话
//
//                //                User user=new User(){Username="kjlkjkl",Password = "12333"};
//                //
//                //                session.Save(user);
//
//                //事务
//                iTransaction = session.BeginTransaction();
//
//                User user1 = new User() { Username = "kjlkjkl3", Password = "12333" };
//                User user2 = new User() { Username = "kjlkjkl3", Password = "12333" };
//
//                session.Save(user1);
//                session.Save(user2);
//
//                iTransaction.Commit();
//            }
//            catch (Exception e)
//            {
//                Console.WriteLine(e);
//            }
//            finally
//            {
//                if (iTransaction != null)
//                {
//                    iTransaction.Dispose();
//                }
//                if (session != null)
//                {
//                    session.Close();
//                }
//                if (sessionFactory != null)
//                {
//                    sessionFactory.Close();
//                }
//            }
//            Console.ReadKey();
//
//            User user = new User() { Id = 8, Username = "4444", Password = "4444" };
//            IUserManager userManager = new UserManager();
//            userManager.Add(user);
//            userManager.Update(user);
//            userManager.Remove(user);
//            Console.WriteLine(userManager.GetById(6).Username);
//            Console.WriteLine(userManager.GetByUsername("zjd").Password);
//            Console.WriteLine(userManager.GetAllUsers().Count);
//            Console.WriteLine(userManager.VerifyUser("zjd","111"));
//            Console.WriteLine(userManager.VerifyUser("zjd","1112"));
        }

    }
}
