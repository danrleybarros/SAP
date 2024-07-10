using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Gcsb.Connect.SAP.Application.UseCases.File
{
    public class FileFactory
    {
        private readonly Dictionary<TypeRegister, IFileRequestHandler> _factories;
        private IFileReadOnlyRepository fileReadOnlyRepository;

        public FileFactory(IFileReadOnlyRepository FileReadOnlyRepository)
        {
            this.fileReadOnlyRepository = FileReadOnlyRepository;

            _factories = new Dictionary<TypeRegister, IFileRequestHandler>()
            {
                { TypeRegister.PAYMENT, new FileRequestHandler(fileReadOnlyRepository, GetTypeReprocessing(TypeRegister.PAYMENT)) },
                { TypeRegister.PAYMENTTSV, new FileRequestHandler(fileReadOnlyRepository, GetTypeReprocessing(TypeRegister.PAYMENTTSV)) },
                { TypeRegister.PAS, new FileRequestHandler(fileReadOnlyRepository, GetTypeReprocessing(TypeRegister.PAS)) },
                { TypeRegister.ARR, new FileRequestHandler(fileReadOnlyRepository, GetTypeReprocessing(TypeRegister.ARR)) },
                { TypeRegister.BILL, new FileRequestHandler(fileReadOnlyRepository, GetTypeReprocessing(TypeRegister.BILL)) },
                { TypeRegister.BILLCSV, new FileRequestHandler(fileReadOnlyRepository, GetTypeReprocessing(TypeRegister.BILLCSV)) },
                { TypeRegister.FAT, new FileRequestHandler(fileReadOnlyRepository, GetTypeReprocessing(TypeRegister.FAT)) }
            };            
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

        public List<FileResult> Execute(FileRequest request, string linkLog, string linkReprocess) 
            => _factories[request.InterfaceType].Execute(request, linkLog, linkReprocess);
    }
}
