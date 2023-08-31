namespace E_Commerce_2.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public List<Product> ProductList { get; set; }
    }
}
