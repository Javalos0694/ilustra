namespace IlustraApp.Core.Bussiness.BDimensionProduct.Request
{
    public class CreateDimensionProductRequest
    {
        public List<DimensionClass> Dimensions { get; set; }
        public int IdProduct { get; set; }
    }

    public class DimensionClass
    {
        public int IdDimension { get; set; }
        public string DimensionName { get; set; }
        public string DimensionCode { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
