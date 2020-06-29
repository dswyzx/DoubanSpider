using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using NLog;
using System;
using System.Collections.Generic;

namespace DoubanSpider
{
    public class MysqlDapper
    {
        public static readonly Logger nlog = LogManager.GetCurrentClassLogger();
        protected readonly MySqlConnection connection;
        public MysqlDapper()
        {
            string conn = Program.configuration["Option:ConnectionString"];
            try
            {
                connection = new MySqlConnection() { ConnectionString = conn };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T GetByID<T>(int id) where T : class
        {
            T res = connection.Get<T>(id);
            return res;
        }


        public int InsertObj<T>(T obj) where T : class
        {
            return (int)connection.Insert<T>(obj);

        }

        public int InsertObjList<T>(IEnumerable<T> list) where T : class
        {
            try
            {
                return (int)connection.Insert(list);
            }
            catch (Exception e)
            {
                nlog.Error(e);
                return 0;
            }
        }


    }

}
