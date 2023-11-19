namespace hf4_app.Models
{
    public class Package
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string SenderAddress { get; set; }
        public string DestinationAddress { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsFinished { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    
    
    public class Warehouse
    {    
        public Warehouse(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
        private int id;
        private string name;
        private string location;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Location { get { return location; } set { location = value; } }
    }
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    public class PackageEvents
    {
        public PackageEvents() { }

        public PackageEvents(int id, int packageId, DateTime timeStamp, int warehouseId)
        {
            Id = id;
            PackageId = packageId;
            TimeStamp = timeStamp;
            WarehouseId = warehouseId;
        }

        public int Id { get; set; }
        public int PackageId { get; set; }
        public int WarehouseId { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class UserLogin
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
    }
}
