namespace IlustraApp.Core.Bussiness.BColorProduct.Response
{
    public class ColorsByProductResponse
    {
        public List<ColorClass> Colors { get; set; }
        public int Total { get; set; }
    }

    public class ColorClass
    {
        public int IdColor { get; set; }

    }
}
