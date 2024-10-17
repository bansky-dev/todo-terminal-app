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

    static void Main(string[] args)
    {

        bool isChoiceInvalid = true;
        

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
                Console.WriteLine("under construction sir..");
                break;
            case 2:
                Task task = new Task{
                    taskId = 1,
                    dateCreated = "NaN",
                    toDoDate = "NaN",
                    name = "NaN",
                    description = "NaN"

                };

                string jsonString = JsonConvert.SerializeObject(task, Formatting.Indented);

                File.WriteAllText("tasks.json", jsonString);
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
