using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class DistinctQuery : Query {
        public DistinctQuery() : base("Active customers", "Lists all the customers that ordered something since the beginning of 1998.", QueryTypes.Set) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }

    public class UnionQuery : Query {
        public UnionQuery() : base("Service providers", "Lists all the companies that either supply or ship products.", QueryTypes.Set) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }
}
