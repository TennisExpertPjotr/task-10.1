using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Task_10._1
{
    /// <summary>
    /// Логика взаимодействия для ClientAdder.xaml
    /// </summary>
    public partial class ClientAdder : Window
    {
        private ObservableCollection<ClientForManager> clients;

        public ClientAdder(ObservableCollection<ClientForManager> clients)
        {
            this.clients = clients;
            InitializeComponent();
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(SurnameTextBox.Text))
            {
                MessageBox.Show("Фамилия не может быть пустой или состоять только из пробелов.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                MessageBox.Show("Имя не может быть пустым или состоять только из пробелов.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(PatronymicTextBox.Text))
            {
                MessageBox.Show("Отчество не может быть пустым или состоять только из пробелов.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Номер телефона не может быть пустым или состоять только из пробелов.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            else if (string.IsNullOrWhiteSpace(PassportTextBox.Text))
            {
                MessageBox.Show("Паспортные данные не могут быть пустыми или состоять только из пробелов.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            ClientForManager clientForManager = new ClientForManager (SurnameTextBox.Text, NameTextBox.Text,
                PatronymicTextBox.Text, PhoneNumberTextBox.Text, PassportTextBox.Text);

            Manager manager = new Manager();

            manager.AddClient(clients, clientForManager);

            this.DialogResult = true;
            this.Close();
        }
    }
}
