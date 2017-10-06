using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class TakeQuery : Query {
        public TakeQuery() : base("Take five orders", "Takes the first 5 orders from the database.", QueryTypes.Partitioning) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }

    public class SkipQuery : Query {
        public SkipQuery() : base("Skip three employees", "Lists the employees in the database, but skips the first 3.", QueryTypes.Partitioning) { }

        public override object Execute() {
            throw new NotSupportedException();
        }
    }
    
}
