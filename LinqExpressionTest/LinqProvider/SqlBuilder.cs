using System;
using System.Collections.Generic;
using System.Text;

namespace LinqExpressionTest.LinqProvider
{
    public class SqlBuilder
    {
        private readonly StringBuilder _builder;
        public SqlBuilder()
        {
            _builder=new StringBuilder();
        }
        public string TableName { set; get; }
        /// <summary>
        /// 表别名
        /// </summary>
        public string TableAlias { set; get; }

        public void AddParams(string key,object value)
        {
            _builder.Append($"{key}={value}");
        }
        public override string ToString()
        {
            return _builder.ToString();
        }
    }
}
