using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LinqModule.View {
    public class EnumerableValueConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null)
                return null;
            var t = value.GetType();
            if (typeof(IEnumerable<string>).IsAssignableFrom(t)) {
                return (value as IEnumerable<string>).Select(v => new { Value = v });
            } else if (typeof(IEnumerable<object>).IsAssignableFrom(t)) {
                return value;
            } else { // IEnumerable of ValueTypes
                return ((value as IEnumerable).Cast<object>()).Select(v => new { Value = v });
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
