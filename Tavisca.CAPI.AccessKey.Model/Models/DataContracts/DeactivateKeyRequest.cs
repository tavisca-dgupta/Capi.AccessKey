namespace Tavisca.CAPI.AccessKey.Model.Models.DataContracts
{
    public class DeactivateKeyRequest
    {
        public string ClientName { get; set; }
        public string ClientId { get; set; }
        public string AccessKey { get; set; }
        public bool IskeyActive { get; set; }
        public string UpdatedBy { get; set; }
    }
}
