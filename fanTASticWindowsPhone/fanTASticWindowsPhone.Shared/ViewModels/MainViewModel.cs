using fanTASticWindowsPhone.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace fanTASticWindowsPhone.ViewModels
{
    public class MainViewModel : ViewModel
    {
        public Client client;

        public User user;

        public string name;

        private ObservableCollection<Post> postCollection;

        public ObservableCollection<Post> PostCollection
        {
            get { return postCollection; }
            set
            {
                postCollection = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            PostCollection = new ObservableCollection<Post>();
            client = new Client();
            user = new User();
        }

        public bool Login(string login, string password)
        {

            return true;
        }

        public bool Register(string login, string password)
        {

            return true;
        }
    }
}
