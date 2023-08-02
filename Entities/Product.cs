namespace E_Commerce_2.Entities
{
    public class Product
    {
        public int Id{get; set;}
        public string Name{get; set;}
        public string Image{get; set;}
        public int BrandId {get; set;}
        public int CategoryId{get; set;}
        
    }
}