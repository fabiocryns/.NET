using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class InnerJoinQuery : Query {
        public InnerJoinQuery() : base("Product list (with category names)", "Lists all the products in the database with their respective categories.", QueryTypes.Joins) { }

        public override object Execute() {
            return from p in ObjectDatabase.Products
                   join c in ObjectDatabase.Categories on p.CategoryID equals c.CategoryID
                   select new { p.ProductName, c.CategoryName };
        }
    }

    public class LeftOuterJoinQuery : Query {
        public LeftOuterJoinQuery() : base("Employees (with managers)", "Lists the employees in the database (with the name of their manager).", QueryTypes.Joins) { }

        public override object Execute() {
            return from e in ObjectDatabase.Employees
                   join ee in ObjectDatabase.Employees on e.ReportsTo equals ee.EmployeeID into eee
                   from eeee in eee.DefaultIfEmpty()
                   select new { Employee = string.Concat(e.FirstName, e.LastName), Manager = string.Concat(eeee?.FirstName, eeee?.LastName) };
        }
    }
}
