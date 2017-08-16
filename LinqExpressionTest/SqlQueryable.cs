using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LinqExpressionTest.Provider;

namespace LinqExpressionTest
{
    public class SqlQueryable<T>
    {
        private List<Expression> Expressions { get; }
        private ISqlTranslator<T> Translator { get; }

        public SqlQueryable(ISqlTranslator<T> translator)
        {
            Translator = translator;
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
            Translator.Translate(Expressions);
            return Translator.Execute();
        }
    }
}
