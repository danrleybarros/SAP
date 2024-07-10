using System.Linq;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.Log;
using Gcsb.Connect.SAP.Application.UseCases.FAT;
using Gcsb.Connect.SAP.Domain.Deferral;

namespace Gcsb.Connect.SAP.Application.UseCases.GF.ReturnNF.ReturnNFHandlers
{
    public class GenerateFATsHandler : Handler
    {
        private readonly IFATUseCase<Domain.FAT.FATFaturado.FATFaturado> fatUseCase;
        private readonly IFATUseCase<Domain.FAT.FATaFaturarACM.FATaFaturarACM> fatAFaturarACMUseCase;
        private readonly IFATUseCase<Domain.FAT.FATaFaturarECM.FATaFaturarECM> fatAFaturarECMUseCase;

        public GenerateFATsHandler(IFATUseCase<Domain.FAT.FATFaturado.FATFaturado> fatUseCase,
            IFATUseCase<Domain.FAT.FATaFaturarACM.FATaFaturarACM> fatAFaturarACMUseCase,
            IFATUseCase<Domain.FAT.FATaFaturarECM.FATaFaturarECM> fatAFaturarECMUseCase)
        {
            this.fatUseCase = fatUseCase;
            this.fatAFaturarACMUseCase = fatAFaturarACMUseCase;
            this.fatAFaturarECMUseCase = fatAFaturarECMUseCase;
        }

        public override void ProcessRequest(ReturnNFRequest request)
        {
            request.Logs.Add(Log.CreateProcessingLog(request.Service, "Executing FATs interfaces"));
            var FATs = new[] { TypeRegister.FAT, TypeRegister.FATAFATURARACM, TypeRegister.FATAFATURARECM };

            FATs.ToList()
                .ForEach(type =>
                {
                    var deferralOffer = request.DeferralOffers.Select(s => s.Clone() as DeferralOffer).ToList();
                    var fATRequest = new FATRequest(type, request.BillfeedId, request.BillfeedCycleDate.Value) { DeferralOffers = deferralOffer };

                    switch (type)
                    {
                        case TypeRegister.FAT:
                            fatUseCase.Execute(fATRequest);
                            break;
                        case TypeRegister.FATAFATURARACM:
                            fatAFaturarACMUseCase.Execute(fATRequest);
                            break;
                        case TypeRegister.FATAFATURARECM:
                            fatAFaturarECMUseCase.Execute(fATRequest);
                            break;
                        default:
                            break;
                    }
                });

            sucessor?.ProcessRequest(request);
        }

    }
}
