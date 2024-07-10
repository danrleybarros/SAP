using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Gcsb.Connect.Messaging.Messages.File;
using Gcsb.Connect.Messaging.Messages.File.Enum;
using Gcsb.Connect.SAP.Application.Repositories;
using Gcsb.Connect.SAP.Application.UseCases.File;

namespace Gcsb.Connect.SAP.Infrastructure.PostgresDataAccess.Repositories
{
    public class FileRepository : IFileReadOnlyRepository, IFileWriteOnlyRepository
    {
        private readonly IMapper mapper;

        public FileRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public int Add(File file)
        {
            var model = mapper.Map<Entities.File>(file);
            var retorno = 0;

            using (var context = new Context())
            {
                context.File.Add(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int AddRange(IEnumerable<File> file)
        {
            var model = mapper.Map<IEnumerable<Entities.File>>(file);
            var retorno = 0;

            using (var context = new Context())
            {
                context.File.AddRange(model);
                retorno = context.SaveChanges();
            }

            return retorno;
        }

        public int GetSequentialFile(TypeRegister type)
        {
            using (var context = new Context())
            {
                var query = context.File.Where(w => w.Type.Equals(type)).ToList();
                var group = query.GroupBy(s => DateTimeToString(s.InclusionDate));
                var result = group.Count() + 1;

                return result;
            }
        }

        public string DateTimeToString(DateTime dateTime)
        {
            var result = dateTime.ToString("s");
            return result;
        }

        public int GetSequentialFileByType(TypeRegister type)
        {
            using (var context = new Context())
            {
                return context.File.Count(w => w.Type.Equals(type)) + 1;
            }
        }

        public int GetSequentialFileByCycle(TypeRegister type)
        {
            using (var context = new Context())
            {
                var query = context.File.Where(w => w.Type.Equals(type));
                var group = query.GroupBy(g => g.CycleDate);
                var result = group.Count() + 1;
                return result;
            }
        }

        public File GetById(Guid id)
        {
            using (var context = new Context())
            {
                return mapper.Map<File>(context.File.Where(f => f.Id == id).Select(s => s).FirstOrDefault());
            }
        }

        public bool ProcessedFile(string fileName, Status success)
        {
            var processedFile = false;

            using (var context = new Context())
            {
                processedFile = mapper.Map<List<File>>(context.File.Where(s => s.FileName == fileName && s.Status == success)).Any();
            }

            return processedFile;
        }

        public File GetFile(string fileName, Status success)
        {
            File file;

            using (var context = new Context())
            {
                file = mapper.Map<File>(context.File.Where(s => s.FileName == fileName && s.Status == success).First());
            }

            return file;
        }

        public int UpdateStatus(Guid id, Status status)
        {
            using (var context = new Context())
            {
                context.File.Where(s => s.Id == id).FirstOrDefault().Status = status;
                return context.SaveChanges();
            }
        }

        public List<File> GetFiles(FileRequest file)
        {
            var lList = new List<File>();
            using (var context = new Context())
            {
                IQueryable<Entities.File> lst = context.File;

                lst = lst.Where(f => f.Type == file.InterfaceType);

                if (file.Status != null)
                    lst = lst.Where(w => w.Status == file.Status.Value);

                if (file.CycleMonth != null && file.CycleYear != null)
                    lst = lst.Where(w => w.CycleDate.Value.Month == file.CycleMonth.Value && w.CycleDate.Value.Year == file.CycleYear.Value);

                if (file.PaymentDateIni != null)
                    lst = lst.Where(w => w.InclusionDate >= file.PaymentDateIni.Value.AddDays(1));

                if (file.PaymentDateEnd != null)
                    lst = lst.Where(w => w.InclusionDate < file.PaymentDateEnd.Value.AddDays(2));

                if (file.GenerationDateIni != null)
                    lst = lst.Where(w => w.InclusionDate >= file.GenerationDateIni.Value);

                if (file.GenerationDateEnd != null)
                    lst = lst.Where(w => w.InclusionDate <= file.GenerationDateEnd.Value);

                switch (file.OrderBy)
                {
                    case 0:
                        {
                            switch (file.SortBy.ToUpper())
                            {
                                case "FILENAME": lst = lst.OrderBy(p => p.FileName); break;
                                case "INCLUSIONDATE": lst = lst.OrderBy(p => p.InclusionDate); break;
                                case "STATUS": lst = lst.OrderBy(p => p.Status); break;
                                default: lst = lst.OrderBy(p => p.InclusionDate); break;
                            }
                            break;
                        }
                    default:
                        {
                            switch (file.SortBy.ToUpper())
                            {
                                case "FILENAME": lst = lst.OrderByDescending(p => p.FileName); break;
                                case "INCLUSIONDATE": lst = lst.OrderByDescending(p => p.InclusionDate); break;
                                case "STATUS": lst = lst.OrderByDescending(p => p.Status); break;
                                default: lst = lst.OrderByDescending(p => p.InclusionDate); break;
                            }
                            break;
                        }
                }

                //paginação
                int qtdregini = (file.Page * file.QuantityItemsPage) - file.QuantityItemsPage;
                lList = mapper.Map<List<File>>(lst.ToList()).Skip(qtdregini).Take(file.QuantityItemsPage + 1).ToList();
            }

            return lList;
        }

        public List<File> GetFiles(TypeRegister type, Status status)
        {
            var lList = new List<File>();
            using (var context = new Context())
            {
                IQueryable<Entities.File> lst = context.File.Where(f => f.Type == type && f.Status == status);
                lList = mapper.Map<List<File>>(lst.ToList()).ToList();
            }

            return lList;
        }

        public int UpdateFileName(Guid id, string fileName)
        {
            using (var context = new Context())
            {
                context.File.Where(s => s.Id == id).FirstOrDefault().FileName = fileName;
                return context.SaveChanges();
            }
        }

        public File GetFile(Expression<Func<File, bool>> condition)
        {
            using (var context = new Context())
            {
                var predicate = mapper.Map<Expression<Func<Entities.File, bool>>>(condition);

                return mapper.Map<File>(context.File.Where(predicate).OrderByDescending(o=> o.InclusionDate).FirstOrDefault());
            }
        }

        public int Delete(Expression<Func<File, bool>> func)
        {
            using (var context = new Context())
            {
                var predicate = mapper.Map<Expression<Func<Entities.File, bool>>>(func);                 
                context.File.RemoveRange(context.File.Where(predicate).ToList());
                return context.SaveChanges();
            }
        }

        public List<File> GetFiles(Expression<Func<File, bool>> condition)
        {
            using (var context = new Context())
            {
                var predicate = mapper.Map<Expression<Func<Entities.File, bool>>>(condition);
                return mapper.Map<List<File>>(context.File.Where(predicate).ToList());
            }
        }

        public int GetTodaySequentialFile(TypeRegister type)
        {
            using (var context = new Context())
            {
                return context.File.Where(x => x.Type.Equals(type) && x.InclusionDate.Date.Equals(DateTime.UtcNow.Date)).Count() + 1;
            }
        }

        public void UpdateParentId(Guid id, Guid parenteId)
        {
            using (var context = new Context())
            {
                var file = context.File.Find(id);

                if (file is not null)
                {
                    file.IdParent = parenteId;
                    context.SaveChanges();
                }
            }
        }
    }
}

