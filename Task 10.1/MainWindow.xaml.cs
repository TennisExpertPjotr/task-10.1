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

namespace Task_10._1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Client> clients = new List<Client>();
        private Client selectedClient;
        private const string filePath = "clients.json";

        public MainWindow()
        {
            InitializeComponent();

            // Загрузка данных из JSON при запуске приложения
            LoadClientsFromJson();
            ClientsListBox.ItemsSource = clients;
        }

        private void LoadClientsFromJson()
        {
            if (File.Exists(filePath))
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    clients = JsonSerializer.Deserialize<List<Client>>(json);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            selectedClient = button.Tag as Client;

            // Открытие нового окна с информацией о клиенте
            ClientEditor detailsWindow = new ClientEditor(selectedClient);
            bool? result = detailsWindow.ShowDialog();

            if (result == true)
            {
                // Обновление списка клиентов в ListBox
                ClientsListBox.Items.Refresh();
                SaveInfo();
            }
        }

        private void SaveInfo()
        {
            try
            {
                string json = JsonSerializer.Serialize(clients, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}