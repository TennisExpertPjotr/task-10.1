using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    public class Consultant : IEditClient
    {
        public Consultant() { }

        public void EditClient(Client client, Client newClient)
        {
            if (client.PhoneNumber != newClient.PhoneNumber)
            {
                client.PhoneNumber = newClient.PhoneNumber;
                client.ChangeTime = DateTime.Now;
                client.ChangedData = ["Номер телефона"];
                client.ChangeType = "редактирование полей";
                client.Editor = "консультант";
            }
        }
    }
}
