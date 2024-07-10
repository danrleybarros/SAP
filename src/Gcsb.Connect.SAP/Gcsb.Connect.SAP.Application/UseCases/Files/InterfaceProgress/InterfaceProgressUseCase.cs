using System;
using System.Linq;
using System.Threading.Tasks;
using Gcsb.Connect.SAP.Application.Repositories.Upload;
using Gcsb.Connect.SAP.Domain.Upload.Enum;

namespace Gcsb.Connect.SAP.Application.UseCases.Files.InterfaceProgress
{
    public class InterfaceProgressUseCase : IInterfaceProgressUseCase
    {
        private readonly IInterfaceProgressRepository interfaceProgressRepository;

        public InterfaceProgressUseCase(IInterfaceProgressRepository interfaceProgressRepository)
        {
            this.interfaceProgressRepository = interfaceProgressRepository;
        }
        public async Task Progress(InterfaceProgressRequest request)
        {
            var progress = interfaceProgressRepository.GetByFilter(s => s.IdParent == request.IdParent).FirstOrDefault();
            if (progress != null)
            {
                progress.SetStatus(StatusType.Processing);
                interfaceProgressRepository.Update(progress);
            }
            interfaceProgressRepository.Add(new Domain.Upload.InterfaceProgress(Guid.NewGuid(), request.IdParent, request.UploadType, Domain.Upload.Enum.StatusType.Processing, DateTime.UtcNow));
        }
        public async Task Successfully(InterfaceProgressRequest request)
        {
            var progress = interfaceProgressRepository.GetByFilter(s => s.IdParent == request.IdParent).FirstOrDefault();
            if (progress != null && progress.StatusType != StatusType.Error)
            {
                progress.SetStatus(StatusType.Success);
                interfaceProgressRepository.Update(progress);
            }            
        }
        public async Task Error(InterfaceProgressRequest request)
        {
            var progress = interfaceProgressRepository.GetByFilter(s => s.IdParent == request.IdParent).FirstOrDefault();
            if (progress != null)
            {
                progress.SetStatus(StatusType.Error);
                interfaceProgressRepository.Update(progress);
            }            
        }
    }
}
