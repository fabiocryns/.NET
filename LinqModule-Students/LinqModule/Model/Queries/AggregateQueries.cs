using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries
{
    public class CountQuery : Query
    {
        public CountQuery() : base("Number of employees", "Counts all the employees in the database.", QueryTypes.AggregateFunctions) { }

        public override object Execute()
        {
            return (from e in ObjectDatabase.Employees select e).Count();
        }
    }

    public class FilteredCountQuery : Query
    {
        public FilteredCountQuery() : base("Top managers", "Counts all the employees who report to no one.", QueryTypes.AggregateFunctions) { }

        public override object Execute()
        {
            return (from e in ObjectDatabase.Employees where e.ReportsTo == null select e).Count();
        }
    }

    public class CheapestProductQuery : Query
    {
        public CheapestProductQuery() : base("Cheapest product", "Returns the lowest product unit price.", QueryTypes.AggregateFunctions) { }

        public override object Execute()
        {
            return ObjectDatabase.Products.Min(p => p.UnitPrice);
        }
    }

    public class MostExpensiveProductQuery : Query
    {
        public MostExpensiveProductQuery() : base("Most expensive product", "Returns the highest product unit price.", QueryTypes.AggregateFunctions) { }

        public override object Execute()
        {
            return ObjectDatabase.Products.Max(p => p.UnitPrice);
        }
    }

    public class AverageProductPriceQuery : Query
    {
        public AverageProductPriceQuery() : base("Average product price", "Returns the average product unit price.", QueryTypes.AggregateFunctions) { }

        public override object Execute()
        {
            return ObjectDatabase.Products.Average(p => p.UnitPrice);
        }
    }

    public class GroupByQuery : Query
    {
        public GroupByQuery() : base("Customer activity", "Lists all the customers and the number of orders they have placed.", QueryTypes.Basic) { }

        public override object Execute()
        {
            return from o in ObjectDatabase.Orders from c in ObjectDatabase.Customers where c.CustomerID == o.CustomerID group c by c.CustomerID into cu select new { CustomerID = cu.Key, OrderCount = cu.Count() };
        }
    }
}