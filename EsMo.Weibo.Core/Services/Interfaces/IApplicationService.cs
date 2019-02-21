using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core.Service
{
    public interface IApplicationService:IBaseService
    {
        Account Account { get; set; }
        ResourceCache ResourceCache { get; }
    }
}
