using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class FirstQuery : Query {
        public FirstQuery() : base("Oldest employee", "Returns the oldest employee.", QueryTypes.Element) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }

    public class SingleQuery : Query {
        public SingleQuery() : base("Top manager", "Returns the emplyee who doesn't report to anyone.", QueryTypes.Element) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }

    public class SingleOrDefaultQuery : Query {
        public SingleOrDefaultQuery() : base("Order 666", "Returns the order with ID 666 (if it exists).", QueryTypes.Element) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }
}
