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

namespace ReChatterBotUWP.LogIn
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class LoginPage2 : Page
    {
        public LoginPage2()
        {
            this.InitializeComponent();
            NameByIdText.Text = AppSettings.UserID;
        }

        private async void CheckCodeButton(object sender, RoutedEventArgs e)
        {
            if (CodeCheck.Text == AppSettings.CheckCode.ToString())
            {
                this.Frame.Navigate(typeof(Logged));
            }
            else
            {
                ContentDialog ErrorDialog = new ContentDialog()
                {
                    Title = "Invalid code",
                    Content = "You have entered wrong code",
                    CloseButtonText = "OK"
                };

                await ErrorDialog.ShowAsync();
            }
        }

        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            await AppSettings.client.SendTextMessageAsync(AppSettings.UserID, "Your authorization code: " + AppSettings.CheckCode + ". If you shouldn't get this code, ignore this message");

        }
    }
}
