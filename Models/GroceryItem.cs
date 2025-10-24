namespace TodoListApp.Models
{
    public class GroceryItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public bool IsPurchased { get; set; }
    }
}