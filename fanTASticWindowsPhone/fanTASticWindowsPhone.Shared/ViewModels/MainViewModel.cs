using fanTASticWindowsPhone.Models;
using Newtonsoft.Json;
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

        public FileSaver filesaver;

        private string name;

        public string Name
        {
            get { return name;  }
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

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
            filesaver = new FileSaver();
        }

        public bool Login(string login, string password)
        {
            LoginRequest request = new LoginRequest { Login = login, Password = password };
            bool result = client.Login(request);
            if (result)
            {
                Name = user.Login;
                user = client.getUser(login);
                filesaver.saveFile(JsonConvert.SerializeObject(user));
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Register(string login, string password)
        {
            RegistrationRequest request = new RegistrationRequest { Login = login, Password = password, Email = "Email", Firstname = "Imię", Lastname = "Nazwisko" };
            bool result = client.Register(request);
            if (result)
            {
                Name = user.Login;
                user = client.getUser(login);
                filesaver.saveFile(JsonConvert.SerializeObject(user));
                //marek.banaszak@allegrogroup.com
                //dawid.mackowiak@allegrogroup.com
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
