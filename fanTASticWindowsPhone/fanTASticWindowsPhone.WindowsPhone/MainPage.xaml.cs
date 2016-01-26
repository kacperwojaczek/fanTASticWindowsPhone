using fanTASticWindowsPhone.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace fanTASticWindowsPhone
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
            
            DataContext = App.ViewModelLocator.MainViewModel;

        }

        private MainViewModel ViewModel
        {
            get
            {
                return DataContext as MainViewModel;
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Login(login.Text, password.Text) )
            {
                Frame.Navigate(typeof(SecondPage));
            }
            else
            {
                MessageDialog msgbox = new MessageDialog("Login failed");
                await msgbox.ShowAsync();
            }
        }

        private async void Register(object sender, RoutedEventArgs e)
        {
            if ( ViewModel.Register(login.Text, password.Text) )
            {
                Frame.Navigate(typeof(SecondPage));
            }
            else
            {
                MessageDialog msgbox = new MessageDialog("Registration failed");
                await msgbox.ShowAsync();
            }
        }
    }
}
