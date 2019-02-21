using EsMo.Weibo.Core.Service;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
namespace EsMo.Weibo.Core.ViewModels
{
    [MvxMasterDetailPagePresentation(MasterDetailPosition.Master)]
    public class TimelineViewModel : MvxNavigationViewModel
    {
        IAccountService accountService;
        ObservableCollection<TimelineItemViewModel> timelineItems;

        public TimelineViewModel(IMvxLogProvider logProvider, IMvxNavigationService navigationService, IMvxViewModelLoader mvxViewModelLoader, IAccountService accountService)
           : base(logProvider, navigationService)
        {
            this.accountService = accountService;
        }
        public ObservableCollection<TimelineItemViewModel> TimelineItems
        {
            get
            {
                if (this.timelineItems == null)
                {
                    this.timelineItems = new ObservableCollection<TimelineItemViewModel>();
                    var statuses = this.GetApplication().Account.Statuses;
                    this.SyncTimelineItems(statuses);
                }
                return this.timelineItems;
            }
        }
        List<Status> Statuses
        {
            get
            {
                return this.GetApplication().Account.Statuses;
            }
        }
        void SyncTimelineItems(List<Status> statuses)
        {
            foreach (var status in statuses)
            {
                this.TimelineItems.Add(new TimelineItemViewModel(status));
            }
        }
        public async Task<int> RequestNextPage()
        {
            if (this.Statuses != null)
            {
                if (this.Statuses.Count > 0)
                {
                    var status = Statuses;
                    long firstID = status[0].ID;
                    long nextID = status.Last().ID - 1;
                    List<Status> nextPage = await this.accountService.GetNextPageTimeline(firstID, nextID);
                    foreach (var item in nextPage)
                    {
                        status.Add(item);
                    }
                    this.SyncTimelineItems(nextPage);
                    return nextPage.Count;
                }
            }
            return 0;
        }
    }
}
