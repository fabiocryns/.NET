using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.ViewModel {
    public class ResultViewModel {
        public ResultViewModel(string name, string description, object result) {
            this.Name = name;
            this.Description = description;
            this.Result = result;
        }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public object Result { get; set; }
    }
}
