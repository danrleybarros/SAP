using Gcsb.Connect.SAP.Domain.Upload;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Gcsb.Connect.SAP.Application.Repositories.Upload
{
    public interface IInterfaceProgressRepository
    {
        int Add(InterfaceProgress interfaceProgress);
        int Add(List<InterfaceProgress> interfacesProgress);
        int Update(InterfaceProgress interfaceProgress);        
        List<InterfaceProgress> GetByFilter(Expression<Func<InterfaceProgress, bool>> expression);
        List<InterfaceProgress> GetAll();
        int Delete(InterfaceProgress interfaceProgress);
    }
}
