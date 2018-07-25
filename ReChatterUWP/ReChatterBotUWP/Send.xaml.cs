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
    public sealed partial class Send : Page
    {
        private static TelegramBotClient client;
        public Send()
        {
            this.InitializeComponent();
            client = new TelegramBotClient(AppSettings.Key);
        }

        private async void Sendmessage(object sender, RoutedEventArgs e)
        {
            string messageText;
            var chatId = RName.Text;
            if (CheckBoxName.IsChecked == true)
            {
                messageText = AppSettings.UserName +": " + MessageText.Text;
            }
            else
            {
                messageText = MessageText.Text;
            }

            try
            {
                await client.SendTextMessageAsync(chatId, messageText);
            }
            catch(Exception ex)
            {
                SendButton.Content = "An error occurred: " + ex + ". Try again";
            }
        }

        private async void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (AppSettings.UserName == "")
            {
                ContentDialog UserEmpty = new ContentDialog()
                {
                    Title = "Username error",
                    Content = "Please, enter your name in Settings page",
                    CloseButtonText = "Cancel",
                    PrimaryButtonText = "Go to Settings"
                };
                UserEmpty.PrimaryButtonClick += GoToSettings;
                UserEmpty.CloseButtonClick += UserEmptyButtonClose;

                await UserEmpty.ShowAsync();
            }
        }

        private void GoToSettings(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            Frame.Navigate(typeof(Settings));
            CheckBoxName.IsChecked = false;
        }

        private void UserEmptyButtonClose(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            CheckBoxName.IsChecked = false;
        }
    }
}
