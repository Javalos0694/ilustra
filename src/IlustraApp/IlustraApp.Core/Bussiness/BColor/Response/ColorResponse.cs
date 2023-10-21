using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BColor.Response
{
    public class ColorResponse
    {
        public int IdColor { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
        public ColorResponse(Color color)
        {
            IdColor = color.IdColor;
            ColorName = color.ColorName;
            ColorCode = color.ColorCode;
            BasePrice = color.BasePrice;
            IsAvailable = color.IsAvailable;
        }
    }
}
