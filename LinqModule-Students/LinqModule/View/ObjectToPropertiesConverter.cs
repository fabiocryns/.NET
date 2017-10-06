using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LinqModule.View {
    public class ObjectToPropertiesConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return null;
            }
            return from p in value.GetType().GetProperties()
                   let v = p.GetValue(value)
                   select new { Name = p.Name, Value = ObjectToString(v), DataType = TypeToStringConverter.TypeToTypeString(p.PropertyType) };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }

        public static string ObjectToString(object o) {
            if (o == null) {
                return "null";
            } else if (o is IEnumerable) {
                if (o is IEnumerable<byte>) {
                    return "0x" + string.Concat((o as IEnumerable<byte>).Select(b => b.ToString("X2")).ToArray());
                } else {
                    var et = o.GetType().GetElementType();
                    if (et == null) {
                        return o.ToString();
                    } else {
                        return string.Format("IEnumerable of type '{0}'", o.GetType().GetElementType().Name);
                    }
                }
            } else {
                return o.ToString();
            }
        }
    }
}
