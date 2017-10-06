using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using LinqModule.Model;
using LinqModule.ServiceLocation;

namespace LinqModule.ViewModel {
    public class QueryViewModel : IQueryViewModel {
        public QueryViewModel() {
            this.Execute = new ExecuteCommand(this);
        }

        public void Initialize(Query query) {
            _query = query;
        }

        public string Name {
            get {
                return _query.Name;
            }
        }
        public string Description {
            get {
                return _query.Description;
            }
        }
        public QueryTypes QueryType {
            get {
                return _query.QueryType;
            }
        }

        public ICommand Execute {
            get; private set;
        }

        public event Action<Query, object> Executed;

        private Query _query;

        private class ExecuteCommand : ICommand {
            public ExecuteCommand(QueryViewModel vm) {
                _vm = vm;
            }

            public bool CanExecute(object parameter) {
                return true;
            }

            public void Execute(object parameter) {
                object ret;
                try {
                    ret = _vm._query.Execute();
                } catch (Exception e) {
                    ret = e;
                }
                _vm.Executed?.Invoke(_vm._query, ret);
            }

            private QueryViewModel _vm;
            public event EventHandler CanExecuteChanged;
        }
    }
}
