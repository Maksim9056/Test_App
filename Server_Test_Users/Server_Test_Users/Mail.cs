using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Class_interaction_Users;

namespace Server_Test_Users
{
    public class Mail
    {
        /// <summary>
        ///Проверки почты
        /// </summary>
        /// <param name="User"></param>
        /// <param name="mailUser"></param>
        public User RegUserMail(string User,string mailUser)
        {
            User user = new User();
            SmtpClient smtpClient = new SmtpClient("46.39.245.154");//Адрес сервиса
                                                                    //smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential("info@экзаменатор.москва", "951951Ss!");
            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("info@экзаменатор.москва");//От кого сообщение
                                                                          //mailMessage.To.Add("info@экзаменатор.москва");
            mailMessage.To.Add(mailUser);//Кому отправить
            mailMessage.Subject = $"Подтверждение почты {User}";//Тема

            mailMessage.Body = "Код подтверждения 1";//Текс тписьма
            try
            {
                smtpClient.Send(mailMessage);//Отправляем письмо
                Console.WriteLine("Письмо успешно отправлено!");
                Console.WriteLine("Отправлено");
            }
            catch (Exception e)
            {
                Console.WriteLine("Произошла ошибка при отправке письма: " + e.Message);
                Console.Read();
                user = new User() { Name_Employee = "1"};
            }

            return user;
        }
    }
}
