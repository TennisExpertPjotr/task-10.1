using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    public class Client : INotifyPropertyChanged
    {
        private string surname;
        private string name;
        private string patronymic;
        private string phoneNumber;
        protected string passportData;

        public DateTime ChangeTime {  get; set; }
        public List<string> ChangedData {  get; set; }
        public string ChangeType {  get; set; }
        public string Editor {  get; set; }

        public Client(string surname, string name, string patronymic, string phoneNumber, string passportData)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.phoneNumber = phoneNumber;
            this.passportData = passportData;
            this.ChangeTime = DateTime.Now;
            this.ChangedData = ["Фамилия", "Имя", "Отчество", "Номер телефона", "Паспортные данные"];
            this.ChangeType = "запись добавлена";
            this.Editor = "менеджер";
        }

        public string Surname
        {
            get { return surname; }
            protected set { surname = value; }
        }

        public string Name
        {
            get { return name; }
            protected set { name = value; }
        }

        public string Patronymic
        {
            get { return patronymic; }
            protected set { patronymic = value; }
        }

        public string PhoneNumber
        {
            get { return phoneNumber; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Phone number cannot be empty.");
                }
                phoneNumber = value;
                OnPropertyChanged("PhoneNumber");
            }
        }

        public string PassportData
        {
            get { return string.IsNullOrEmpty(passportData) ? "" : "**** ******"; }
            protected set { passportData = value; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
