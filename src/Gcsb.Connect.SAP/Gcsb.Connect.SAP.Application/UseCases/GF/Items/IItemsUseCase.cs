using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Items
{
    public interface IItemsUseCase
    {
        void Execute(ItemsRequest request);
    }
}
