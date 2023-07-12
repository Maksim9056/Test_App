using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Testing
{
    internal class Program
    {
        

        static void Main(string[] args)
        {
            List<string> Вопросы = new List<string>();

            string Return = "Вопросы?";

            Вопросы.Add(Return);
            var Ad = "Вопросы ?";
            Вопросы.Add(Ad);

            string[] вопросы = new string[Вопросы.Count()];

            for (int i = 0; i < Вопросы.Count(); i++)
            {
                вопросы[i] = Вопросы[i];
            }



            for (int i = 0; i < вопросы.Length; i++)
            {
                Console.WriteLine(вопросы[i]);
            }

            Console.ReadLine();

        }
    }
}
