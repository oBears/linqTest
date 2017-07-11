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
        public SqlBuilder SqlBuilder { get; set; }
        public IQueryable<T> Select(Expression<Func<T, object>> expression)
        {
            //new SqlTranslator().Translate(expression);
            throw new NotImplementedException();
        }
        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}
