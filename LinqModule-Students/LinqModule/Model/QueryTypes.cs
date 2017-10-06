using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model {
    public enum QueryTypes {
        [Description("Unfiltered database contents")]
        NoLinq,
        [Description("Basic queries")]
        Basic,
        [Description("Aggregate functions")]
        AggregateFunctions,
        [Description("Joins")]
        Joins,
        [Description("Quantifier operators")]
        Quantifiers,
        [Description("Partitioning operators")]
        Partitioning,
        [Description("Element operators")]
        Element,
        [Description("Set operators")]
        Set,
        [Description("Advanced queries")]
        Advanced
    }
}
