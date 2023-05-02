using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace BruOS
{
    public class Kernel : Sys.Kernel
    {
        string version = "0.1";
        string credits = "Huy1234TH";

        // calc app
        int number1 = 0;
        int number2 = 0;
        bool inCalc = false;

        // setting app
        bool inSetting = false;

        protected override void BeforeRun()
        {
            Console.WriteLine("BruOS booted successfully!");
            Console.WriteLine("Type Something or Using 'help' command for display some command!");

            var fs = new Sys.FileSystem.CosmosVFS();
            Sys.FileSystem.VFS.VFSManager.RegisterVFS(fs);
        }

        protected override void Run()
        {
            var usersFile = @"0:\users.dat";

            if (!File.Exists(usersFile))
            {
                File.Create(usersFile);
            }

            Console.Write("> ");
            var input = Console.ReadLine();
            // Console.Write("Text typed: ");
            Console.WriteLine(input);

            switch (input)
            {
                case "help":
                    if (!inCalc)
                    {
                        Console.Clear();
                        Console.WriteLine("- BASIC COMMAND -");
                        Console.WriteLine("1. help - Display some command");
                        Console.WriteLine("2. clear or cls - Clear all text");
                        Console.WriteLine("3. version or ver - Display Version of BruOS");
                        Console.WriteLine("4. credits - Display all person who made BruOS");
                        Console.WriteLine("- APP SYSTEM COMMAND -");
                        Console.WriteLine("1. calc - Running calculation app for BruOS");
                        Console.WriteLine("- SYSTEM COMMAND -");
                        Console.WriteLine("1. shutdown - Power Off the OS");
                        Console.WriteLine("2. restart - Restart the OS");
                    }
                    break;

                case "calc":
                    Console.Clear();
                    inCalc = true;
                    if (inCalc)
                    {
                        Console.WriteLine("Please press the first number: ");
                        inCalc = false;
                    }
                    break;

                case "credits":
                    if (!inCalc)
                        Console.WriteLine("BruOS was made by " + credits);
                    break;

                case "version":
                    if (!inCalc)
                        Console.WriteLine("BruOS Version: " + version);
                    break;

                case "ver":
                    if (!inCalc)
                        Console.WriteLine("BruOS Version: " + version);
                    break;

                case "cls":
                    if (!inCalc)
                        Console.Clear();
                    break;

                case "clear":
                    if (!inCalc)
                        Console.Clear();
                    break;

                case "shutdown":
                    if (!inCalc)
                        Sys.Power.Shutdown(); 
                    break;

                case "restart":
                    if (!inCalc)
                        Sys.Power.Reboot();
                    break;

                default:
                    if (!inCalc)
                        Console.WriteLine("Unknow command");
                    break;
            }
        }
    }
}
