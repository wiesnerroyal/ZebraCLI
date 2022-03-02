using System;

namespace View 
{
    class Apperance
    {
        public static void WriteCursor(){
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("ZEBRA-CLI> ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        public static void WriteHeader(){
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\n");
            Console.WriteLine("            ███████╗███████╗██████╗ ██████╗  █████╗        ██████╗██╗     ██╗");
            Console.WriteLine("            ╚══███╔╝██╔════╝██╔══██╗██╔══██╗██╔══██╗      ██╔════╝██║     ██║");
            Console.WriteLine("              ███╔╝ █████╗  ██████╔╝██████╔╝███████║█████╗██║     ██║     ██║");
            Console.WriteLine("             ███╔╝  ██╔══╝  ██╔══██╗██╔══██╗██╔══██║╚════╝██║     ██║     ██║");
            Console.WriteLine("            ███████╗███████╗██████╔╝██║  ██║██║  ██║      ╚██████╗███████╗██║");
            Console.WriteLine("            ╚══════╝╚══════╝╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝       ╚═════╝╚══════╝╚═╝");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                           ZEBRA-CLI V1.0.0 by Fabian Wiesner");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Clear(){
            try{                        // for vsdbg debugger
                Console.Clear();
            }catch{;}
            WriteHeader();
        }

        public static bool Retry(){

            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Connection error! Retry? [N/y]  ");
            Console.ForegroundColor = ConsoleColor.White;
            string input = Console.ReadLine();

            if ((input == "y") || (input == "Y")){
                return true;
            }else{
                return false;
            }
        }

        public static void WirteStatus(String s_ip, String s_port){
            Clear();
            Console.WriteLine($"connected to: {s_ip}:{s_port}   -   use \"e\" to leave ");
        }

        public static void WriteMenu(){
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine(" 1) Print Start");
            Console.WriteLine(" 2) Cancel All");
            Console.WriteLine(" 3) Load Autoexec");
            Console.WriteLine(" 4) Delete Autoexec");
            Console.WriteLine(" 5) Set Thermal Direct");
            Console.WriteLine(" 6) Set Thermal Transfer");
            Console.WriteLine(" 7) Set Printer-Time");
            Console.WriteLine(" 8) Get Printer-Head-Diagnostic");
            Console.WriteLine(" 9) Get Printer-Status");
            Console.WriteLine(" 10) Get Printer-Flash");
            Console.WriteLine(" 11) Get Printer-RAM");
            Console.WriteLine(" 12) Custom Command");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("   \"e\" - for Exit");
            Console.WriteLine();
            WriteCursor();
        }

        public static void WriteAnyKey(){
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Press any key to continue");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }

        public static void WriteResponse(string s_input){
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Printer> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(s_input);
        }
    }
}