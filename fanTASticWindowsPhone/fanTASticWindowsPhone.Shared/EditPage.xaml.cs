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
    public sealed partial class EditPage : Page
    {
        public EditPage()
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
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Post post = e.Parameter as Post;
            SendButton.Content = "Send";
            if (post != null)
            {
                ViewModel.CurrentPost = post;
                ViewModel.Title = post.title;
                ViewModel.Content = post.content;
                SendButton.Content = "Update";
            }
        }

        private async void Send(object sender, RoutedEventArgs e)
        {
            ViewModel.CurrentPost.title = TitleBox.Text;
            ViewModel.CurrentPost.content = ContentBox.Text;
            if(!ViewModel.AddPost(SendButton.Content.ToString()))
            {
                MessageDialog msgbox = new MessageDialog("Operation failed");
                await msgbox.ShowAsync();
            }
            else
            {
                MessageDialog msgbox = new MessageDialog("Operation successful");
                await msgbox.ShowAsync();
                Frame.Navigate(typeof(SecondPage));
            }
        }


    }
}
