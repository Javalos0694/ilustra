using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BDimension.Response
{
    public class DimensionsResponse
    {
        public List<DimensionClass> Dimensions { get; set; }
        public int Total { get; set; }
        public DimensionsResponse(List<Dimension> dimensions)
        {
            Dimensions = new();
            foreach (var dimension in dimensions)
            {
                Dimensions.Add(new DimensionClass(dimension));
            }
            Total = Dimensions.Count;
        }

        public DimensionsResponse(List<DimensionXproduct> dimensions)
        {
            Dimensions = new();
            foreach (var dimension in dimensions)
            {
                Dimensions.Add(new DimensionClass(dimension));
            }
            Total = Dimensions.Count;
        }
    }

    public class DimensionClass
    {
        public int IdDimension { get; set; }
        public string DimensionName { get; set; }
        public string DimensionCode { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
        public DimensionClass(Dimension dimension)
        {
            IdDimension = dimension.IdDimension;
            DimensionName = dimension.DimensionName;
            DimensionCode = dimension.DimensionCode;
            BasePrice = dimension.BasePrice;
            IsAvailable = dimension.IsAvailable;
        }

        public DimensionClass(DimensionXproduct dimension)
        {
            IdDimension = dimension.IdDimension;
            DimensionName = dimension.IdDimensionNavigation.DimensionName;
            DimensionCode = dimension.IdDimensionNavigation.DimensionCode;
            BasePrice = dimension.IdDimensionNavigation.BasePrice;
            IsAvailable = dimension.IdDimensionNavigation.IsAvailable;
        }
    }
}
