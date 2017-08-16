using System.Collections.Generic;
using System.Linq;

namespace LinqExpressionTest.Provider.MySql
{
    public class MySqlBuilder : ISqlBuilder
    {
        private string SqlTemplate => "SELECT {0} FROM {1}{2} ";
        private  List<string> WhereInfos { get; }
        private List<string> SelectInfos { get; }
        private  string WhereSql => string.Join(" ",WhereInfos);
        private string SelectSql => string.Join(",", SelectInfos);
        public string TableName { set; get; }

        public MySqlBuilder()
        {
            WhereInfos=new List<string>();
            SelectInfos=new List<string>();
        }
        public void AppendWhereOrAnd(string sqlString)
        {
            WhereInfos.Add(WhereInfos.Any() ? (" AND " + sqlString):(" WHERE " + sqlString));
        }
        public void AppendSelect(string fieldName)
        {
            SelectInfos.Add(fieldName);
        }
        public override string ToString()
        {
            return string.Format(SqlTemplate,SelectSql, TableName,WhereSql);
        }
    }
}
