using EsMo.Weibo.Core.ViewModels;
using ITLec.XamarinForms.Tool.AdvancedProgressBar;
using MvvmCross.Forms.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsMo.Weibo.UI.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class StartupPage : MvxContentPage<StartupViewModel>
	{
		public StartupPage ()
		{
			InitializeComponent ();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.progressBar.IsRunning = true;
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.progressBar.IsRunning = false;
        }
    }
}