using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LinqModule.Model;

namespace LinqModule.ServiceLocation {
    public interface IQueryViewModel {
        void Initialize(Query query);
        string Name { get; }
        string Description { get; }
        QueryTypes QueryType { get; }
        ICommand Execute { get; }
        event Action<Query, object> Executed;
    }
}