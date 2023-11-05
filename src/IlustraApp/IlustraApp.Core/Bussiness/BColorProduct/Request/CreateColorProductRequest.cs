namespace IlustraApp.Core.Bussiness.BColorProduct.Request
{
    public class CreateColorProductRequest
    {
        public List<ColorClass> Colors { get; set; }
        public int IdProduct { get; set; }
    }

    public class ColorClass
    {
        public int IdColor { get; set; }
        public string ColorName { get; set; }
        public string ColorCode { get; set; }
        public decimal BasePrice { get; set; }
        public bool IsAvailable { get; set; }
    }
}
