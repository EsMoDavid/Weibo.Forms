using EsMo.Weibo.Core.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core.Service
{
    public interface IHttpNetworkService
    {
        Task<T> Get<T>(IHttpParams p);
        Task<Stream> Get(IHttpParams p);
    }
}
