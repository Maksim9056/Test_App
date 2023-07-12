using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static Testing.Program;

namespace Testing
{
    internal class Program
    {

        public class Questions
        {
            Questions() { }
            public int Id { get; set; }

            public string Questionss { get; set; }
            /// <summary>
            /// Правильный ответ
            /// </summary>
            public string Answer_True { get; set; }
            /// <summary>
            /// Оценка
            /// </summary>
            public string Grade_Quessions { get; set; }
            public Questions(int id, string questionss, string answer_True, string grade_Quessions)
            {
                Id = id;
                Questionss = questionss;
                Answer_True = answer_True;
                Grade_Quessions = grade_Quessions;
            }
        }
        public class Questionss
        {
            Questionss() { }
            public Questions[] Quest { get; set; }
            public Questionss(Questions[] quest)
            {
                Quest = quest;
            }
        }
        public class Questionss_travel
        {
            public List<Questionss> Questionsses = new List<Questionss>();
        }
        static void Main(string[] args)
        {
            try
            {
                Questions[] Questions =new  Questions[10];
                Questions d = new Questions(1,"","","");
                string FileFS = "";
                Questions[0] = d;

                Questionss questionss = new Questionss(Questions);
                     MemoryStream memoryStream = new MemoryStream();


                       JsonSerializer.Serialize<Questionss>(memoryStream, questionss);

                //Декодировали в строку  memoryStream    класс запоаковали в json строку
                FileFS = Encoding.Default.GetString(memoryStream.ToArray());

                Questionss msgtests = JsonSerializer.Deserialize<Questionss>(FileFS);

                string Code = "{\"Quest\":[{\"Id\":1,\"Questionss\":\"\\u041A\\u0430\\u043A \\u0434\\u0435\\u043B\\u0430?\",\"Answer_True\":\"\\u0425\\u043E\\u0440\\u043E\\u0448\\u043E\",\"Grade_Quessions\":null},{\"Id\":2,\"Questionss\":\"\\u041A\\u0430\\u043A \\u0434\\u0435\\u043B\\u0430 ?\",\"Answer_True\":\"\\u041F\\u0440\\u0438\\u0432\\u0435\\u0442!\",\"Grade_Quessions\":null},{\"Id\":3,\"Questionss\":\"Admin@Admin.ru\",\"Answer_True\":\"Admin@Admin.ru\",\"Grade_Quessions\":null},{\"Id\":4,\"Questionss\":\"Admin@Admin.ru\",\"Answer_True\":\"Admin@Admin.ru\",\"Grade_Quessions\":null},{\"Id\":5,\"Questionss\":\"Admin@Admin.ru\",\"Answer_True\":\"Admin@Admin.ru\",\"Grade_Quessions\":null},{\"Id\":6,\"Questionss\":\"Admin@Admin.ru\",\"Answer_True\":\"Admin@Admin.ru\",\"Grade_Quessions\":null},{\"Id\":7,\"Questionss\":\"Admin@Admin.ru\",\"Answer_True\":\"Admin@Admin.ru\",\"Grade_Quessions\":null},{\"Id\":8,\"Questionss\":\"Admin@Admin.ru\",\"Answer_True\":\"Admin@Admin.ru\",\"Grade_Quessions\":null},{\"Id\":9,\"Questionss\":\"Admin@Admin.ru\",\"Answer_True\":\"Admin@Admin.ru\",\"Grade_Quessions\":null}]}";
                Questionss_travel msgtest = JsonSerializer.Deserialize<Questionss_travel>(Code);
                Console.ReadLine();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
