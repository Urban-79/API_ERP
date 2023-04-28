namespace API_ERP.Class
{
    /// <summary>
    /// Classe du client
    /// </summary>
    public class Customer
    {
        public string CreatedAt { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Address { get; set; }
        public Profile Profile { get; set; }
        public Company Company { get; set; }
        public string Id { get; set; }
        public List<Order> Orders { get; set; }
    }
    /// <summary>
    /// Classe adresse du client
    /// </summary>
    public class Address
    {
        public string PostalCode { get; set; }
        public string City { get; set; }
    }
    /// <summary>
    /// Classe profile du client
    /// </summary>
    public class Profile
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    /// <summary>
    /// Classe Entreprise du client
    /// </summary>
    public class Company
    {
        public string CompanyName { get; set; }
    }
    /// <summary>
    /// Classe Commande du client
    /// </summary>
    public class Order
    {
        public string CreatedAt { get; set; }
        public string Id { get; set; }
        public string CustomerId { get; set; }
    }
}
