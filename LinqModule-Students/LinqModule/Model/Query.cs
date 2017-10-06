using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.Model {
    public abstract class Query {
        public Query(string name, string description, QueryTypes qtype) {
            this.QueryType = qtype;
            this.Name = name;
            this.Description = description;
        }
        public QueryTypes QueryType { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public abstract object Execute();

        public static IEnumerable<Query> FindAll() {
            var queries = new List<Query>();
            var ass = Assembly.GetExecutingAssembly();
            var qt = typeof(Query);
            foreach (var t in ass.DefinedTypes) {
                if (t.BaseType == qt) {
                    queries.Add(Activator.CreateInstance(t.AsType()) as Query);
                }
            }
            return queries;
        }
    }
}
