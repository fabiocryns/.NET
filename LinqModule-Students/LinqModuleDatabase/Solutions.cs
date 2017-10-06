using System;
using System.Collections.Generic;
using System.Linq;
using LinqModule.Model;

namespace LinqModule {
    internal static class Solutions {
        public static IEnumerable<string> DistinctQuery { get; } = ObjectDatabase.Orders.Where(o => o.OrderDate >= new DateTime(1998, 1, 1)).Select(s => s.CustomerID).Distinct();
        public static IEnumerable<string> UnionQuery { get; } = ObjectDatabase.Suppliers.Select(s => s.CompanyName).Union(ObjectDatabase.Shippers.Select(sh => sh.CompanyName));
        public static IEnumerable<Order> TakeQuery { get; } = ObjectDatabase.Orders.Take(5);
        public static IEnumerable<Employee> SkipQuery { get; } = ObjectDatabase.Employees.Skip(3);
        public static IEnumerable<object> InnerJoinQuery { get; } = from product in ObjectDatabase.Products join category in ObjectDatabase.Categories on product.CategoryID equals category.CategoryID select new { product.ProductName, category.CategoryName };
        public static IEnumerable<object> LeftOuterJoinQuery { get; } = from employee in ObjectDatabase.Employees join manager in ObjectDatabase.Employees on employee.ReportsTo equals manager.EmployeeID into e from x in e.DefaultIfEmpty() select new { Employee = employee.FirstName + " " + employee.LastName, Manager = x == null ? null : x.FirstName + " " + x.LastName };
        public static bool AnyQuery { get; } = ObjectDatabase.Employees.Any(c => c.HireDate.Value.Subtract(c.BirthDate.Value).TotalDays > 50 * 365);
        public static bool AllQuery { get; } = ObjectDatabase.Suppliers.All(c => c.Phone != null);
        public static bool ContainsQuery { get; } = ObjectDatabase.OrderDetails.Select(c => c.ProductID).Contains(11);
        public static Employee FirstQuery { get; } = ObjectDatabase.Employees.OrderBy(c => c.BirthDate).First();
        public static Employee SingleQuery { get; } = ObjectDatabase.Employees.Where(c => c.ReportsTo == null).Single();
        public static Order SingleOrDefaultQuery { get; } = ObjectDatabase.Orders.Where(c => c.OrderID == 666).SingleOrDefault();
        public static IEnumerable<Supplier> WhereQuery { get; } = ObjectDatabase.Suppliers.Where(s => s.Country == "Germany");
        public static IEnumerable<object> SelectQuery { get; } = ObjectDatabase.Employees.Select(e => new { Name = string.Format("{0} {1} {2}", e.TitleOfCourtesy, e.FirstName, e.LastName), BirthDate = e.BirthDate });
        public static IEnumerable<Employee> OrderByQuery { get; } = ObjectDatabase.Employees.OrderBy(e => e.HireDate);
        public static IEnumerable<object> GroupByQuery { get; } = ObjectDatabase.Orders.GroupBy(e => e.CustomerID).Select(s => new { CustomerID = s.Key, OrderCount = s.Count() });
        public static int CountQuery { get; } = ObjectDatabase.Employees.Count();
        public static int FilteredCountQuery { get; } = ObjectDatabase.Employees.Count(e => e.ReportsTo == null);
        public static decimal? CheapestProductQuery { get; } = ObjectDatabase.Products.Min(c => c.UnitPrice);
        public static decimal? MostExpensiveProductQuery { get; } = ObjectDatabase.Products.Max(c => c.UnitPrice);
        public static decimal? AverageProductPriceQuery { get; } = ObjectDatabase.Products.Average(c => c.UnitPrice);
        public static IEnumerable<int> UnpopularProductsQuery { get; } = ObjectDatabase.Products.Select(p => p.ProductID).Except(from o in ObjectDatabase.Orders join od in ObjectDatabase.OrderDetails on o.OrderID equals od.OrderID where o.OrderDate > new DateTime(1998, 4, 1) select od.ProductID);
        public static IEnumerable<object> BestSalesmenQuery { get; } = from e in ObjectDatabase.Employees let companyAverage = ObjectDatabase.OrderDetails.Sum(c => { return c.UnitPrice * c.Quantity * (1M - (decimal)c.Discount); }) / (decimal)ObjectDatabase.Orders.Count() let employeeAverage = (from od in ObjectDatabase.OrderDetails join o in ObjectDatabase.Orders on od.OrderID equals o.OrderID where o.EmployeeID == e.EmployeeID group od by od.OrderID into g select new { Price = g.Sum(c => { return c.UnitPrice * c.Quantity * (1M - (decimal)c.Discount); }) }).Average(c => c.Price) where employeeAverage < companyAverage select new { e.FirstName, e.LastName, AveragePrice = employeeAverage };
    }
}