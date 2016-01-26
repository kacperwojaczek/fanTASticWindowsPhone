using fanTASticWindowsPhone.Models;
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
    public sealed partial class SecondPage : Page
    {
        public SecondPage()
        {
            this.InitializeComponent();
            DataContext = App.ViewModelLocator.MainViewModel;

        }

        private MainViewModel ViewModel
        {
            get
            {
                return DataContext as MainViewModel;
            }
        }

        private async void Logout(object sender, RoutedEventArgs e)
        {
            if(ViewModel.Logout())
            {
                Frame.Navigate(typeof(MainPage));
            }
            else
            {
                MessageDialog msgbox = new MessageDialog("Logout failed");
                await msgbox.ShowAsync();
            }
        }

        private void SelectPost(object sender, SelectionChangedEventArgs e)
        {
            Post post = (Post) e.AddedItems.ElementAt(0);
            Frame.Navigate(typeof(EditPage), post);
        }

        private async void Refresh(object sender, RoutedEventArgs e)
        {
            if(!ViewModel.GetPosts())
            {
                MessageDialog msgbox = new MessageDialog("Cannot get posts");
                await msgbox.ShowAsync();
            }
        }

        private void Add(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(EditPage), null);
        }
    }
}
