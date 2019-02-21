using EsMo.Weibo.Core.ViewModels;
using MvvmCross.Forms.Views;
using Syncfusion.ListView.XForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EsMo.Weibo.UI.Pages.Timeline
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TimelinePage : MvxContentPage<TimelineViewModel>
    {
		public TimelinePage()
		{
			InitializeComponent ();
            //this.listView.Loaded += ListView_Loaded;
            
		}

        //private void ListView_Loaded(object sender, ListViewLoadedEventArgs e)
        //{
        //    //Device.BeginInvokeOnMainThread(async () =>
        //    //{
        //    //    await Task.Delay(100);
        //    //    listView.RefreshListViewItem();
        //    //});
        //}
    }
}