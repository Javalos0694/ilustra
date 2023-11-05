namespace IlustraApp.Core.Bussiness.BColorProduct.Request
{
    public class DeleteColorProductRequest
    {
        public List<ColorClass> Colors { get; set; }
        public int IdProduct { get; set; }
    }
}
