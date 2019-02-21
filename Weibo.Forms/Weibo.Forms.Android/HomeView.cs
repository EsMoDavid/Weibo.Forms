using Android.App;
using Android.Content.PM;
using Android.OS;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Forms.Platforms.Android.Views;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;

namespace EsMo.Weibo.Droid
{
    [MvxActivityPresentation]
    [Activity(Label = "View for HomeViewModel",
        Icon = "@mipmap/icon",
        Theme = "@style/AppTheme",
        // MainLauncher = true, // No Splash Screen: Uncomment this lines if removing splash screen
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        LaunchMode = LaunchMode.SingleTask)]
    public class HomeView : MvxFormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            //SetContentView(Resource.Layout.HomeView);
        }
    }
}