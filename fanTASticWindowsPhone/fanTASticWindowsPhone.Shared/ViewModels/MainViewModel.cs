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

        private Post currentPost;

        public Post CurrentPost
        {
            get { return currentPost; }
            set
            {
                currentPost = value;
                NotifyPropertyChanged();
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                NotifyPropertyChanged();
            }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                content = value;
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

        private ObservableCollection<Post> allpostCollection;

        public ObservableCollection<Post> AllPostCollection
        {
            get { return allpostCollection; }
            set
            {
                allpostCollection = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            PostCollection = new ObservableCollection<Post>();
            client = new Client();
            user = new User();
            filesaver = new FileSaver();
            CurrentPost = new Post();
        }

        public bool Login(string login, string password)
        {
            LoginRequest request = new LoginRequest { Login = login, Password = password };
            bool result = client.Login(request);
            if (result)
            {
                Name = login;
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
            RegistrationRequest request = new RegistrationRequest { Login = login, Password = password, Firstname = "Imię", Lastname = "Nazwisko",Avatar = "", Bio= "" };
            bool result = client.Register(request);
            if (result)
            {
                Name = login;
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
        public bool Logout()
        {
            Name = "";
            user = new User();
            PostCollection = new ObservableCollection<Post>();
            filesaver.deleteFile();
            return true;
        }
        public bool GetPosts()
        {
            string result = client.getPosts(user.Login);
            if(!String.IsNullOrEmpty(result))
            {
                PostCollection = JsonConvert.DeserializeObject<ObservableCollection<Post>>(result);
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool AddPost(string type)
        {
            bool result;
            if (type == "Send")
            {
                result = client.postPost(user, CurrentPost);
            }
            else
            {
                result = client.updatePost(CurrentPost);   
            }
            CurrentPost = new Post();
            Title = "";
            Content = "";
            return result;
        }
        public bool GetAll()
        {
            string result = client.getAll();
            if (!String.IsNullOrEmpty(result))
            {
                AllPostCollection = JsonConvert.DeserializeObject<ObservableCollection<Post>>(result);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
