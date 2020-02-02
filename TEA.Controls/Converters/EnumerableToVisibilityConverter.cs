using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace TEA.Controls.Converters
{
  public class EnumerableToVisibilityConverter : IValueConverter
  {
    public Visibility ValueIfEmpty { get; set; }
    public Visibility ValueIfAny { get; set; }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (!(value is IEnumerable<object> enumerable))
      {
        throw new ArgumentException(nameof(value));
      }

      return enumerable.Any() ? ValueIfAny : ValueIfEmpty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}