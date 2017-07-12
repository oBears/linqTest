using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqExpressionTest.LinqProvider
{
    public class SqlQueryable<T> : IQueryable<T> where T : class
    {
        private List<Expression> Expressions { set; get; }

        public SqlQueryable()
        {
            Expressions=new List<Expression>();
        }

        public IQueryable<T> Select(Expression<Func<T, object>> expression)
        {
            Expressions.Add(expression);
            return this;
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
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
