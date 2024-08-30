using Microsoft.Windows.Themes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    public class Manager : IAddClient, IEditClient
    {
        public Manager() { }

        public void AddClient(ObservableCollection<ClientForManager> clients, ClientForManager client) 
        {
            client.ChangeTime = DateTime.Now;
            client.ChangedData = ["Фамилия", "Имя", "Отчество", "Номер телефона", "Пасспортные данные"];
            client.ChangeType = "запись добавлена";
            client.Editor = "менеджер";

            clients.Add(client);
        }

        public void EditClient (Client client, Client newClient)
        {
            ClientForManager clientForManager;
            clientForManager = (ClientForManager)client;

            ClientForManager newClientForManager;
            newClientForManager = (ClientForManager)newClient;

            if (clientForManager.Surname != newClientForManager.Surname || clientForManager.Name != newClientForManager.Name ||
                clientForManager.Patronymic != newClientForManager.Patronymic || 
                clientForManager.PhoneNumber != newClientForManager.PhoneNumber || 
                clientForManager.PassportData != newClientForManager.PassportData)
            {
                List<string> changedProperties = [];
                if (clientForManager.Surname != newClientForManager.Surname)
                {
                    changedProperties.Add("Фамилия");
                    clientForManager.Surname = newClientForManager.Surname;
                }
                if (clientForManager.Name != newClientForManager.Name)
                {
                    changedProperties.Add("Имя");
                    clientForManager.Name = newClientForManager.Name;
                }
                if (clientForManager.Patronymic != newClientForManager.Patronymic)
                {
                    changedProperties.Add("Отчество");
                    clientForManager.Patronymic = newClientForManager.Patronymic;
                }
                if (clientForManager.PhoneNumber != newClientForManager.PhoneNumber)
                {
                    changedProperties.Add("Номер телефона");
                    clientForManager.PhoneNumber = newClientForManager.PhoneNumber;
                }
                if (clientForManager.PassportData != newClientForManager.PassportData)
                {
                    changedProperties.Add("Паспортные данные");
                    clientForManager.PassportData = newClientForManager.PassportData;
                }
                clientForManager.ChangeTime = DateTime.Now;
                clientForManager.ChangedData = changedProperties;
                clientForManager.ChangeType = "редактирование полей";
                clientForManager.Editor = "менеджер";
            }
        }

    }
}
