using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqModule.ServiceLocation {
    public interface IWindow : IView {
        bool? ShowDialog();
        void Show();
    }
}
