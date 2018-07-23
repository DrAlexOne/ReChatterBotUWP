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
        }

        private async void NextLogin(object sender, RoutedEventArgs e)
        {
            try
            {
                Random r = new Random();

                int a1 = r.Next(1, 10);
                int b1 = r.Next(1, 10);
                int c1 = r.Next(1, 10);
                int d1 = r.Next(1, 10);
                int e1 = r.Next(1, 10);
                int f1 = r.Next(1, 10);

                AppSettings.CheckCode = a1 + b1 + c1 + d1 + e1 + f1;
                AppSettings.UserID = UserID.Text;
                await client.SendTextMessageAsync(UserID.Text, "Your authorization code: " + AppSettings.CheckCode.ToString() + ". If you shouldn't get this code, ignore this message");

                

                this.Frame.Navigate(typeof(LogIn.LoginPage2));
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
    }
}
