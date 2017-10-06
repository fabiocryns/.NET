using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.ServiceLocation {
    public interface IMainWindowViewModel : INotifyPropertyChanged {
        IEnumerable<IQueryViewModel> Queries { get; }
        object ResultsView { get; }
    }
}
