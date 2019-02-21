using EsMo.Weibo.Core.ViewModels;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core
{
    public class App : MvxApplication
    {
        public const string ClientID = "2362431378";

        public override void Initialize()
        {
            this.CreatableTypes()
           .EndingWith("Service")
           .AsInterfaces()
           .RegisterAsLazySingleton();
            RegisterAppStart<LoginViewModel>();
        }
    }
}
