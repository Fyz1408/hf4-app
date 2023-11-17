namespace hf4_app.Models;

public class PackageModel
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
    
    public class PackageEvent {
        public int Id { get; set; }
        public int WarehouseId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}