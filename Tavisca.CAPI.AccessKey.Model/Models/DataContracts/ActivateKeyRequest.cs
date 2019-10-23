namespace Tavisca.CAPI.AccessKey.Model.Models.DataContracts
{
    public class ActivateKeyRequest
    {
        public string ClientName { get; set; }
        public string AccessKey { get; set; }
        public bool IskeyActive { get; set; }
        public string UpdatedBy { get; set; }
        public string ClientId { get; set; }
    }
}
