using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using Pomelo.Data.MySql;

namespace LinqExpressionTest.Provider.MySql
{
    public class MysqlDb : IDb
    {
        public string ConnectionString { get; }
        public MysqlDb(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private MySqlConnection CreateConn()
        {
            var conn= new MySqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }
        public int Execute(string sql)
        {
            using (var conn = CreateConn())
            {
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }
        public T ExecuteScalar<T>(string sql)
        {
            using (var conn = CreateConn())
            {
                using (var cmd = new MySqlCommand(sql, conn))
                {

                    return (T)cmd.ExecuteScalar();

                }
            }
        }

        public List<T> Query<T>(string sql)
        {
            using (var conn = CreateConn())
            {
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    var list = new List<T>();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var obj = Activator.CreateInstance<T>();
                        var props = typeof(T).GetProperties();
                        foreach (var prop in props)
                        {
                            prop.SetValue(obj, reader[prop.Name]);
                        }
                        list.Add(obj);
                    }
                    return list;
                }
            }
        }
        public SqlQueryable<T> CreateQuery<T>()
        {
            var sqlbuilder = new MySqlBuilder();
            var translator = new MySqlTranslator<T>(sqlbuilder,this);
            return new SqlQueryable<T>(translator);
        }
    }
}
