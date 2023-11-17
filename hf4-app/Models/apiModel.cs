using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hf4_app.Models
{
    class apiModel
    {

    }

    class Warehouse
    {
        private int id;
        private string name;
        private string location;

        public int Id { get { return id; } set { id = value; } }
        public string Name { get { return name; } set { name = value; } }
        public string Location { get { return location; } set { location = value; } }
    }
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
    class PackageEvents
    {
        public int Id { get; set; }
        public int PackageId { get; set; }
        public int WarehouseId { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    class Package
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string SenderAddress { get; set; }
        public string DestinationAddress { get; set; }
        public bool IsDelivered { get; set; }
        public bool IsFinished { get; set; }
        public DateTime createdAt { get; set; }

    }
    class UserLogin
    {
        public string UserName {  get; set; }
        public string Password { get; set; }
    }
}
