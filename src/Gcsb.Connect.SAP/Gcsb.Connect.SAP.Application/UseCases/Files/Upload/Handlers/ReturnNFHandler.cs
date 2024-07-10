using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.SAP.Application.GenericClass.UseCases.Handlers;
using Gcsb.Connect.SAP.Application.Repositories.DocFeed.BillFeed;
using Gcsb.Connect.SAP.Application.Repositories.GF;
using Gcsb.Connect.SAP.Domain.GF.Nfe;
using Newtonsoft.Json;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.Upload.Handlers
{
    public class ReturnNFHandler : Handler<UploadUseCaseRequest>
    {
        private readonly IInvoiceReadOnlyRepository InvoiceRepository;
        private readonly IReturnNFConvertRepository ReturnNFConvert;

        public ReturnNFHandler(IInvoiceReadOnlyRepository invoiceRepository,
            IReturnNFConvertRepository returnNFConvert)
        {
            InvoiceRepository = invoiceRepository;
            ReturnNFConvert = returnNFConvert;
        }

        public override void ProcessRequest(UploadUseCaseRequest request)
        {
            request.AddProcessingLog("ReturnNFHandler");

            if(request.UploadType == Domain.Upload.Enum.UploadTypeEnum.ReturnNF)
            {
                List<ReturnNF> returnNFs = ReturnNFConvert.FromCsv(request.Base64, Guid.NewGuid(), "storeAcronym").ToList();
                
                string firstInvoiceId = returnNFs.ElementAt(0).InvoiceID;
                
                string storeAcronym = InvoiceRepository.GetInvoice(firstInvoiceId)?.StoreAcronym;
                
                var files = new List<NfeFiles>
                        {
                            new NfeFiles(request.FileName, storeAcronym, GetDate(request.FileName, 14))
                        };

                request.NfeFilesJSON = JsonConvert.SerializeObject(files);
            }

            sucessor?.ProcessRequest(request);
        }

        private string GetDate(string fileName, int positions)
            => new Regex("[0-9]{" + positions + "}").Match(fileName).Value;
    }
}
