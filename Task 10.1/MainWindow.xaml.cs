using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Printing;
using System.Collections.ObjectModel;

namespace Task_10._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Client> clients = new ObservableCollection<Client>();
        private ObservableCollection<ClientForManager> clientsForManager = new ObservableCollection<ClientForManager>();
        private string role;
        private Client selectedClient;
        private const string filePath = "clients.json";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = AdminsComboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null)
            {
                string selectedItemText = selectedItem.Content.ToString();
                if (selectedItemText == "Консультант")
                {
                    role = "consultant";
                    LoadClientsFromJson();
                    ClientsListBox.ItemsSource = clients;
                    AddClientButton.IsEnabled = false;
                }
                else if (selectedItemText == "Менеджер")
                {
                    role = "manager";
                    LoadClientsForManagerFromJson();
                    ClientsListBox.ItemsSource = clientsForManager; 
                    AddClientButton.IsEnabled = true;
                }
                else
                {
                    MessageBox.Show("Неизвестный пользователь", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите под чьими правами вы хотите войти в систему");
            }
        }

        private void LoadClientsFromJson()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        IncludeFields = true
                    };

                    clients = JsonSerializer.Deserialize<ObservableCollection<Client>>(json, options);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void LoadClientsForManagerFromJson()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                        IncludeFields = true
                    };

                    clientsForManager = JsonSerializer.Deserialize<ObservableCollection<ClientForManager>>(json, options);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (role == "manager")
            {
                selectedClient = button.Tag as ClientForManager; 
            }
            else if (role == "consultant")
            {
                selectedClient = button.Tag as Client; 
            }

            if (selectedClient != null)
            {
                ClientEditor detailsWindow = new ClientEditor(selectedClient, role);
                bool? result = detailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Клиент не выбран или тип клиента неверен.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;

            if (clientsForManager != null)
            {
                ClientAdder detailsWindow = new ClientAdder(clientsForManager);
                bool? result = detailsWindow.ShowDialog();
            }
            else
            {
                MessageBox.Show("Что-то пошло не так.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
