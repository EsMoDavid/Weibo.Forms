using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EsMo.Weibo.Core.Service
{
    public interface IAccountService : IBaseService
    {
        Task<Account> LoginWithToken(string url);
        Task InitialAccountInfo(Account account);
        Task InitialUserShow(Account account);

        Task<List<Status>> GetNextPageTimeline(long firstID, long nextID);
        Task<List<Comment>> GetComments(Status status);

    }
}
