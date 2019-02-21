using Android.App;
using Android.Content.PM;
using Android.OS;
using EsMo.Weibo.Core;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Platforms.Android.Views;
using System.Threading.Tasks;

namespace EsMo.Weibo.Droid
{
    [Activity(
        Label = "EsMo.Weibo.Droid"
        , MainLauncher = true
        , Icon = "@mipmap/icon"
        , Theme = "@style/AppTheme.Splash"
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxFormsSplashScreenActivity<Setup, Core.App, UI.App>
    {
        public SplashScreen()
             : base(Resource.Layout.SplashScreen)
        {
        }
        protected override Task RunAppStartAsync(Bundle bundle)
        {
            StartActivity(typeof(HomeView));
            return Task.CompletedTask;
        }
    }
}