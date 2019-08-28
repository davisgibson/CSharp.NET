using System;
namespace ToDo
{
    public class ToDoItem
    {
        public int id { get; private set; }
        public string description { get; set; }
        public bool isDone { get; set; }
        public ToDoItem(string description, bool isDone)
        {
            this.description = description;
            this.isDone = isDone;
        }
        public override string ToString()
        {
            return $"{this.id} | {this.description} - {this.isDone}";
        }
    }
}
