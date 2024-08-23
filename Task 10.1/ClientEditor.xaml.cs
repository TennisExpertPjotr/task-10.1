using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для ClientEditor.xaml
    /// </summary>
    public partial class ClientEditor : Window
    {
        private Client client;

        public ClientEditor(Client client)
        {
            InitializeComponent();
            this.client = client;

            SurnameLabel.Content = client.Surname;
            NameLabel.Content = client.Name;
            PatronymicLabel.Content = client.Patronymic;
            PhoneNumberTextBox.Text = client.PhoneNumber;
            PassportLabel.Content = client.PassportData;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Номер телефона не может быть пустым или состоять только из пробелов.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            client.PhoneNumber = PhoneNumberTextBox.Text;

            this.DialogResult = true;
            this.Close();
        }
    }
}
