using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace personal_organizer
{
    class Program
    {
        private static TaskManager taskManager = new TaskManager();
        private static DataManager dataManager = new DataManager();
        static void Main()
        {
            do
            {
                Display();
                switch (GetChoice())
                {
                    case 1:
                        //taskManager.GetPriorities();
                        break;
                    case 2:
                        Console.Write("Enter priority level: ");
                        int level = int.Parse(Console.ReadLine());
                        taskManager.CreatePriority(level);
                        break;
                    case 3:
                        Console.Write("Enter priority id: ");
                        int id = int.Parse(Console.ReadLine());
                        taskManager.RemovePriority(id);
                        break;
                    case 4:
                        //taskManager.GetCategories();
                        break;
                    case 5:
                        Console.Write("Enter category name: ");
                        string name = Console.ReadLine();
                        taskManager.CreateCategory(name);
                        break;
                    case 6:
                        Console.Write("Enter category id: ");
                        taskManager.RemoveCategory(int.Parse(Console.ReadLine()));
                        break;
                    case 7:
                        //taskManager.GetTasts();
                        break;
                    case 8:
                        Console.Write("Enter task name: ");
                        string n = Console.ReadLine();
                        Console.Write("Enter task description: ");
                        taskManager.CreateTask(n, Console.ReadLine());
                        break;
                    case 9:
                        Console.Write("Enter task id: ");
                        taskManager.RemoveTask(int.Parse(Console.ReadLine()));
                        break;
                    case 10:
                        Console.Write("Enter save path: ");
                        dataManager.SaveDataToFile(Console.ReadLine(), taskManager.WrapBox());
                        break;
                    case 11:
                        Console.Write("Enter file name: ");
                        dataManager.LoadDataFromFile(Console.ReadLine());
                        break;
                    case 12:
                        Console.Write("Enter file name: ");
                        dataManager.DeleteDataFile(Console.ReadLine());
                        break;
                    case 0:
                        break;
                    default:
                        break;
                }
            } while (AllowContinue());
        }

        public static void Display()
        {
            Console.WriteLine("\n ========================");
            Console.WriteLine("\n    Personal Organizer   ");
            Console.WriteLine("\n ========================");
            Console.WriteLine("\n    1 - All priorities   ");
            Console.WriteLine("\n    2 - Add priority     ");
            Console.WriteLine("\n    3 - Remove priority  ");
            Console.WriteLine("\n    4 - All categories   ");
            Console.WriteLine("\n    5 - Add category     ");
            Console.WriteLine("\n    6 - Remove category  ");
            Console.WriteLine("\n    7 - All tasks        ");
            Console.WriteLine("\n    8 - Add task         ");
            Console.WriteLine("\n    9 - Remove task      ");
            Console.WriteLine("\n    10 - Save data       ");
            Console.WriteLine("\n    11 - Load data       ");
            Console.WriteLine("\n    12 - Remove save file");
            Console.WriteLine("\n    0 - Exit             ");
            Console.WriteLine("\n ========================");
        }

        public static int GetChoice()
        {
            Console.Write("Enter number of operation: ");
            int choice = int.Parse(Console.ReadLine());
            return choice;
        }

        public static bool AllowContinue()
        {
            Console.Write("Continue? (y/n): ");
            string allow = Console.ReadLine();
            return (allow == "y");
        }
    }
}