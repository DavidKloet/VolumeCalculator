﻿using Domain.UnitConverter;
using System;
using System.Globalization;
using System.Windows.Data;
using VolumeCalculator.ViewModel;

namespace VolumeCalculator.Helpers
{
    /// <inheritdoc />
    /// <summary>
    /// Converter for mapping radiobutton options for <see cref="Unit"/> to the corresponding property on <see cref="MainWindowViewModel"/>
    /// </summary>
    public class UnitOptionsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return false;

            var checkValue = value.ToString();
            var targetValue = parameter.ToString();

            return checkValue.Equals(targetValue, StringComparison.InvariantCultureIgnoreCase);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || parameter == null) return null;

            var useValue = (bool)value;
            var targetValue = parameter.ToString();

            if (useValue) return Enum.Parse(targetType, targetValue);

            return null;
        }
    }
}
