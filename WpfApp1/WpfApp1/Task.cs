using System;

namespace ToDoApp
{
    public class TaskItem
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; } 

        public override string ToString()
        {
            return $"{Name} - {Description} (Time: {Time:hh:mm tt})";
        }
    }
}
