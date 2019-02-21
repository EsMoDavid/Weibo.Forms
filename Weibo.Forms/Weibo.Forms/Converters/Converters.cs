using EsMo.Weibo.Core;
using MvvmCross.Converters;
using MvvmCross.Forms.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace EsMo.Weibo.UI.Converters
{
    public class ModelToUrlConverter : MvxFormsValueConverter<IList<ImageModel>, string>
    {
        protected override string Convert(IList<ImageModel> value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                throw new Exception("ImageModelConverter has no parameter");
            }
            int index = int.Parse(parameter.ToString());
            if (index >= value.Count)
            {
                return string.Empty;
            }
            return value[index].ThumbnailPic;
            //return "http://wx2.sinaimg.cn/thumbnail/8e7f1a15ly1fnstiejlbrg20dv05hnar.gif";
        }
    }
    public class ModelToVisibilityConverter : MvxFormsValueConverter<IList<ImageModel>, bool>
    {
        protected override bool Convert(IList<ImageModel> value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null)
            {
                throw new Exception("ImageModelConverter has no parameter");
            }
            int index = int.Parse(parameter.ToString());
            if (index >= value.Count)
            {
                return false;
            }
            return true;
        }
    }
}
