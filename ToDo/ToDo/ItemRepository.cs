using System;
using System.Collections.Generic;
using System.Linq;
namespace ToDo
{
    public class ItemRepository
    {
        ItemContext context;
        public ItemRepository()
        {
            context = new ItemContext();
            context.Database.EnsureCreated();
        }
        //list all todo items
        public List<ToDoItem> getToDoItems()
        {
            IEnumerable<ToDoItem> list = context.ToDoList;
            return list.ToList();
        }

        public void addItem(string description, bool isDone)
        {
            context.Add(new ToDoItem(description, isDone));
            context.SaveChanges();
        }

        public void updateItem(int id, string newDescription, bool newStatus)
        {
            ToDoItem toFind = context.ToDoList.Where(x => x.id == id).FirstOrDefault();
            if(newDescription.Length > 0)
            {
                toFind.description = newDescription;
            }
            toFind.isDone = newStatus;
            context.Update(toFind);
            context.SaveChanges();
        }
        public void deleteItem(int id)
        {
            ToDoItem toFind = context.ToDoList.Where(x => x.id == id).FirstOrDefault();
            context.Remove(toFind);
            context.SaveChanges();
        }

        public List<ToDoItem> getDoneItems()
        {
            List<ToDoItem> ret = context.ToDoList.Where(x => x.isDone == true).ToList();
            return ret;
        }
        public List<ToDoItem> getUnfinishedItems()
        {
            List<ToDoItem> ret = context.ToDoList.Where(x => x.isDone == false).ToList();
            return ret;
        }
    }
}
