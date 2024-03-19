using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Client;
using Microsoft.AspNetCore.SignalR.Client;

namespace ChatClient
{
    public class MessageItem
    {
        public string Text { get; set; }
    }
    public partial class MainWindow : Window
    {
        HubConnection connection;  // подключение для взаимодействия с хабом
        bool isConnected = false;
        public bool ProfileIsOpen = false;

        public MainWindow()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
                .WithUrl("http://89.111.168.218:80/chat")
                .Build();
            //
            // http://89.111.168.218:80/chat
            //
            // регистрируем функцию Receive для получения данных
            connection.On<string, string>("Receive", (user, message) =>
            {
                Dispatcher.Invoke(() =>
                {
                    MessageItem newMessage = new MessageItem()
                    {
                        Text = $"{user}: {message}",
                    };
                    lbChat.Items.Add(newMessage.Text);
                });
            });
            //tbUserName.Text = authorizationData.ReadData()[0];
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            tbMessage.Text = "Сначала Connect";
            tbMessage.IsEnabled = false;
            bSendMessage.IsEnabled = false;

        }
        public async void ConnectUser()
        {
            if (!isConnected)
            {
                try
                {
                    await connection.StartAsync();
                    lbChat.Items.Add("Вы вошли в чат");
                    tbMessage.Text = string.Empty;
                    isConnected = true;
                    tbMessage.IsEnabled = true;
                    bSendMessage.IsEnabled = true;
                    tbUserName.IsEnabled = false;
                }
                catch (Exception ex)
                {
                    lbChat.Items.Add(ex.Message);
                }
            }
        }
        public async void DisconnectUser()
        {
            if (isConnected)
            {
                try
                {
                    await connection.StopAsync();
                    lbChat.Items.Add("Вы вышли из чата");
                    tbMessage.Text = "Сначала Connect";
                    tbMessage.IsEnabled = false;
                    isConnected = false;
                    bSendMessage.IsEnabled = false;
                    tbUserName.IsEnabled = true;
                }
                catch (Exception ex)
                {
                    lbChat.Items.Add(ex.Message);
                }
            }
        }
        private void Button_Click_ConDiscon(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisconnectUser();
                bConnDisconn.Content = "Connect";
            }
            else
            {
                ConnectUser();
                GetPermissionToConnect();
                bConnDisconn.Content = "Disconect";
            }
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisconnectUser();
        }
        private void GetPermissionToConnect()
        {
            if (tbUserName.Text.Length > 20)
            {
                tbUserName.Text = tbUserName.Text.Remove(20);
            }
        }
        private bool GetPermissionToSend(string message)
        {
            if (message == string.Empty || message.Length > 149)
                return false;
            if (message.Replace(" ", "").Length == 0)
                return false;
            return true;
        }
        private async void MessageSender()
        {
            try
            {
                if (GetPermissionToSend(tbMessage.Text))
                {
                    string date = DateTime.Now.ToShortTimeString();

                    await connection.InvokeAsync("Send", $"-{date}- {tbUserName.Text}", tbMessage.Text);
                    lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);
                }
            }
            catch (Exception ex)
            {
                lbChat.Items.Add(ex.Message);
            }
        }
        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                MessageSender();
                tbMessage.Text = string.Empty;
            }
        }
        private void Button_Click_Send(object sender, RoutedEventArgs e)
        {
            MessageSender();
            tbMessage.Text = string.Empty;
        }
        private void bCloseChat_Click(object sender, RoutedEventArgs e) => Close();
        public bool ProfileWindowIsOpen(bool a)
        {
            ProfileIsOpen = a;
            return ProfileIsOpen;
        }
        public void OpenWindow()
        {
            ProfileWindow profileWindow = new ProfileWindow();
            profileWindow.Closed += (s, e) => ProfileIsOpen = false; // Обработчик события закрытия окна профиля
            profileWindow.Show();
            ProfileIsOpen = true; // Установка флага, что окно профиля открыто
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ProfileIsOpen) // Проверка, что окно профиля не открыто
            {
                OpenWindow();
                ProfileIsOpen = true; // Установка флага, что окно профиля открыто
            }
        }
    }
}