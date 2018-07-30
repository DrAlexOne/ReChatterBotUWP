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
using ReChatterBotUWP;
using Windows.ApplicationModel.Core;
using Windows.UI.ViewManagement;
using Windows.UI;
using ReChatterBotUWP.LogIn;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace ReChatterBotUWP
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(Send));

            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;

            var viewTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            viewTitleBar.ButtonBackgroundColor = Colors.Transparent;
            viewTitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            viewTitleBar.ButtonForegroundColor = (Color)Resources["SystemBaseHighColor"];

            var full = (ApplicationView.GetForCurrentView().IsFullScreenMode);
            var left = 12 + (full ? 0 : CoreApplication.GetCurrentView().TitleBar.SystemOverlayLeftInset);
            AppTitle.Margin = new Thickness(left, 8, 0, 0);

            Logged();
        }

        private void SendPage(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Send));
        }

        private void ReceivedPage(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Received));
        }

        private void CommentPage(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Comment));
        }

        private void InfoPage(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Info));
        }

        private void SettingsPage(object sender, TappedRoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(Settings));
        }

        async void Logged()
        {
            if (AppSettings.Logged == false)
            {
                AuthorizeDialog LoginD = new AuthorizeDialog();
                await LoginD.ShowAsync();

                if (LoginD.Result == SignInResult.SignInOK)
                {
                    this.Frame.Navigate(typeof(LoginPage1));
                }
            }
        }

        private void MainPage_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (MPage.Width > 560)
            {
                AppTitle.Visibility = Visibility.Visible;
            }
            if (MPage.Width < 560)
            {
                Console.WriteLine("1");
            }
        }
        private void NavView_PaneOpened(NavigationView sender, object args)
        {
            AppTitle.Visibility = Visibility.Visible;
        }

        private void NavView_PaneClosed(NavigationView sender, object args)
        {
            AppTitle.Visibility = Visibility.Collapsed;
        }
    }
}
