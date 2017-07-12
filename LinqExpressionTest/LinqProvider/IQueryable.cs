using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LinqExpressionTest.LinqProvider
{
    public interface IQueryable<T> where T:class
    {
  
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        IQueryable<T> Select(Expression<Func<T, object>> expression);
        List<T> ToList();

    }
}
