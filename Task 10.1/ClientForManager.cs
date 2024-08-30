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

        public new string Surname
        {
            get { return base.Surname; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Surname cannot be empty.");
                }
                base.Surname = value; 
                OnPropertyChanged("Surname"); 
            }
        }

        public new string Name
        {
            get { return base.Name; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                base.Name = value; 
                OnPropertyChanged("Name"); 
            }
        }

        public new string Patronymic
        {
            get { return base.Patronymic; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Patronymic cannot be empty.");
                }
                base.Patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }

        public new string PassportData
        {
            get { return base.passportData; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("PassportData cannot be empty.");
                }
                base.PassportData = value;
                OnPropertyChanged("PassportData");
            }
        }
    }
}
