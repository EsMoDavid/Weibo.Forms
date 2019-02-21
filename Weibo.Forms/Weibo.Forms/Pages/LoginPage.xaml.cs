using EsMo.Weibo.Core.ViewModels;
using EsMo.Weibo.UI.Controls;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsMo.Weibo.UI
{
    [MvxContentPagePresentation(WrapInNavigationPage = true)]

    //[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : MvxContentPage<LoginViewModel>
    {
		public LoginPage ()
		{
			InitializeComponent ();
            
		}
        protected override void OnViewModelSet()
        {
            base.OnViewModelSet();
            this.ViewModel.WebView = this.WebView;
        }
    }
}