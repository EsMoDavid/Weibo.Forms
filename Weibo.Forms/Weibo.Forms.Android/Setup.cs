using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Logging;
using Serilog;

namespace EsMo.Weibo.Droid
{
    public class Setup : MvxFormsAndroidSetup<Core.App, UI.App>
    {
        public override MvxLogProviderType GetDefaultLogProviderType()
            => MvxLogProviderType.Serilog;
        public Setup()
        {

        }
        protected override IMvxLogProvider CreateLogProvider()
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.AndroidLog()
                .CreateLogger();

            return base.CreateLogProvider();
        }
    }
}