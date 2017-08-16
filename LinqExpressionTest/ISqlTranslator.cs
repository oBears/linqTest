using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LinqExpressionTest
{
    public interface ISqlTranslator<T>
    {
        void Translate(List<Expression> expressions);
        void Translate(Expression expression);
        List<T> Execute();
    } 
   
}
