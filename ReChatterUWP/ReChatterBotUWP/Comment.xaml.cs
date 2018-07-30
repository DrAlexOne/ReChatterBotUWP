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
    public sealed partial class Comment : Page
    {
        private static TelegramBotClient client;

        public Comment()
        {
            this.InitializeComponent();
            client = new TelegramBotClient(AppSettings.Key);

        }

        private async void Sendmessage(object sender, RoutedEventArgs e)
        {
            var messageText = "Comment: " + MessageText.Text;
            var chatId = "547561865";
            try
            {
                await client.SendTextMessageAsync(chatId, messageText);
            }
            catch (Exception error)
            {
                SendButton.Content = error;
            }
        }
    }
}
