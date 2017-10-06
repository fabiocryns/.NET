using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using LinqModule.Model;
using LinqModule.ServiceLocation;

namespace LinqModule.View {
    public class QueryFilterConverter : IMultiValueConverter {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            var queries = values[0] as IEnumerable<IQueryViewModel>;
            if (queries == null) { 
                return null;
            }
            var queryType = (QueryTypes)values[1];
            return queries.Where(q => q.QueryType == queryType);
        }
        
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }        
    }
}
