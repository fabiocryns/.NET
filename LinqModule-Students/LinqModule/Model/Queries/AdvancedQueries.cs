using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class UnpopularProductsQuery : Query {
        public UnpopularProductsQuery() : base("Unpopular products", "Returns all the product IDs from products that haven't been ordered since April 1st 1998", QueryTypes.Advanced) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }

    public class BestSalesmenQuery : Query {
        public BestSalesmenQuery() : base("Worst salesmen", "Returns all the employees whose average order price is lower than the company average order price.", QueryTypes.Advanced) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }
}
