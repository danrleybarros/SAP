using Gcsb.Connect.SAP.Application.Repositories;

using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Application.UseCases.File.RequestHandlers
{
    public class FileReprocess<T> : IFileReprocess<T>
    {
        private readonly IPublisher<T> publisher;
        public FileReprocess(IPublisher<T> Publisher)
        {
            this.publisher = Publisher;
        }

        public void Reprocess(T file)
        {
            publisher.PublishAsync(file);
        }
    }
}
