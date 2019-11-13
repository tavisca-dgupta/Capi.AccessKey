namespace Tavisca.CAPI.AccessKey.Model.Models.DataApiModel
{
    public class DeactivateKeyDataResponse
    {
        public string AccessKey { get; set; }
        public bool IsKeyActive { get; set; }
        public string UpdatedBy { get; set; }
        public string LastUpdatedOn { get; set; }
    }

}
