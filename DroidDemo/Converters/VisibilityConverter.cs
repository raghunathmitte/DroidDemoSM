using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Converters;
using System.Globalization;

namespace DroidDemo.Converters
{
    public class VisibilityConverter : MvxValueConverter<bool, string>
    {
        protected override string Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!value)
            {
                return "gone";
            }
            return "visible";
        }

        protected override bool ConvertBack(string value, Type targetType, object parameter, CultureInfo culture)
        {
            return ("visible".Equals(value)) ? true : false;
        }

    }
}