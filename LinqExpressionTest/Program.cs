using System;
using System.Linq;
using System.Text;
using LinqExpressionTest.Provider.MySql;
using LinqExpressionTest.Models;
using LinqExpressionTest.Provider.Sqlite;

//using Microsoft.Data.Sqlite;



namespace LinqExpressionTest
{
    class Program
    {
        static void Main(string[] args)
        {

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            var db = new SqliteDb("Data Source=linqTest;");
            InitSqliteDataBase(db);
            var list = db.CreateQuery<Student>()
                 .Where(x => x.Name == "张三")
                .Select(x => new
                {
                    x.Gender,
                    x.Name
                })
                 .ToList();
            list.ForEach(s => Console.WriteLine($"Id:{s.Id}  Name:{s.Name}  Gender:{s.Gender}"));
            Console.Read();
        }

        private static void InitSqliteDataBase(IDb db)
        {

            var res = db.ExecuteScalar<int>("SELECT COUNT(*) FROM sqlite_master where type='table' and name='Student'");
            if (res == 0)
            {
                db.Execute(@" CREATE TABLE Student(
   Id INTEGER  PRIMARY KEY,
   Name           TEXT    NOT NULL,
   Gender         TEXT     NOT NULL
);");
                db.Execute("insert into Student(Name,Gender) values('张三','男')");
                db.Execute("insert into Student(Name,Gender) values('李四','男')");
                db.Execute("insert into Student(Name,Gender) values('王五','男')");
                db.Execute("insert into Student(Name,Gender) values('张三','女')");
                db.Execute("insert into Student(Name,Gender) values('张三','男')");
            }


        }
    }
}