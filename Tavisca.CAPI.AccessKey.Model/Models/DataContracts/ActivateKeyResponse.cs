namespace Tavisca.CAPI.AccessKey.Model.Models.DataContracts
{
    public class ActivateKeyResponse
    {
        public string ClientName { get; set; }
        public string AccessKey { get; set; }
        public bool IskeyActive { get; set; }
        public string UpdatedBy { get; set; }
    }
}
