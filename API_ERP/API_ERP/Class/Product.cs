namespace API_ERP.Class
{
    public class Product
    {
        public DateTime CreatedAt { get; set; }
        public string Name { get; set; }
        public Details Details { get; set; }
        public int Stock { get; set; }
        public string Id { get; set; }
    }

    public class Details
    {
        public string Price { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }

}
