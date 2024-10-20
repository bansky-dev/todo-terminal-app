using System.Dynamic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using System;
using System.IO;

namespace todo_terminal_app;

class Program
{
    public static int menuChoice;

    public static string jsonFilePath = "tasks.json";

    static void Main(string[] args)
    {

        bool isChoiceInvalid = true;


        List<Task> tasksList = new List<Task>();
        if (File.Exists(jsonFilePath))
        {
            string jsonData = File.ReadAllText(jsonFilePath);
            tasksList = JsonConvert.DeserializeObject<List<Task>>(jsonData) ?? new List<Task>();
        }
        

        while(isChoiceInvalid){
            menuDisplay();

            try
            {
                menuChoice = int.Parse(Console.ReadLine());
                isChoiceInvalid = false;
                
                if(menuChoice > 4 || menuChoice < 1)
                {
                    Console.Clear();
                    Console.WriteLine("Error: Invalid option!");
                    isChoiceInvalid = true;
                }
            }
            catch(FormatException)
            {
                Console.Clear();
                System.Console.WriteLine("Error: Invalid data format! Please insert a number!");
                isChoiceInvalid = true;

            }
            catch(Exception ex)
            {
                Console.Clear();
                System.Console.WriteLine($"Error occured: {ex.Message}");
                isChoiceInvalid = true;
            }
        }
        
        switch(menuChoice){
            case 1:
                // TODO: Make this function work
                Console.WriteLine("under construction sir..");
                break;
            case 2:
                // TODO: Needs improvement

                DateTime todaysDate = DateTime.Now.Date;

                System.Console.Write("Enter task name (short): ");
                string taskNameUser = Console.ReadLine();

                System.Console.Write("Enter task description: ");
                string taskDescUser = Console.ReadLine();

                Console.Write("When you want to do the task? (dd/mm/yyyy): ");
                string toDoDateUserInput = Console.ReadLine();

                Task task = new Task{
                    taskId = 1,
                    dateCreated = todaysDate.ToString(),
                    toDoDate = toDoDateUserInput,
                    name = taskNameUser,
                    description = taskDescUser

                };

                tasksList.Add(task);

                string updatedJsonData = JsonConvert.SerializeObject(tasksList, Formatting.Indented);
                File.WriteAllText(jsonFilePath, updatedJsonData);

                System.Console.WriteLine($"New task created!");
                break;
        }
        
    }

    public class Task{
        public int taskId {get; set;}
        public string dateCreated {get; set;}
        public string toDoDate {get; set;}
        public string name {get; set;}
        public string description {get; set;}
    }

    public static void menuDisplay(){
        Console.WriteLine("===CLI-TASK-MNG===");
        Console.WriteLine("[1] View existing tasks");
        Console.WriteLine("[2] Add new task");
        Console.WriteLine("[3] Delete existing task");
        Console.WriteLine("[4] Mark task as done");
        Console.Write("Choice: ");
    }
    
}
