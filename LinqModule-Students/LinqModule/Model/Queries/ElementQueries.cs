using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class FirstQuery : Query {
        public FirstQuery() : base("Oldest employee", "Returns the oldest employee.", QueryTypes.Element) { }

        public override object Execute() {
            return (from e in ObjectDatabase.Employees orderby e.BirthDate ascending select e).First();
        }
    }

    public class SingleQuery : Query {
        public SingleQuery() : base("Top manager", "Returns the emplyee who doesn't report to anyone.", QueryTypes.Element) { }

        public override object Execute() {
            return ObjectDatabase.Employees.Where(e => e.ReportsTo == null).First();
        }
    }

    public class SingleOrDefaultQuery : Query {
        public SingleOrDefaultQuery() : base("Order 666", "Returns the order with ID 666 (if it exists).", QueryTypes.Element) { }

        public override object Execute() {
            return ObjectDatabase.Orders.Where(e => e.OrderID == 666).FirstOrDefault();
        }
    }
}
