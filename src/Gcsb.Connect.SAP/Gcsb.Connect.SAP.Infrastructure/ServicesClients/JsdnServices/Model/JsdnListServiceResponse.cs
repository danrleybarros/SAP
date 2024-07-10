using System;
using System.Collections.Generic;
using System.Text;

namespace Gcsb.Connect.SAP.Infrastructure.ServicesClients.JsdnServices.Model
{
    public partial class JsdnListServicesResponse
    {
        public Services Services { get; set; }
    }

    public partial class Services
    {
        public List<ServiceList> ServiceList { get; set; }
    }

    public partial class ServiceList
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string MoreInfo { get; set; }
        public TypeEnum Type { get; set; }
        public ServiceCategories ServiceCategories { get; set; }
        public MediaSet MediaSet { get; set; }
        public Uri Urn { get; set; }
        public bool ServiceAssignedToUser { get; set; }
        public string Requirements { get; set; }
        public string Faqs { get; set; }
    }

    public partial class MediaSet
    {
        public List<ServiceMedia> ServiceMedia { get; set; }
    }

    public partial class ServiceMedia
    {
        public List<LogoList> LogoList { get; set; }
    }

    public partial class LogoList
    {
        public Uri Urn { get; set; }
        public string Dimensions { get; set; }
    }

    public partial class ServiceCategories
    {
        public List<CategoryList> CategoryList { get; set; }
    }

    public partial class CategoryList
    {
        public string Name { get; set; }
        public List<ServiceSubCategory> ServiceSubCategories { get; set; }
    }

    public partial class ServiceSubCategory
    {
        public string Name { get; set; }
    }

    public enum TypeEnum { BundledService, IndividualService };

}
