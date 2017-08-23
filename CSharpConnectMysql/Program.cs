using System;
using MySql.Data.MySqlClient;

namespace CSharpConnectMysql
{
    class Program
    {
        static void Main(string[] args)
        {
//            Read();
//            Insert();
//            Update();
//            Delete();
//            ReadUsersCount();
//            ExcuteScalar();
            Console.WriteLine(Verify("zjd","111"));
            Console.ReadKey();
        }

        static bool Verify(string username,string password)
        {
            string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立连接");
//                string sql = "select * from users where username = '"+username+"' and password = '"+password+"'";
                string sql = "select * from users where username = @username and password = @password";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("username", username);
                cmd.Parameters.AddWithValue("password", password);

                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
            return false;        
        }

        static void Read()
        {
            string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立连接");

                string sql = "select * from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //                cmd.ExecuteReader();//执行查询语句（查）
                //                cmd.ExecuteNonQuery();//插入、删除、更新（增、删、改）
                //                cmd.ExecuteScalar();//查询，返回单个的值
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
//                    Console.WriteLine(reader[0] + "  " + reader[1] + "  " + reader[2] + "  " + reader[3]);
                    int id=reader.GetInt32("id");
                    string name = reader.GetString("username");
                    string password = reader.GetString("password");
                    Console.WriteLine(id + "  " + name + "  " + password);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
            Console.ReadKey();           
        }

        static void ReadUsersCount()
        {
            string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立连接");

                string sql = "select count(*) from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //                cmd.ExecuteReader();//执行查询语句（查）
                //                cmd.ExecuteNonQuery();//插入、删除、更新（增、删、改）
                //                cmd.ExecuteScalar();//查询，返回单个的值
                MySqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                int aa = Convert.ToInt32(reader[0]);
                Console.WriteLine(aa);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
            Console.ReadKey();
        }

        static void ExcuteScalar()
        {
            string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立连接");

                string sql = "select count(*) from users";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                //                cmd.ExecuteReader();//执行查询语句（查）
                //                cmd.ExecuteNonQuery();//插入、删除、更新（增、删、改）
                //                cmd.ExecuteScalar();//查询，返回单个的值
                object reader = cmd.ExecuteScalar();

                int aa = Convert.ToInt32(reader);
                Console.WriteLine(aa);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
            Console.ReadKey();
        }

        static void Insert()
        {
            string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立连接");

                string sql = "insert into users(username,password,registerdate) values('sicong','111','"+ DateTime.Now+"')";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//返回值是受影响的行数
                Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
            Console.ReadKey();
        }

        static void Update()
        {
            string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立连接");

                string sql = "update users set username='aaa',password='999' where id =4";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//返回值是受影响的行数
                Console.WriteLine(result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
            Console.ReadKey();
        }

        static void Delete()
        {
            string connectStr = "server=localhost;port=3306;database=mygamedb;user=root;password=root;";
            MySqlConnection conn = new MySqlConnection(connectStr);
            try
            {
                conn.Open();
                Console.WriteLine("已经建立连接");

                string sql = "delete from users where id =4";
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                int result = cmd.ExecuteNonQuery();//返回值是受影响的行数
                Console.WriteLine(result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                conn.Close();
            }
            Console.ReadKey();
        }
    }
}
