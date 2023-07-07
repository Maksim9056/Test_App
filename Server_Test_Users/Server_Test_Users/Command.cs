using Class_interaction_Users;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace Server_Test_Users
{
    internal class Command
    {

        public void CheckMail_and_Passwords(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            try
            {
                CheckMail_and_Password? person3 = JsonSerializer.Deserialize<CheckMail_and_Password>(arg1);

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                @class.Check_login_amail(person3);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.



                if (@class.Travel == null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Regis_users regis_Users = new Regis_users(0, "", "", 0, "");
                        JsonSerializer.Serialize<Regis_users>(ms, regis_Users);
                        //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }
                else
                {
                   if(@class.Tru_user == true)
                   {
                      using (MemoryStream ms = new MemoryStream())
                      {
                        JsonSerializer.Serialize<Regis_users>(ms, @class.Travel);
                         //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                      }
                   }

               
                }
                // @class.Regis_users
             
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Delete_Message(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void Insert_Message(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void List_Friens(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void List_Friens_Message(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }


        /// <summary>
        /// Регистрирует пользователя 
        /// </summary>
        public void Registration_users(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
            try
            {
                Regis_users? person3 = JsonSerializer.Deserialize<Regis_users>(arg1);
                /// person3;
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
                @class.Regis_user(person3);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.




                if (@class.Travel == null)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        Regis_users regis_Users = new Regis_users(0,"","",0,"");
                        JsonSerializer.Serialize<Regis_users>(ms, regis_Users);
                        //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }
                else
                {


                    // @class.Regis_users
                    using (MemoryStream ms = new MemoryStream())
                    {
                        JsonSerializer.Serialize<Regis_users>(ms, @class.Travel);
                        //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                        stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            

        }

        public void Sampling_Messages_Correspondence(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void Sampling_Users_Correspondence(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void Search_Image(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public  void Search_Image_Friends(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void Searh_Friends(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void Select_Message_Friend(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }

        public void Update_Message(byte[] arg1, GlobalClass @class, NetworkStream stream)
        {
        }
    }
}