using System;
using System.Collections.Generic;
using System.Text;

namespace EsMo.Weibo.Core.ViewModels
{
    public interface IWebView
    {
        void LoadUrl(string url);
        void LoadHtmlString(string html, string schema);
        void EvalJavaScript(string js);
        event EventHandler LoadFinished;
        Uri Uri { get; }

    }
}
