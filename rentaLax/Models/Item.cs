using System.ComponentModel;

namespace rentaLax.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public decimal PricePerHour { get; set; }
        public decimal Price { get; set; }
        public string ContactEmail { get; set; }
        public string Location { get; set; }
        public string Conditions { get; set; }

        // foreign key 
        public int ItemTypeId { get; set; }
        
        // this is a parent ref

        public ItemType? ItemType { get; set; }
    }
}
