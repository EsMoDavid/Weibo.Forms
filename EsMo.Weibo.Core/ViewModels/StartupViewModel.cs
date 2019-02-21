using EsMo.Weibo.Core.Network;
using EsMo.Weibo.Core.Resources;
using EsMo.Weibo.Core.Service;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EsMo.Weibo.Core.ViewModels
{
    public class StartupViewModel : MvxNavigationViewModel<MvxBundle>
    {
        IAccountService accountService;
        internal const string LoginUrl = "LoginUrl";
        string loginUrl;
        public StartupViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMvxViewModelLoader mvxViewModelLoader, IAccountService accountService)
            :base(logProvider,navigationService)
        {
            this.accountService = accountService;
        }

        bool isLoggingIn=false;

        public bool IsLoggingIn
        {
            get
            {
                return isLoggingIn;
            }

            private set
            {
                this.RaiseAndSetIfChanged(ref isLoggingIn, value, () => this.IsLoggingIn);
            }
        }
        string statusText;
        public string StatusText
        {
            get
            {
                return statusText;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref statusText, value, () => this.StatusText);
            }
        }
        string profileUrl;
        public string ProfileUrl
        {
            get
            {
                return profileUrl;
            }
            private set
            {
                this.RaiseAndSetIfChanged(ref profileUrl, value, () => this.ProfileUrl);
            }
        }
        public Stream UnknownProfile
        {
            get { return this.GetApplication().ResourceCache.Get(AssetsHelper.login_user_unknown.ToAssetsImage()); }
        }
        public ICommand StartupCommand
        {
            get { return new MvxAsyncCommand(Startup); }
        }
        
        async Task Startup()
        {
            this.IsLoggingIn = true;
            this.StatusText = AppResources.Loading + " " + AppResources.User;
            Account account = await this.accountService.LoginWithToken(loginUrl);
            Debug.WriteLine("Login account");
            await Task.Delay(1000);
            if (account != null)
            {
                this.GetApplication().Account = account;
                await this.accountService.InitialUserShow(account);
                Debug.WriteLine("Get AccountShow");
                
                this.StatusText = AppResources.Loading + " " + account.Show.ScreenName;
                this.ProfileUrl = account.Show.ProfileImageUrl;
                await Task.Delay(2000);
                await this.accountService.InitialAccountInfo(account);
                Debug.WriteLine("Initial Account");
                //this.ShowViewModel<MenuViewModel>();
                await this.NavigationService.Navigate<TimelineViewModel>();
            }
            this.IsLoggingIn = false;
        }

        public override void Prepare(MvxBundle parameter)
        {
            loginUrl = parameter.Data[LoginUrl];
            this.StartupCommand.Execute(null);
        }
    }
}
