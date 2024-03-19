using ChatClient;
using System.Windows;
using System.Windows.Controls;


namespace Client
{
    public partial class AuthorizationWindow : Window
    {
        public bool IsUserRegistered = false;

        DataBase.Interaction interaction = new DataBase.Interaction();
        ActionsAuthorizationData authorizationData = new ActionsAuthorizationData();
        MainWindow main = new MainWindow();

        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_SignIn(object sender, RoutedEventArgs e)
        {
            string[] userData = authorizationData.ReadData();
            string[] userIdent = interaction.ReadUserData(userData[0]);
            if (userData[0] == userIdent[0] && userData[1] == userIdent[1] && userData[2] == userIdent[2])
            {
                main.Show();
                this.Close();
            }
            else
            {
                //всплывающее предупреждение об ошибке входа
            }
        }
        private void Button_Click_SignUp(object sender, RoutedEventArgs e)
        {
            if (interaction.TheUserAlreadyExists(tbLogin.Text))
            {
                string[] data = authorizationData.ReadData();
                if (data[0] == tbLogin.Text && data[1] == tbPassword.Text && data[2] == interaction.ReadUserData(tbLogin.Text)[2])
                {
                    Console.WriteLine("Вы уже зарегестрированы, попробуйте войти"); //предупреждение о существовании другой кнопки                 
                }
                else
                    Console.WriteLine("Этот ник уже занят"); //вывести на экран предупреждение о занятости ника
            }
            else
            {
                interaction.RegistrtationUser(tbLogin.Text, tbPassword.Text);
                main.Show();
                this.Close();
            }
        }

        private void tbPassword_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            main.Close();
        }
    }
}