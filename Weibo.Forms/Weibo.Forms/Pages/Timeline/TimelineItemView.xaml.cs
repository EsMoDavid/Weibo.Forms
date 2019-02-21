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
	public partial class TimelineItemView : Grid
	{
		public TimelineItemView ()
		{
			InitializeComponent ();
            //SfListView
		}
	}
}