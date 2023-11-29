using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiscordSpam
{
    internal class Setup
    {
        public string channelId;
        public string userToken;

        public int rounds;

        public string message;

        public Setup()
        {
            Banner();
            Run();
        }


        public void Banner()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine(@"                                                                      
                                                                       
             (((                                       %@@            
            (((((                                     @@@@@           
            ((((((( *(((((((((((((# @@@@@@@@@@@@@@/ @@@@@@@           
            ,(((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@@            
         (((((((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@@@@@@        
        ((((((((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@@@@@@@       
       (((((((((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@@@@@@@@      
      ((((((((((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@@@@@@@@@     
     (((((((((((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@    
    ((((((((((((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@   
   (((((((((((((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@&  
   (((((((((((((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@. 
  (((((((((((((((((. ,((((((((((((# @@@@@@@@@@@@@* /@@@@@@@@@@@@@@@@@ 
 ,(((((((((((((((((        *((((((# @@@@@@@(        @@@@@@@@@@@@@@@@@.
 ((((((((((((((((((           /(((# @@@@&           @@@@@@@@@@@@@@@@@&
 (((((((((((((((((((         (((((# @@@@@&         @@@@@@@@@@@@@@@@@@@
 ((((((((((((((((((((((*,,((((((((# @@@@@@@@@/*#@@@@@@@@@@@@@@@@@@@@@@
.((((((((((((,((((((((((((((((((((# @@@@@@@@@@@@@@@@@@@@@&(@@@@@@@@@@@
 ((((((((((((((/  /#((((((((((((((# @@@@@@@@@@@@@@@@#  .@@@@@@@@@@@@@@
   ((((((((((((((((/      */#(((((# @@@@@@@%(.     *@@@@@@@@@@@@@@@@  
      ((((((((((((((((                           @@@@@@@@@@@@@@@#     
           ,((((((((                               &@@@@@@%,  
");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public void Run()
        {
            channelId = ChannelId();
            userToken = UserToken();
            rounds = Rounds();
            message = Message();
        }

        public string ChannelId()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [?]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Channel ID: ");
            string value = Console.ReadLine();
            return value;
        }

        public string UserToken()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [?]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Account Token: ");

            StringBuilder token = new StringBuilder();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
                {
                    token.Append(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else
                {
                    if (keyInfo.Key == ConsoleKey.Backspace && token.Length > 0)
                    {
                        token.Length--;
                        Console.Write("\b \b");
                    }
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine();

            return token.ToString();
        }

        public int Rounds()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [?]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" Rounds: ");
            string value = Console.ReadLine();

            if (int.TryParse(value, out rounds))
            {
                return rounds;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" [-]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" Insert Numbers!");
                return Rounds();
            }
        }

        public string Message()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" [?]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" You Message (MAX: 1.000)");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("Message: ");
            string value = Console.ReadLine();

            if (value.Length > 1000)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(" [-]");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\r Invalid, max lenght 1.000. => " + value.Length);
                return Message();
            }
            else
            {
                return value;
            }

        }

    }
}
