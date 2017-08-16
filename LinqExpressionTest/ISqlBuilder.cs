namespace LinqExpressionTest
{
    public interface ISqlBuilder
    {
        string TableName { get; set; }
        void AppendSelect(string fieldName);
        void AppendWhereOrAnd(string sqlString);

    }
}