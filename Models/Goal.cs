namespace TodoListApp.Models
{
    public class Goal
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty; // daily, weekly, monthly
        public bool IsCompleted { get; set; }
    }
}