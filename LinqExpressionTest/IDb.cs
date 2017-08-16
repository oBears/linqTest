using System.Collections.Generic;

namespace LinqExpressionTest
{
    public interface IDb
    {
        string ConnectionString { get; }
        int Execute(string sql);
        T ExecuteScalar<T>(string sql);
        List<T> Query<T>(string sql);
        SqlQueryable<T> CreateQuery<T>();
    }
}