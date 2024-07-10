using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using System.Linq;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.Master.RequestHandlers
{
    public class GetFileNameHandler : Handler<MasterRequest>, IGetFileNameHandler
    {
        public override void ProcessRequest(MasterRequest request)
        {
            request.FileName = Util.GetFileName("GW_MESTRE_01_", request.Invoices.SelectMany(s => s.Services).ToList(), "txt");
            request.TypeInterface = TypeRegister.MASTER;

            sucessor?.ProcessRequest(request);
        }
    }
}