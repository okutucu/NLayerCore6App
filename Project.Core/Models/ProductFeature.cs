namespace Project.Core.Models
{
    public class ProductFeature
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }

        //ForingKey
        public int ProductId { get; set; }

        public virtual Product Product { get; set; }


    }
}
