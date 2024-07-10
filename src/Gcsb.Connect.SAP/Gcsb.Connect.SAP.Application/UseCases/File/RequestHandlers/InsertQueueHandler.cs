using Gcsb.Connect.SAP.Application.Repositories;
using System;
using System.Reflection;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.Messaging.Messages.File;

namespace Gcsb.Connect.SAP.Application.UseCases.File.RequestHandlers
{
    public class InsertQueueHandler : IInsertQueueHandler
    {
        private readonly IFileReadOnlyRepository fileReadOnlyRepository;
        private readonly IFileReprocess<Connect.Messaging.Messages.File.BillFeedCsv> billFeedCsvReprocess;
        private readonly IFileReprocess<PaymentFeedTsv> paymentTsvReprocess;
        private readonly IFileReprocess<PaymentFeedFile> paymentReprocess;
        private readonly IFileReprocess<ARRFile> arrReprocess;
        private readonly IFileReprocess<BillFeedFile> billFeedReprocess;
        private readonly IFileReprocess<ReturnNFCsv> returnNFCsvReprocess;
        private readonly IFileReprocess<ClientFile> clientReprocess;
        private readonly IFileReprocess<ISIFile> isiReprocess;
        private readonly IFileReprocess<MasterFile> masterReprocess;
        private readonly IFileReprocess<ItemsFile> itemsReprocess;
        
        public InsertQueueHandler(
            IFileReadOnlyRepository FileReadOnlyRepository,
            IFileReprocess<BillFeedCsv> BillFeedCsvReprocess,
            IFileReprocess<PaymentFeedTsv> PaymentTsvReprocess,
            IFileReprocess<PaymentFeedFile> PaymentReprocess,
            IFileReprocess<ARRFile> ArrReprocess,
            IFileReprocess<BillFeedFile> BillFeedReprocess,
            IFileReprocess<ReturnNFCsv> ReturnNFCsvReprocess,
            IFileReprocess<ClientFile> ClientReprocess,
            IFileReprocess<ISIFile> ISIReprocess,
            IFileReprocess<MasterFile> MasterReprocess,
            IFileReprocess<ItemsFile> ItemsReprocess)
        {
            this.fileReadOnlyRepository = FileReadOnlyRepository;
            this.billFeedCsvReprocess = BillFeedCsvReprocess;
            this.paymentTsvReprocess = PaymentTsvReprocess;
            this.paymentReprocess = PaymentReprocess;
            this.arrReprocess = ArrReprocess;
            this.billFeedReprocess = BillFeedReprocess;
            this.returnNFCsvReprocess = ReturnNFCsvReprocess;
            this.clientReprocess = ClientReprocess;
            this.isiReprocess = ISIReprocess;
            this.masterReprocess = MasterReprocess;
            this.itemsReprocess = ItemsReprocess;
        }

        public void FileReprocess(Connect.Messaging.Messages.File.File file)
        {
            var reprocess = false;

            switch (GetTypeReprocessing(file.Type))
            {
                case TypeReprocessing.ALL: reprocess = true; break;
                case TypeReprocessing.None: reprocess = false; break;
                case TypeReprocessing.AnyError: reprocess = (file.Status.Equals(Status.Error)); break;
                case TypeReprocessing.AnyWaiting: reprocess = (file.Status.Equals(Status.Waiting)); break;
                case TypeReprocessing.AnySucess: reprocess = (file.Status.Equals(Status.Success)); break;
                case TypeReprocessing.WaitingAndError: reprocess = (file.Status.Equals(Status.Error) || file.Status.Equals(Status.Waiting)); break;
                default: reprocess = false; break;
            }

            if (reprocess)
                if (file.IdParent != null && file.IdParent.Value != Guid.Empty)
                     Publisher(file, fileReadOnlyRepository.GetById((Guid)file.IdParent));
                else
                    throw new Exception("Parent necessary for reprocessing");
        }

        private TypeReprocessing GetTypeReprocessing(TypeRegister value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            Attribute[] attributes =
                (Attribute[])fi.GetCustomAttributes(
                typeof(Attribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
            {
                return ((TypeRegisterAttribute)attributes[0]).TypeReprocessing;
            }
            else
                return TypeReprocessing.None;
        }

        private void Publisher(Connect.Messaging.Messages.File.File file, Connect.Messaging.Messages.File.File parent)
        {
            switch (file.Type)
            {
                case TypeRegister.BILL: billFeedCsvReprocess.Reprocess(new BillFeedCsv(parent.FileName)); break;
                case TypeRegister.PAYMENT: paymentTsvReprocess.Reprocess(new PaymentFeedTsv(parent.FileName, TypePaymentMethod.CreditCard)); break;
                case TypeRegister.PAYMENTBOLETO: paymentTsvReprocess.Reprocess(new PaymentFeedTsv(parent.FileName, TypePaymentMethod.Boleto)); break;
                case TypeRegister.ARR: paymentReprocess.Reprocess(new PaymentFeedFile(parent.Id, parent.FileName, TypePaymentMethod.CreditCard)); break;
                case TypeRegister.PAS: arrReprocess.Reprocess(new ARRFile(parent.Id, parent.FileName)); break;                
                case TypeRegister.FAT: billFeedReprocess.Reprocess(new BillFeedFile(parent.Id, TypeRegister.FAT, parent.FileName, TypeProcess.Reprocess, parent.CycleDate)); break;
                case TypeRegister.AJU: billFeedReprocess.Reprocess(new BillFeedFile(parent.Id, TypeRegister.AJU, parent.FileName, TypeProcess.Reprocess, parent.CycleDate)); break;                
                case TypeRegister.INDIVIDUALREPORT: billFeedReprocess.Reprocess(new BillFeedFile(parent.Id, TypeRegister.INDIVIDUALREPORT, parent.FileName, TypeProcess.Reprocess, parent.CycleDate)); break;                
                case TypeRegister.SPECIALREGIME: billFeedReprocess.Reprocess(new BillFeedFile(parent.Id, TypeRegister.SPECIALREGIME, parent.FileName, TypeProcess.Reprocess, parent.CycleDate)); break;
                case TypeRegister.RETURNNF: returnNFCsvReprocess.Reprocess(new ReturnNFCsv(parent.FileName)); break;
                case TypeRegister.CLIENT: clientReprocess.Reprocess(new ClientFile(parent.Id, parent.FileName)); break;
                case TypeRegister.ISI: isiReprocess.Reprocess(new ISIFile(parent.Id, parent.FileName)); break;
                case TypeRegister.MASTER: masterReprocess.Reprocess(new MasterFile(parent.Id, parent.FileName)); break;
                case TypeRegister.ITEMS: itemsReprocess.Reprocess(new ItemsFile(parent.Id, parent.FileName)); break;
            }
        }
    }
}