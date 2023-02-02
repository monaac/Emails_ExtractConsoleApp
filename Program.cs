// See https://aka.ms/new-console-template for more information

using System;
using System.Net;
using System.Text.RegularExpressions;

namespace EmailExtractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a website URL to extract emails from:");
            string website = Console.ReadLine();

            try
            {
                WebClient client = new WebClient();
                string htmlCode = client.DownloadString(website);

                string pattern = @"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
                MatchCollection matches = Regex.Matches(htmlCode, pattern);

                Console.WriteLine("Emails found:");
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.ReadLine();
        }
    }
}

