using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core.Service
{
    public interface ILoginService : IBaseService
    {
        Task<string> GetAuthPage(string accountName, string pwd);
    }
}
