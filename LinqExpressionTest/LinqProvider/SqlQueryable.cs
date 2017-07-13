using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqExpressionTest.LinqProvider
{
    public class SqlQueryable<T>
    {
        private List<Expression> Expressions { get; }

        public SqlQueryable()
        {
            Expressions=new List<Expression>();
        }

        public SqlQueryable<T> Select(Expression<Func<T, object>> expression)
        {
            Expressions.Add(expression);
            return this;
        }
        public SqlQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            Expressions.Add(expression);
            return this;
        }

        public List<T> ToList()
        {
            var translate= new SqlTranslator<T>();
            translate.Translate(Expressions);
            var sql= translate.SqlBuilder.ToString();
            Console.WriteLine(sql);
            return  new List<T>();
        }
    }
}
