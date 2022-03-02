using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;

namespace ConnectionHandler 
{
    class Handler
    {
        private Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private string s_receivedMessage = null;
        public string s_ReceivedMessage{
            get => s_receivedMessage;
        }

        public bool Connect(string s_ip, string s_port){
            
            int i_port;
            try{
                i_port = int.Parse(s_port);
            }catch{
                i_port = 9100;
            }

            var connection = s.BeginConnect(s_ip, i_port, null, null);
            bool success = connection.AsyncWaitHandle.WaitOne(1000, true);
            
            if (success){
                return true;
            }else{
                if (!View.Apperance.Retry()){
                    Disconnect();
                }else{
                    return false;
                }
            }
            return false;
        }

        public void Disconnect(){
            s.Close();
            Environment.Exit(Environment.ExitCode);
        }

        public void Send(string input){
            byte[] by_data = System.Text.Encoding.ASCII.GetBytes(input + "\n\r");
            s.Send(by_data);
            Thread.Sleep(100);  // short delay for answer; 
        }

        public void Receive(){

            byte[] b_inBuffer = new byte[1024];

            while (true){
                try{
                    int i_inBytes = s.Receive(b_inBuffer, 0, 1024, SocketFlags.None);
                    
                    if (i_inBytes > 0){
                        s_receivedMessage = Encoding.ASCII.GetString(b_inBuffer, 0, i_inBytes);
                    }else{
                        s_receivedMessage = null;
                    }

                }catch{
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n");
                    Console.WriteLine("ERROR LOST CONNECTION!");
                    Console.ForegroundColor = ConsoleColor.White;
                    Disconnect();
                    
                }
            }
        }
    }
}