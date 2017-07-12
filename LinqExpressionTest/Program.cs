using System;
using System.Linq;
using LinqExpressionTest.LinqProvider;
using LinqExpressionTest.Models;

namespace LinqExpressionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var translator = new SqlTranslator();
         
            var sqlQuery = new SqlQueryable<Student>();
            var res = sqlQuery.Where(x => x.Gender == "男")
                .Where(x => x.Id == 1)
                .ToList();
              
            Console.WriteLine("Hello World!");
        }
    }
}