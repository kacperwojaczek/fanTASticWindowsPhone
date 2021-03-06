﻿using fanTASticWindowsPhone.ViewModels;
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
            DataContext = App.ViewModelLocator.MainViewModel;

        }



        private MainViewModel ViewModel
        {
            get
            {
                return DataContext as MainViewModel;
            }
        }

        private async void Login(object sender, RoutedEventArgs e)
        {
            if (ViewModel.Login(login.Text, password.Password))
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
            if (ViewModel.Register(login.Text, password.Password))
            {
                Frame.Navigate(typeof(SecondPage));
            }
            else
            {
                MessageDialog msgbox = new MessageDialog("Registration failed");
                await msgbox.ShowAsync();
            }
        }

        private void Continue(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(PublicWall));
        }
    }
}
