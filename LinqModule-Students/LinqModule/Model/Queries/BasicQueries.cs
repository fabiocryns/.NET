using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model.Queries {
    public class WhereQuery : Query {
        public WhereQuery() : base("German suppliers", "Lists all the German suppliers.", QueryTypes.Basic) { }

        public override object Execute() {
            /*
                LINQ extension syntax:
                    return ObjectDatabase.Suppliers.Where(...);

                LINQ query syntax:
                    return from s in ObjectDatabase.Suppliers where ... select s;
            */

            return from s in ObjectDatabase.Suppliers where s.Country == "Germany" select s;
        }
    }

    public class SelectQuery : Query {
        public SelectQuery() : base("Employees (formatted)", "Lists select information of all the employees.", QueryTypes.Basic) { }

        public override object Execute() {
            return from e in ObjectDatabase.Employees select new { Name = string.Concat(e.TitleOfCourtesy + " ", e.LastName + " ", e.FirstName + " "), e.BirthDate };
        }
    }

    public class OrderByQuery : Query {
        public OrderByQuery() : base("Employees (ordered)", "Lists all the employees, ordered by hire date.", QueryTypes.Basic) { }

        public override object Execute() {
            return from e in ObjectDatabase.Employees orderby e.HireDate ascending select e;
        }
    }
}
