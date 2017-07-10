﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace LinqExpressionTest.LinqProvider
{
    public class SqlExpressionVisitor
    {
        private SqlBuilder _sqlBuilder;
        /// <summary>
        /// 处理表达式，返回sql语句
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public SqlBuilder ProcessExpression(Expression expression)
        {
            _sqlBuilder=new SqlBuilder();
            VisitExpression(expression);
            return _sqlBuilder;
        }

        private void VisitExpression(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.AndAlso:
                    VisitAndAlso((BinaryExpression)expression);
                    break;;
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
                    break;;
                    
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
            if (expression.Left.NodeType== ExpressionType.MemberAccess)
            {
                _sqlBuilder.AddParams(((MemberExpression)expression.Left).Member.Name,((ConstantExpression)expression.Right).Value);
            }
        }
    }
}