using EsMo.Weibo.Core.ViewModels;
using System;
using Xam.Plugin.WebView.Abstractions;
using Xamarin.Forms;

namespace EsMo.Weibo.UI.Controls
{
    public class WebViewImpl : FormsWebView, IWebView
    {
        public event EventHandler LoadFinished;
        private string url;
        public WebViewImpl()
        {
            this.OnContentLoaded += WebViewImpl_OnContentLoaded;
            this.OnNavigationCompleted += WebViewImpl_OnNavigationCompleted;
        }

        private void WebViewImpl_OnNavigationCompleted(object sender, string e)
        {
            this.url = e;
        }

        private void WebViewImpl_OnContentLoaded(object sender, EventArgs e)
        {
            this.LoadFinished?.Invoke(this, EventArgs.Empty);
        }

        public Uri Uri
        {
            get
            {
                string url = string.IsNullOrEmpty(this.url) ? this.BaseUrl : this.url;
                return url == null ? null : new Uri(url);
            }
        }


        public void EvalJavaScript(string js)
        {
            Device.BeginInvokeOnMainThread( async() => await this.InjectJavascriptAsync(js));
        }

        public void LoadHtmlString(string html, string schema)
        {
            this.ContentType = Xam.Plugin.WebView.Abstractions.Enumerations.WebViewContentType.StringData;
            this.BaseUrl = schema;
            this.Source = html;
        }

        public void LoadUrl(string url)
        {
            this.ContentType = Xam.Plugin.WebView.Abstractions.Enumerations.WebViewContentType.Internet;
            this.Source = url;
        }
    }
}
