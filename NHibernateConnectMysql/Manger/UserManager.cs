using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Criterion;
using NHibernateConnectMysql.Model;

namespace NHibernateConnectMysql.Manger
{
    class UserManager:IUserManager
    {
        public void Add(User user)
        {         
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (ITransaction transaction=session.BeginTransaction())
                {
                    session.Save(user);
                    transaction.Commit();
                }             
            }
        }

        public void Update(User user)
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(user);
                    transaction.Commit();
                }
            }
        }

        public void Remove(User user)
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(user);
                    transaction.Commit();
                }
            }
        }

        public User GetById(int id)
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    User user= session.Get<User>(id);
                    transaction.Commit();
                    return user;
                }
            }
        }

        public User GetByUsername(string username)
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                User user =session
                    .CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("Username", username))
                    .UniqueResult<User>();
                return user;
            }
        }

        public ICollection<User> GetAllUsers()
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                ICriteria criteria = session.CreateCriteria(typeof(User));
                return criteria.List<User>();
            }
        }

        public bool VerifyUser(string username, string password)
        {
            using (ISession session = NhibernateHelper.OpenSession())
            {
                User user = session
                    .CreateCriteria(typeof(User))
                    .Add(Restrictions.Eq("Username", username))
                    .Add(Restrictions.Eq("Password", password))
                    .UniqueResult<User>();

                if (user==null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
