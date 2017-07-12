using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LinqExpressionTest.LinqProvider
{
    /// <summary>
    /// sql翻译器
    /// </summary>
    public class SqlTranslator
    {
        public  SqlBuilder SqlBuilder { get; }

        public SqlTranslator()
        {
            SqlBuilder = new SqlBuilder();
        }
        public void Translate(List<Expression> expressions)
        {
            expressions.ForEach(Translate);
        }
        public void Translate(Expression expression)
        {
            VisitExpression(expression);
        }
        private void VisitExpression(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.AndAlso:
                    VisitAndAlso((BinaryExpression)expression);
                    break; ;
                case ExpressionType.Equal:
                    VisitEqual((BinaryExpression)expression);
                    break;
                case ExpressionType.LessThan:
                case ExpressionType.LessThanOrEqual:
                    VisitLessThanOrEqual((BinaryExpression)expression);
                    break;
                case ExpressionType.GreaterThan:
                case ExpressionType.GreaterThanOrEqual:
                    GreaterThanOrEqual((BinaryExpression)expression);
                    break;
                case ExpressionType.Call:
                    VisitMethodCall((MethodCallExpression)expression);
                    break;
                case ExpressionType.Lambda:
                    VisitExpression(((LambdaExpression)expression).Body);
                    break;
                default:
                    break; ;
            }
        }
        /// <summary>
        /// 处理调用方法 如 Contains
        /// </summary>
        /// <param name="expression"></param>
        private void VisitMethodCall(MethodCallExpression expression)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 处理 >= 或 >
        /// </summary>
        /// <param name="expression"></param>
        private void GreaterThanOrEqual(BinaryExpression expression)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 处理 小于= 或小于
        /// </summary>
        /// <param name="expression"></param>
        private void VisitLessThanOrEqual(BinaryExpression expression)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 处理 &&
        /// </summary>
        /// <param name="andAlso"></param>
        private void VisitAndAlso(BinaryExpression andAlso)
        {
            //处理左边表达式
            VisitExpression(andAlso.Left);
            //处理右边表达式
            VisitExpression(andAlso.Right);
        }
        /// <summary>
        /// 处理 == 
        /// </summary>
        /// <param name="expression"></param>
        private void VisitEqual(BinaryExpression expression)
        {
            //节点类型是字段或属性
            if (expression.Left.NodeType == ExpressionType.MemberAccess)
            {
                var sql =
                    $"{((MemberExpression)expression.Left).Member.Name}={((ConstantExpression)expression.Right).Value}";
                SqlBuilder.AppendWhereOrAnd(sql);
            }
        }

    }
}
