namespace Gcsb.Connect.SAP.WebApi.Config.Model
{
    public class UserInfo
    {
        public string CompanyName { get; set; }
        public bool Imported { get; set; }
        public bool Empty { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string LoginName { get; set; }
        public string RoleName { get; set; }
        public long RoleId { get; set; }
        public long CompanyId { get; set; }
        public string TenantID { get; set; }
        public bool IsImported { get; set; }
        public long CustomerCode { get; set; }
    }
}
