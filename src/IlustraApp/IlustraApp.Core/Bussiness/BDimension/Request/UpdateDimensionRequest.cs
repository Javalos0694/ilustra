namespace IlustraApp.Core.Bussiness.BDimension.Request
{
    public class UpdateDimensionRequest
    {
        public string DimensionName { get; set; }
        public string DimensionCode { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
