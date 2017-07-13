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
            var res = new SqlQueryable<Student>()
                .Where(x => x.Gender == "男"&&x.Id==1)
                .Select(x=>new
                {
                    x.Gender,
                    x.Name
                })
                .ToList();
            Console.Read();
        }
    }
}