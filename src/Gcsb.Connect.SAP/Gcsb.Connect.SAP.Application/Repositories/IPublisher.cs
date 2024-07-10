using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Gcsb.Connect.SAP.Application.Repositories
{
    public interface IPublisher<T>
    {
        Task PublishAsync(T objectFile);
    }
}