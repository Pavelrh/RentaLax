namespace rentaLax.Models
{
    public class ItemType
    {
        public int ItemTypeId { get; set; }
        public string Name { get; set; }

        public string PriceType { get; set; }
        public string Abbreviation { get; set; }

        // this is a child ref to items
        public List<Item>? Items { get; set; }
    }
}
