using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_10._1
{
    public class ClientForManager : Client
    {
        public ClientForManager(string surname, string name, string patronymic, string phoneNumber, string passportData)
            : base(surname, name, patronymic, phoneNumber, passportData)
        {
            
        }

        // Переопределение свойств для предоставления доступа на запись
        public new string Surname
        {
            get { return base.Surname; }
            set 
            { 
                base.Surname = value; 
                OnPropertyChanged("Surname"); 
            }
        }

        public new string Name
        {
            get { return base.Name; }
            set 
            { 
                base.Name = value; 
                OnPropertyChanged("Name"); 
            }
        }

        public new string Patronymic
        {
            get { return base.Patronymic; }
            set 
            { 
                base.Patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }

        public new string PassportData
        {
            get { return base.passportData; }
            set 
            { 
                base.PassportData = value;
                OnPropertyChanged("PassportData");
            }
        }
    }
}
