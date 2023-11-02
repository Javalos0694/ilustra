using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BDimension.Response
{
    public class DimensionResponse
    {
        public int IdDimension { get; set; }
        public string DimensionName { get; set; }
        public string DimensionCode { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
        public DimensionResponse(Dimension dimension)
        {
            IdDimension = dimension.IdDimension;
            DimensionName = dimension.DimensionName;
            DimensionCode = dimension.DimensionCoode;
            BasePrice = dimension.BasePrice;
            IsAvailable = dimension.IsAvailable;
        }
    }
}
