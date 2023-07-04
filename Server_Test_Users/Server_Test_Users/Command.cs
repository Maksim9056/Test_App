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
            CheckMail_and_Password? person3 = JsonSerializer.Deserialize<CheckMail_and_Password>(arg1);

#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            @class.Check_login_amail(person3);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.

            // @class.Regis_users
            using (MemoryStream ms = new MemoryStream())
            {
                JsonSerializer.Serialize<Regis_users>(ms,@class.Travel);
                //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
                stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
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
            Regis_users? person3 = JsonSerializer.Deserialize<Regis_users>(arg1);
            /// person3;
#pragma warning disable CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.
            @class.Regis_user(person3);
#pragma warning restore CS8604 // Возможно, аргумент-ссылка, допускающий значение NULL.





            // @class.Regis_users
            using (MemoryStream ms = new MemoryStream())
            {
              JsonSerializer.Serialize<Regis_users>(ms, @class.Regis_users);
                //  byte[] msgAnswe = System.Text.Encoding.Default.GetBytes();
             stream.Write(ms.ToArray(), 0, ms.ToArray().Length);
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