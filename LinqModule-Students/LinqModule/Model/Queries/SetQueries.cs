using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class DistinctQuery : Query {
        public DistinctQuery() : base("Active customers", "Lists all the customers that ordered something since the beginning of 1998.", QueryTypes.Set) { }

        public override object Execute() {
            var listA = (from c in ObjectDatabase.Customers select c.CustomerID).ToList();
            var listB = (from o in ObjectDatabase.Orders where o.OrderDate >= new DateTime(1998, 1, 1) select o.CustomerID).ToList();
            return listA.Intersect(listB);
        }
    }

    public class UnionQuery : Query {
        public UnionQuery() : base("Service providers", "Lists all the companies that either supply or ship products.", QueryTypes.Set) { }

        public override object Execute() {
            var listA = (from c in ObjectDatabase.Shippers select c.CompanyName).ToList();
            var listB = (from c in ObjectDatabase.Suppliers select c.CompanyName).ToList();
            return listA.Concat(listB);
        }
    }
}
