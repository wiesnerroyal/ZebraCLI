using System;
using System.Threading;

namespace ZebraCLI
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true){
            
                View.Apperance.Clear();
                
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Printer IP: ");
                Console.ForegroundColor = ConsoleColor.White;
                string s_ip = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Printer Port: ");
                Console.ForegroundColor = ConsoleColor.White;
                string s_port = Console.ReadLine();

                Console.WriteLine("connecting...");            
                ConnectionHandler.Handler ConnectionHandler = new ConnectionHandler.Handler();  

                if (ConnectionHandler.Connect(s_ip, s_port)){
                    
                    Thread ReceiveThread = new Thread(new ThreadStart(ConnectionHandler.Receive));
                    ReceiveThread.Start();
                    string s_input;

                    do{

                        View.Apperance.WriteHeader();
                        View.Apperance.WirteStatus(s_ip, s_port);
                        View.Apperance.WriteMenu();
                        s_input = Console.ReadLine();

                        switch (s_input){
                            case "1":
                                ConnectionHandler.Send("~PS");
                                break;

                            case "2":
                                ConnectionHandler.Send("~JA");
                                break;
                            
                            case "3":
                                ConnectionHandler.Send("~JA^XA^XFE:AUTOEXEC.ZPL^XZ");
                                break;
                        
                            case "4":
                                ConnectionHandler.Send("~JA^XA^IDE:AUTOEXEC.ZPL^XZ");
                                break;
                            
                            case "5":
                                ConnectionHandler.Send("^XA^MTD^MD0.0^XZ~SD0.0");
                                break;

                            case "6":
                                ConnectionHandler.Send("^XA^MTT^MD20.0^XZ~SD20.0");
                                break;

                            case "7":
                                var date = DateTime.Now;
                                string update_time = ("^XA^ST" + date.Month + "," + date.Day + "," + date.Year + "," + date.Hour + "," + date.Minute + "," + date.Second + ",M^JUS^XZ");
                                ConnectionHandler.Send(update_time);
                                break;

                            case "8":
                                ConnectionHandler.Send("~HD");
                                Thread.Sleep(500);              // wait for printer response
                                if (ConnectionHandler.s_ReceivedMessage != null){
                                    View.Apperance.WriteResponse(ConnectionHandler.s_ReceivedMessage);
                                }
                                View.Apperance.WriteAnyKey();
                                break;

                            case "9":{
                                 ConnectionHandler.Send("~HD");
                                Thread.Sleep(500);              // wait for printer response
                                if (ConnectionHandler.s_ReceivedMessage != null){
                                    View.Apperance.WriteResponse(ConnectionHandler.s_ReceivedMessage);
                                }
                                View.Apperance.WriteAnyKey();
                                break;                               
                            }

                            case "10":
                                ConnectionHandler.Send("^XA^HWE:^XZ");
                                Thread.Sleep(500);              // wait for printer response
                                if (ConnectionHandler.s_ReceivedMessage != null){
                                    View.Apperance.WriteResponse(ConnectionHandler.s_ReceivedMessage);
                                }
                                View.Apperance.WriteAnyKey();
                                break;

                            case "11":
                                ConnectionHandler.Send("^XA^HWR:^XZ");
                                Thread.Sleep(500);              // wait for printer response
                                if (ConnectionHandler.s_ReceivedMessage != null){
                                    View.Apperance.WriteResponse(ConnectionHandler.s_ReceivedMessage);
                                }
                                View.Apperance.WriteAnyKey();                           
                                break;

                            case "12":   
                                View.Apperance.WriteHeader();
                                View.Apperance.WirteStatus(s_ip, s_port);
                                Console.WriteLine("\n");

                                while (s_input != "e"){
                                    View.Apperance.WriteCursor();
                                    s_input = Console.ReadLine();
                                    ConnectionHandler.Send(s_input);                    
                                    if (ConnectionHandler.s_ReceivedMessage != null){
                                        Console.WriteLine($"Printer> {ConnectionHandler.s_ReceivedMessage}");
                                    }
                                }
                                s_input = null;
                                break;

                            case "e":
                                ConnectionHandler.Disconnect();
                                break;

                            default:
                                break;
                        }

                    }while (s_input != "e");
                }else{
                    Main(null);
                }
            }
        }
	}
}
