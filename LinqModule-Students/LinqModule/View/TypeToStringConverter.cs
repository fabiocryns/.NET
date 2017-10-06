using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LinqModule.View {
    public class TypeToStringConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return ObjectToTypeString(value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public static string ObjectToTypeString(object value) {
            if (value == null) {
                return "null";
            } else {
                return TypeToTypeString(value.GetType());
            }
        }
        public static string TypeToTypeString(Type t) {
            if (typeof(ValueType).IsAssignableFrom(t) && t.GenericTypeArguments != null && t.GenericTypeArguments.Length == 1) {
                return string.Format("Nullable<{0}>", TypeToTypeString(Nullable.GetUnderlyingType(t)));
            } else if(!typeof(string).IsAssignableFrom(t) && typeof(IEnumerable).IsAssignableFrom(t)) {
                /*if (t.GenericTypeArguments != null && t.GenericTypeArguments.Length >= 1) {
                    return string.Format("IEnumerable<{0}>", TypeToTypeString(t.GenericTypeArguments[t.GenericTypeArguments.Length - 1]));
                } else {
                    return t.Name;
                }*/
                return "IEnumerable";
            } else {
                return t.Name;
            }
        }
    }
}
