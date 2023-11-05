using IlustraApp.Core.Entities;

namespace IlustraApp.Core.Bussiness.BColor.Response
{
    public class ColorsResponse
    {
        public List<ColorClass> Colors { get; set; }
        public int Total { get; set; }
        public ColorsResponse(List<Color> colors)
        {
            Colors = new List<ColorClass>();
            foreach (var color in colors)
            {
                Colors.Add(new ColorClass(color));
            }

            Total = Colors.Count;
        }
        public ColorsResponse(List<ColorXproduct> colors)
        {
            Colors = new();
            foreach (var color in colors)
            {
                Colors.Add(new ColorClass(color));
            }
            Total = Colors.Count;
        }
    }

    public class ColorClass
    {
        public int IdColor { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
        public ColorClass(Color color)
        {
            IdColor = color.IdColor;
            ColorName = color.ColorName;
            ColorCode = color.ColorCode;
            BasePrice = color.BasePrice;
            IsAvailable = color.IsAvailable;
        }
        public ColorClass(ColorXproduct color)
        {
            IdColor = color.IdColorNavigation.IdColor;
            ColorName = color.IdColorNavigation.ColorName;
            ColorCode = color.IdColorNavigation.ColorCode;
            BasePrice = color.IdColorNavigation.BasePrice;
            IsAvailable = color.IdColorNavigation.IsAvailable;
        }
    }
}
