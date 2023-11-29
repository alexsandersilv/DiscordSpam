using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DiscordSpam
{
    internal class DiscordSpam
    {

        Setup setup = new Setup();

        private System.Timers.Timer aTimer;

        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(" [*]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Starting...");

            for (int i = 0; i < setup.rounds; i++)
            {

                if (i + 1 == setup.rounds)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" [?]");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" Repeat Spam [Y\\n] ");
                    string value = Console.ReadLine();

                    if (value == "Y")
                    {
                        Run();
                    }
                }
                else
                {
                    Spam();
                }


            }
        }

        private void Spam()
        {
           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://discord.com/api/v9/channels/" + setup.channelId + "/messages");
            request.Method = "POST";

            request.ContentType = "application/json";
            request.Headers.Add("authorization", setup.userToken);


            byte[] byteArray = Encoding.UTF8.GetBytes("{\"content\": \"" + setup.message + "\"}");

            request.ContentLength = byteArray.Length;

            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(byteArray, 0, byteArray.Length);
            }

            HttpWebResponse httpResponse = (HttpWebResponse)request.GetResponse();
            HttpStatusCode statusCode = httpResponse.StatusCode;

            using (Stream responseStream = httpResponse.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    string responseString = reader.ReadToEnd();

                    if (statusCode == HttpStatusCode.OK)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" [+]");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" Success!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" [-]");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" Fail!");
                    }
                }
            }


        }
        public void SetTimeOut(Action fn, int timeout)
        {
            aTimer = new System.Timers.Timer(timeout);
            aTimer.Elapsed += (sender, e) =>
            {
                fn.Invoke();
            };

            aTimer.Enabled = true;
        }


    }
}
