namespace ToDoApp
{
    public class TaskItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Time { get; set; } // New: Task Time

        public override string ToString()
        {
            return $"{Name} - {Description} (Time: {Time})";
        }
    }
}
