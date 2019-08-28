using System;
using System.Collections.Generic;
namespace ToDo
{
    public class ConsoleUtils
    {
        ItemRepository itemRepo;
        string function = "all";
        public ConsoleUtils()
        {
            itemRepo = new ItemRepository();
        }
        public void start()
        {
            while (true)
            {
                Console.Clear();
                getFunction();
                function = "all";
                Console.WriteLine("What would you like to do? (exit)");
                Console.WriteLine("1. Display All Items");
                Console.WriteLine("2. Add a To Do Item");
                Console.WriteLine("3. Update an Item");
                Console.WriteLine("4. Get Done Items");
                Console.WriteLine("5. Get Unfinished Items");
                Console.WriteLine("6. Delete an Item");

                string choice = Console.ReadLine();
                if(choice == "exit")
                {
                    break;
                }
                else if(choice == "1")
                {
                    function = "all";
                }
                else if(choice == "2")
                {
                    addItem();
                }
                else if (choice == "3")
                {
                    updateItem();
                }
                else if (choice == "4")
                {
                    function = "doneItems";
                }
                else if(choice == "5")
                {
                    function = "unfinished";
                }
                else if(choice == "6")
                {
                    deleteItem();
                }
            }
            
        }

        public void printHeaders()
        {
            Console.WriteLine("--------------------------");
            Console.WriteLine("Id | Description | Done");
            Console.WriteLine("--------------------------");
        }

        public void printAll()
        {
            List<ToDoItem> all = itemRepo.getToDoItems();
            printHeaders();
            foreach(ToDoItem item in all)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
        public void addItem()
        {
            Console.WriteLine("What is the description?");
            string desc = Console.ReadLine();
            Console.WriteLine("is it done? true or false");
            string status = Console.ReadLine();
            bool isDone;
            if(status == "true")
            {
                isDone = true;
            }
            else
            {
                isDone = false;
            }
            itemRepo.addItem(desc, isDone);
        }

        public void updateItem()
        {
            Console.WriteLine("What is the ID of the item you'd like to update?");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("What is the new description? Leave this blank if it's the same");
            string desc = Console.ReadLine();
            Console.WriteLine("Is it done? true or false");
            string status = Console.ReadLine();
            bool isDone = false;
            if(status == "true")
            {
                isDone = true;
            }

            itemRepo.updateItem(id, desc, isDone);
        }

        public void getDoneItems()
        {
            List<ToDoItem> doneItems = itemRepo.getDoneItems();
            printHeaders();
            foreach (ToDoItem item in doneItems)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }

        public void getFunction()
        {
            if(function == "all")
            {
                printAll();
            }
            else if(function == "doneItems")
            {
                getDoneItems();
            }
            else if(function == "unfinished")
            {
                getUnfinished();
            }
        }

        public void deleteItem()
        {
            Console.WriteLine("What is the ID of the item you would like to delete?");
            int id = Convert.ToInt32(Console.ReadLine());
            itemRepo.deleteItem(id);
        }
        public void getUnfinished()
        {
            List<ToDoItem> unfinishedItems = itemRepo.getUnfinishedItems();
            printHeaders();
            foreach (ToDoItem item in unfinishedItems)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine();
        }
    }
}
