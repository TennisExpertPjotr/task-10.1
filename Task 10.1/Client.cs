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
        private string passportData;

        public Client(string surname, string name, string patronymic, string phoneNumber, string passportData)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.phoneNumber = phoneNumber;
            this.passportData = passportData;
        }

        public string Surname
        {
            get { return surname; }
        }

        public string Name
        {
            get { return name; }
        }

        public string Patronymic
        {
            get { return patronymic; }
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
            get { return "**** ******"; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
