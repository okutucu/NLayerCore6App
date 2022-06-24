namespace Project.Core.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }


        //Relational Property
        public List<Product> Products { get; set; }
    }
}
