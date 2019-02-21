using MvvmCross;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core.Service
{
    internal static class ServiceExtension
    {
        public static IApplicationService GetApplication(this IBaseService that)
        {
            //return Mvx.Resolve<IApplicationService>();
            return Mvx.IoCProvider.Resolve<IApplicationService>();
        }
    }
}
