using EsMo.Weibo.Core.Service;
using MvvmCross;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core
{
    internal static class ViewModelExtension
    {
        public static IApplicationService GetApplication(this MvxNotifyPropertyChanged that)
        {
            return Mvx.IoCProvider.Resolve<IApplicationService>();
        }
    }
}
