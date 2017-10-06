using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class InnerJoinQuery : Query {
        public InnerJoinQuery() : base("Product list (with category names)", "Lists all the products in the database with their respective categories.", QueryTypes.Joins) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }

    public class LeftOuterJoinQuery : Query {
        public LeftOuterJoinQuery() : base("Employees (with managers)", "Lists the employees in the database (with the name of their manager).", QueryTypes.Joins) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }
}
