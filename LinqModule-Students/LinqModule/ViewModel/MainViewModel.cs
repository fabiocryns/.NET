using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using LinqModule.Model;
using LinqModule.ServiceLocation;

namespace LinqModule.ViewModel {
    public class MainViewModel : IMainWindowViewModel, INotifyPropertyChanged {
        public MainViewModel() {
            this.Queries = Query.FindAll().Select(q => {
                var ret = ServiceLocator.Resolve<IQueryViewModel>();
                ret.Initialize(q);
                ret.Executed += Query_Executed;
                return ret;
            });
            this.ResultsView = ServiceLocator.Resolve<IView>(ViewNames.NoResultsView);
            this.Status = "Ready!";
        }

        private void Query_Executed(Query query, object result) {
            IView view;
            if (result is Exception) {
                view = ServiceLocator.Resolve<IView>(ViewNames.ExceptionResultView);
                Status = "An exception has occurred while executing the query.";
            } else if (result is string || result is ValueType) {
                view = ServiceLocator.Resolve<IView>(ViewNames.SingleValueResultView);
                Status = "A single object has been returned by the query.";
            } else if (result is IEnumerable) {
                view = ServiceLocator.Resolve<IView>(ViewNames.EnumerableResultsView);
                Status = string.Format("A list with {0} items has been returned by the query.", (result as IEnumerable).Cast<object>().Count());
            } else /* ordinary object */ {
                view = ServiceLocator.Resolve<IView>(ViewNames.SingleResultView);
                if (result == null) {
                    Status = "No object has been returned by the query.";
                } else {
                    Status = "A single object has been returned by the query.";
                }
            }
            view.DataContext = new ResultViewModel(query.Name, query.Description, result);
            ResultsView = view;
        }

        public IEnumerable<IQueryViewModel> Queries {
            get; private set;
        }

        public object ResultsView {
            get {
                return _results;
            }
            private set {
                _results = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ResultsView)));
            }
        }
        private object _results;

        public string Status {
            get {
                return _status;
            }
            private set {
                _status = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Status)));
            }
        }
        private string _status;

        public event PropertyChangedEventHandler PropertyChanged;
    }    
}
