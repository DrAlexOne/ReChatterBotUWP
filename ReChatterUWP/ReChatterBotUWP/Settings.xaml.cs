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
                YourID.Text = "You are not authorized";
                YourIDB.Content = "Log in";
            }
        }

        private void UserNameApply(object sender, RoutedEventArgs e)
        {
            AppSettings.UserName = TextUserName.Text;
        }

        private void LogInButton(object sender, RoutedEventArgs e)
        {
            if (AppSettings.Logged == true)
            {
                AppSettings.Logged = false;
            }
            if (AppSettings.Logged == false)
            {
                Frame.Navigate(typeof(LoginPage1));
            }
        }
    }
}
//--------------------------------------
// Content, to make this file longer
// becouse GitHub cant detect that this project is C# project
//
//
//
//
//
//
//
//
//
//
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                    
//                                        
//
//                    
//
//
// End of content                     
//---------------------------------------------------

