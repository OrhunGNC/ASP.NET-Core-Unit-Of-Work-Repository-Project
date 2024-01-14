using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uowProject.Data.Repository.IRepository
{
    public interface IUnitOfWork:IDisposable
    {
        IPublisherRepository Publisher { get; }
        IGameRepository Game { get; }
        IDeveloperRepository Developer { get; }
        IPlatformRepository Platform { get; }
        void Save();
    }
}
