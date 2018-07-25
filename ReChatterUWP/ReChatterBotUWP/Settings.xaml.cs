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

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace ReChatterBotUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class Settings : Page
    {
        public Settings()
        {
            this.InitializeComponent();
            if (AppSettings.Logged == true)
            {
                YourID.Text = "Your ID:" + AppSettings.UserID;
                YourIDB.Content = "Log out";
            }
            else
            {
                YourID.Text = "You are not authorized" + AppSettings.UserID;
                YourIDB.Content = "Log in";
            }
        }

        private async void ToggleSwitch_Toggled(object sender, RoutedEventArgs e)
        {
            if (BotHostingSwitch.IsOn == false)
            {
                ContentDialog BotHostingDialog = new ContentDialog()
                {
                    Title = "Bot Hosting problem",
                    Content = "Please, leave this switcher togged on, if you using unlimited networks",
                    CloseButtonText = "Turn off",
                    PrimaryButtonText = "Leave on"
                };

                BotHostingDialog.CloseButtonClick += BotHostingDialogClose;
                BotHostingDialog.PrimaryButtonClick += BotHostingDialogPrimary;

                await BotHostingDialog.ShowAsync();
            }
        }

        private void BotHostingDialogClose(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            BotHostingSwitch.IsOn = false;
        }

        private void BotHostingDialogPrimary(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            BotHostingSwitch.IsOn = true;
        }

        private void UserNameApply(object sender, RoutedEventArgs e)
        {
            AppSettings.UserName = TextUserName.Text;
        }
    }
}
