using System;
using BL;
using Persistence;
namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            short mainChoose = 0, imChoose;
            ItemBL ibl = new ItemBL();
            string[] mainMenu = { "item Management", "Add customer", "Create Order", "exit" };
            string[] imMenu = { "Get By Item id", "Get All Item", "Search by item name", "back" };
            mainChoose = Menu("Order manager system", mainMenu);
           do
            {
                mainChoose = Menu(" Order Management System - OMS", mainMenu);
                switch (mainChoose)
                {
                    case 1:
                        do
                        {
                            // if (ibl == null) ibl = new ItemBL();
                            imChoose = Menu("Item Management", imMenu);
                            switch (imChoose)
                            {
                                case 1:
                                    Console.Write("\nInput Item Id: ");
                                    int itemId;
                                    if (Int32.TryParse(Console.ReadLine(), out itemId))
                                    {
                                        Item i = ibl.GetItemById(itemId);
                                        if (i != null)
                                        {
                                            Console.WriteLine("Item ID: " + i.ItemId);
                                            Console.WriteLine("Item Name: " + i.ItemName);
                                            Console.WriteLine("Item Price: " + i.ItemPrice);
                                            Console.WriteLine("Amount: " + i.Amout);
                                            Console.WriteLine("Item Status: " + i.Status);
                                            Console.WriteLine("Item Description: " + i.Description);
                                        }
                                        else
                                        {
                                            Console.WriteLine("There is no item with id " + itemId);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Your Choose is wrong!");
                                    }
                                    Console.WriteLine("\n    Press Enter key to back menu...");
                                    Console.ReadLine();
                                    break;
                                case 2:
                                   
                                    break;
                                case 3:
                                    
                                    break;
                            }
                        } while (imChoose != imMenu.Length);
                        break;
                    case 2:
                        
                        break;
                    case 3:
                        break;
                }
            } while (mainChoose != mainMenu.Length);
        }
        private static short Menu(string title, string[] menuItems)
        {
            string logo = @"mo hinh 3 lop";
            short choose = 0;
            Console.WriteLine(logo);
            string line = "==============================================";
            Console.WriteLine(line);
            Console.WriteLine(" " + title);
            Console.WriteLine(line);
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.WriteLine(" " + (i + 1) + ". " + menuItems[i]);
            }
            Console.WriteLine(line);
            do
            {
                Console.Write("Your choice: ");
                try
                {
                    choose = Int16.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Your Choose is wrong!");
                    continue;
                }
            } while (choose <= 0 || choose > menuItems.Length);
            return choose;
        }

    }
}
