using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqExpressionTest.LinqProvider
{
    public class SqlQueryable<T> : IOrderedQueryable<T>
    {
        public SqlQueryable(IQueryProvider baseProvider)
        {
            Provider = baseProvider;
            Expression = Expression.Constant(this);
        }
        public SqlQueryable(IQueryProvider baseProvider, Expression expression)
        {
            Provider = baseProvider;
            Expression = expression;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return ((IEnumerable<T>)Provider.Execute(Expression)).GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Type ElementType => typeof(T);
        public Expression Expression { get; }
        public IQueryProvider Provider { get; }
    }
}
