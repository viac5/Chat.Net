using Microsoft.AspNetCore.SignalR.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.DataBase;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using ChatClient;

namespace Client
{
    public partial class ProfileWindow : Window
    {
        Interaction interaction = new Interaction();
        ActionsAuthorizationData authorizationData = new ActionsAuthorizationData();
        MainWindow mainWindow = new MainWindow();
        public ProfileWindow()
        {
            InitializeComponent();
            tbNickname.Text = authorizationData.ReadData()[0];
            tbAboutMe.Text = interaction.ReadProfileText(tbNickname.Text);
        }
        private void ChangePhoto_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_NickName(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_AboutMe(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_Close(object sender, RoutedEventArgs e)
        {
            mainWindow.ProfileWindowIsOpen(false);
            Close();
            mainWindow.ProfileWindowIsOpen(true);
        }

        private void bSaveAboutMeText_Click(object sender, RoutedEventArgs e)
        {
            if (tbAboutMe.Text != "" && tbAboutMe.Text != "О себе")
            {
                interaction.WriteProfileText(tbNickname.Text, tbAboutMe.Text);
            }
        }
    }
}
