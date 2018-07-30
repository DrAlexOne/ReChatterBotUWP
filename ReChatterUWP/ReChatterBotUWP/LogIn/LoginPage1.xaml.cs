using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Telegram.Bot;
using ReChatterBotUWP.LogIn;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReChatterBotUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class LoginPage1 : Page
    {
        private static TelegramBotClient client;

        public LoginPage1()
        {
            this.InitializeComponent();
            client = new TelegramBotClient(AppSettings.Key);

            IKbutton.IsChecked = true;

            True.Visibility = Visibility.Visible;
            False.Visibility = Visibility.Collapsed;
        }

        private async void NextLogin(object sender, RoutedEventArgs e)
        {
            try
            {
                Random r = new Random();

                string a1 = r.Next(1, 10).ToString();
                string b1 = r.Next(1, 10).ToString();
                string c1 = r.Next(1, 10).ToString();
                string d1 = r.Next(1, 10).ToString();
                string e1 = r.Next(1, 10).ToString();
                string f1 = r.Next(1, 10).ToString();

                AppSettings.CheckCode = a1 + b1 + c1 + d1 + e1 + f1;
                AppSettings.UserID = UserID.Text;
                await client.SendTextMessageAsync(UserID.Text, "Your authorization code: " + a1 + b1 + c1 + d1 + e1 + f1 + ". If you shouldn't get this code, ignore this message");

                Frame.Navigate(typeof(LoginPage2));
            }
            catch(Exception ex)
            {
                ContentDialog ErrorDialog = new ContentDialog()
                {
                    Title = "An error occurred",
                    Content = "Error: " + ex,
                    CloseButtonText = "OK"
                };

                await ErrorDialog.ShowAsync();
            }
        }

        private void IDKbutton_Checked(object sender, RoutedEventArgs e)
        {
            True.Visibility = Visibility.Collapsed;
            False.Visibility = Visibility.Visible;
        }

        private void IKbutton_Checked(object sender, RoutedEventArgs e)
        {
            True.Visibility = Visibility.Visible;
            False.Visibility = Visibility.Collapsed;
        }
    }
}
