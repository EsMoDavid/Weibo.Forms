using EsMo.Weibo.Core.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core.Service
{
    public interface ISinaNetworkService:IHttpNetworkService,IBaseService
    {
        IHttpParams CreateHttpParams(string url, HttpMethod method, bool auth = true);
          Task<T> InvokeAction<T>(string actionKey, params object[] p);

    }
}
