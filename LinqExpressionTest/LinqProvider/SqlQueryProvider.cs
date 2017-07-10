using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace LinqExpressionTest.LinqProvider
{
    public class SqlQueryProvider : IQueryProvider
    {
        private SqlBuilder sqlBuilder;
        public IQueryable CreateQuery(Expression expression)
        {
            sqlBuilder = new SqlExpressionVisitor().ProcessExpression(expression);

            throw new NotImplementedException();
        }
        public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
        {
            return new SqlQueryable<TElement>(this, expression);
        }
        /// <summary>
        /// 执行sql 返回结果
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public object Execute(Expression expression)
        {
            //String url = GetQueryText(expression);
            //IEnumerable<Post> results = PostHelper.PerformWebQuery(url);

            //return results;
            throw new NotImplementedException();
        }

        public TResult Execute<TResult>(Expression expression)
        {
            return (TResult)Execute(expression);
        }
    }
}
