using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class UnpopularProductsQuery : Query {
        public UnpopularProductsQuery() : base("Unpopular products", "Returns all the product IDs from products that haven't been ordered since April 1st 1998", QueryTypes.Advanced) { }

        public override object Execute() {
            var listA = (from c in ObjectDatabase.Products select c.ProductID).ToList();

            var listB = (from o in ObjectDatabase.Orders
                         join od in ObjectDatabase.OrderDetails on o.OrderID equals od.OrderID
                         where o.OrderDate >= new DateTime(1998, 4, 1)
                         select od.ProductID
                         ).ToList();

            return listA.Except(listB);
        }
    }

    public class BestSalesmenQuery : Query {
        public BestSalesmenQuery() : base("Worst salesmen", "Returns all the employees whose average order price is lower than the company average order price.", QueryTypes.Advanced) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }
}
