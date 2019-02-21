using EsMo.Weibo.Core.Network;
using EsMo.Weibo.Core.Service;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core.ViewModels
{
    public class LoginViewModel: MvxNavigationViewModel
    {
        #region ctor
        ILoginService loginService;
        IWebView webView;
        bool fillAccount;
        bool hasShowStartup;
        string defaultUserId = "showmercy123@sina.com";
        string defaultPwd = "showmercy1112";
        public LoginViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMvxViewModelLoader mvxViewModelLoader, ILoginService loginService, IAccountService accountService)
            :base(logProvider,navigationService)
        {
            this.loginService = loginService;
        }
       
        #endregion

        #region prop
        public IWebView WebView
        {
            get
            {
                return webView;
            }

            set
            {
                if (this.webView != null)
                    this.webView.LoadFinished -= WebView_LoadFinished;
                webView = value;
                if (this.webView != null)
                    this.webView.LoadFinished += WebView_LoadFinished;
            }
        }
        #endregion

        #region methods

        Task<string> GetLoginPage()
        {
            return this.loginService.GetAuthPage(null, null);
            //return this.loginService.GetAuthPage("showmercy123@sina.com", "showmercy1112");
        }
        public override void ViewAppeared()
        {
            base.ViewAppeared();
            this.WebView.LoadUrl(GlobalURI.Auth.ToSchemaHttps());
        }
        private void WebView_LoadFinished(object sender, EventArgs e)
        {
            string url = this.WebView.Uri == null ? string.Empty : this.WebView.Uri.ToString();
            if (!fillAccount)
            {
                if (!string.IsNullOrEmpty(this.defaultPwd) && !string.IsNullOrEmpty(this.defaultUserId))
                {
                    string fillAccount = string.Format(@"
                    document.getElementById('userId').value = '{0}';
                    document.getElementById('passwd').value = '{1}';", this.defaultUserId, this.defaultPwd);

                    this.WebView.EvalJavaScript(fillAccount);
                    this.fillAccount = true;
                }
            }
            if (url.StartsWith("https://api.weibo.com/oauth2/authorize"))
            {
                //authorize
            }
            else if (url.StartsWith(GlobalURI.XCallback) && !this.hasShowStartup)
            {
                this.hasShowStartup = true;
                this.NavigationService.Navigate<StartupViewModel,MvxBundle>(new MvxBundle(new Dictionary<string, string> { { StartupViewModel.LoginUrl, this.WebView.Uri.ToString() } }));
            }
        }
        #endregion
    }
}
