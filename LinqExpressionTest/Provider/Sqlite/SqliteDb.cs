using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using LinqExpressionTest.Provider.MySql;
using Microsoft.Data.Sqlite;

namespace LinqExpressionTest.Provider.Sqlite
{
    class SqliteDb : IDb
    {
        public string ConnectionString { get; }

        public SqliteDb(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private SqliteConnection CreateConn()
        {
            var conn = new SqliteConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        public int Execute(string sql)
        {
            using (var conn = CreateConn())
            {
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public T ExecuteScalar<T>(string sql)
        {
            using (var conn = CreateConn())
            {
                using (var cmd = new SqliteCommand(sql, conn))
                {

                    var obj = cmd.ExecuteScalar();

                    return (T)Convert.ChangeType(obj, typeof(T));

                }
            }
        }

        public List<T> Query<T>(string sql)
        {
            using (var conn = CreateConn())
            {
                using (var cmd = new SqliteCommand(sql, conn))
                {
                    var list = new List<T>();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var obj = Activator.CreateInstance<T>();
                        var props = typeof(T).GetProperties();
                        foreach (var prop in props)
                        {
                            try
                            {
                                prop.SetValue(obj, reader[prop.Name]);
                                list.Add(obj);
                            }
                            catch (Exception)
                            {

                            }

                        }

                    }
                    return list;
                }
            }
        }

        public SqlQueryable<T> CreateQuery<T>()
        {
            var sqlbuilder = new SqliteBuilder();
            var translator = new SqliteTranslator<T>(sqlbuilder, this);
            return new SqlQueryable<T>(translator);
        }
    }
}
