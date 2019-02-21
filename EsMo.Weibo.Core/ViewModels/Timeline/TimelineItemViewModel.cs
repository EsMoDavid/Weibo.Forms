using EsMo.Weibo.Core.Network;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;
using System.Linq;
namespace EsMo.Weibo.Core.ViewModels
{
    public class TimelineItemViewModel : MvxViewModel
    {
        public static readonly Color @RetweetColor = new Color(5, 124, 255);
        public MvxCommand<int> ImageSelected { get; private set; }
        internal const string SelectedIndex = "SelectedIndex";
        internal const string ImageArray = "ImageArray";

        public Status Model { get; private set; }
        public TimelineItemViewModel(Status model)
        {
            this.Model = model;
            this.ImageSelected = new MvxCommand<int>(index =>
            {
                MvxBundle bundle = new MvxBundle();
                bundle.Data.Add(ImageArray, this.Model.PicURLs.Select(x => x.ThumbnailPic).ToJson());
                bundle.Data.Add(TimelineItemViewModel.SelectedIndex, index.ToString());
                //this.ShowViewModel<ImageBrowserViewModel>(bundle);
            });
        }

        Status RetweetedStatus { get { return this.Model.RetweetedStatus; } }
        public bool HasRetweetedStatus
        {
            get
            {
                return RetweetedStatus != null;
            }
        }
        public string RetweetContent
        {
            get
            {
                if (this.RetweedtedText == null) return string.Empty;
                return RetweetedHeader + this.RetweedtedText;
            }
        }
        public string RetweetedHeader
        {
            get
            {
                return string.IsNullOrEmpty(RetweetedUserName)
                    ? string.Empty
                    : string.Format("@{0}", this.RetweetedUserName);
            }
        }

        public string Description
        {
            get
            {
                return this.Model.User.CreatedAt.DateConvertToString();
            }
        }
        public string Name
        {
            get
            {
                return this.Model.User.ActualGeneralName;
            }
        }
        public string ProfileUrl
        {
            get
            {
                return this.Model.User.ActualProfileUrl;
            }
        }
        public long ID
        {
            get { return this.Model.ID; }
        }
        public string Text
        {
            get { return this.Model.Text; }
        }
        public int RepostCount
        {
            get { return this.Model.RepostsCount; }
        }
        public int LikeCount
        {
            get { return 0; }
        }
        public int CommentCount
        {
            get { return this.Model.CommentsCount; }
        }
        public ImageSource ImageLike
        {
            get { return ImageSource.FromStream( ()=>this.GetApplication().ResourceCache.Get(AssetsHelper.timeline_icon_like.ToAssetsImage(), false)); }
        }
        public ImageSource ImageComment
        {
            get { return ImageSource.FromStream(() => this.GetApplication().ResourceCache.Get(AssetsHelper.timeline_icon_comment.ToAssetsImage(),false)); }
        }
        public ImageSource ImageRepost
        {
            get { return ImageSource.FromStream(() => this.GetApplication().ResourceCache.Get(AssetsHelper.timeline_icon_redirect.ToAssetsImage(),false)); }
        }

        public ImageSource ImageVerified
        {
            get
            {
                Stream stream = null;
                // yellow vip
                if (this.Model.User.VerifiedType == 0)
                {
                    stream= this.GetApplication().ResourceCache.Get(AssetsHelper.avatar_vip.ToAssetsImage(),false);
                }
                // junior 200, senior 220
                else if (this.Model.User.VerifiedType == 200 || this.Model.User.VerifiedType == 220)
                {
                    stream= this.GetApplication().ResourceCache.Get(AssetsHelper.avatar_grassroot.ToAssetsImage(), false);
                }
                // blue vip
                else if (this.Model.User.VerifiedType > 0)
                {
                    stream= this.GetApplication().ResourceCache.Get(AssetsHelper.avatar_enterprise_vip.ToAssetsImage(), false);
                }
                if (stream != null)
                {
                    return ImageSource.FromStream(()=>stream);
                }
                return null;
            }
        }
        public Stream ImageLoading
        {
            get
            {
                return this.GetApplication().ResourceCache.Get(AssetsHelper.timeline_loading.ToAssetsImage());
            }
        }
        public List<ImageModel> ImageModels
        {
            get
            {
                return this.Model.PicURLs.ToList();
            }
        }

        public int Padding { get; set; } = 1;
        int ColumnCount { get; set; } = 3;
        int ImageModelRowsCount
        {
            get
            {
                int itemCount = ImageModels.Count;
                return itemCount % ColumnCount == 0 ? itemCount / ColumnCount : itemCount / ColumnCount + 1;
            }
        }
        string RetweetedUserName
        {
            get
            {
                if (this.HasRetweetedStatus && this.RetweetedStatus.User != null)
                    return this.RetweetedStatus.User.ScreenName;
                return string.Empty;
            }
        }
        string RetweedtedText
        {
            get
            {
                return this.HasRetweetedStatus ? this.RetweetedStatus.Text : string.Empty;
            }
        }
        public double GetImageModelsHeight(double containerWidth, out double itemSize)
        {
            int rowsCount = this.ImageModelRowsCount;
            itemSize = (containerWidth - Padding * (this.ColumnCount - 1)) / this.ColumnCount;
            return itemSize * rowsCount + Padding * (rowsCount - 1);
        }
    }
}
