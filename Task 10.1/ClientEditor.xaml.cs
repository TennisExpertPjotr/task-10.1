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

        public ClientEditor(Client client, string role)
        {
            InitializeComponent();
            this.client = client;

            SurnameTextBox.Text = client.Surname;
            NameTextBox.Text = client.Name;
            PatronymicTextBox.Text = client.Patronymic;
            PhoneNumberTextBox.Text = client.PhoneNumber;

            ChangeDateLabel.Content = client.ChangeTime;
            ChangeTypeLabel.Content = client.ChangeType;
            EditorLabel.Content = client.Editor;

            string changedData = "";
            foreach(string property in client.ChangedData)
            {
                changedData += property + ";";
            }

            ChangedPropertiesTextBlock.Text = changedData;

            if (role == "consultant")
            {
                SurnameTextBox.IsReadOnly = true;
                NameTextBox.IsReadOnly = true;
                PatronymicTextBox.IsReadOnly = true;
                PassportTextBox.IsReadOnly = true;

                PassportTextBox.Text = client.PassportData;

                SaveManagerButton.Visibility = Visibility.Collapsed;
                SaveButton.Visibility = Visibility.Visible;
            }
            else if (role == "manager")
            {
                ClientForManager clientForManager;
                clientForManager = (ClientForManager)client; 

                SurnameTextBox.IsReadOnly = false;
                NameTextBox.IsReadOnly = false;
                PatronymicTextBox.IsReadOnly = false;
                PassportTextBox.IsReadOnly = false;

                PassportTextBox.Text = clientForManager.PassportData;

                SaveManagerButton.Visibility = Visibility.Visible;
                SaveButton.Visibility = Visibility.Collapsed;
            }

            
        }

        private void SaveConsultantButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(PhoneNumberTextBox.Text))
            {
                MessageBox.Show("Номер телефона не может быть пустым или состоять только из пробелов.",
                                "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            Client newClient = new Client(client.Surname, client.Name, client.Patronymic, PhoneNumberTextBox.Text, client.PassportData);
            Consultant consultant = new Consultant();
            consultant.EditClient(client, newClient);

            this.DialogResult = true;
            this.Close();
        }

        private void SaveManagerButton_Click(object sender, RoutedEventArgs e)
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

            ClientForManager newClient = new ClientForManager(SurnameTextBox.Text, NameTextBox.Text, PatronymicTextBox.Text,
                PhoneNumberTextBox.Text, PassportTextBox.Text);

            Manager manager = new Manager();
            manager.EditClient(client, newClient);

            this.DialogResult = true;
            this.Close();
        }
    }
}
