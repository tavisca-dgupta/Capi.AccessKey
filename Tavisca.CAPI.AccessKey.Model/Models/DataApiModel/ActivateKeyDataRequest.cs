namespace Tavisca.CAPI.AccessKey.Model.Models.DataApiModel
{
    public class ActivateKeyDataRequest
    {
        public string ClientName { get; set; }
        public string AccessKey { get; set; }
        public bool IskeyActive { get; set; }
        public string UpdateDate { get; set; }
        public string UpdatedBy { get; set; }
    }

}
