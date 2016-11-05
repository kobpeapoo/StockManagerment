using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InventoryManagerment.JobCardTracker.Controller
{
    public class ModTenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string dayCountFromRow = value as string;
            string modNumber = parameter as string;

            return Int32.Parse(dayCountFromRow) % Int32.Parse(modNumber) == 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
