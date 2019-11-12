namespace Tavisca.CAPI.AccessKey.Model.Models
{
    public class AccessKeyModel
    {
        public string ClientId { get; set; }
        public string ClientTenantId { get; set; }
        public string ClientName { get; set; }
        public string ProgramGroup { get; set; }
        public string Program { get; set; }
        public string AccessKey { get; set; }
        public bool IskeyActive { get; set; }
        public string UpdatedBy { get; set; }
    }
}
