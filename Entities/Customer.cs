namespace E_Commerce_2.Entities
{
    public class Customer
    {
        public int Id{get; set;}
        public User User{get; set;}
        public int UserId{get;set;}
        public Cart Cart { get; set; }
        public int CartId { get; set;}
    }
}