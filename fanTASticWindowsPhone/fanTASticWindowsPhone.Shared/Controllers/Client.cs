using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace fanTASticWindowsPhone.Models
{
    public class Client
    {
        HttpClient client;

        string address;

        public Client()
        {
            client = new HttpClient();
            address = "http://resty.azurewebsites.net";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public bool Login(LoginRequest request)
        {
            string body = JsonConvert.SerializeObject(request);
            HttpResponseMessage response = client.PostAsync(address + "/login", new StringContent(body, Encoding.UTF8, "application/json")).Result;
            return response.IsSuccessStatusCode;
        }

        public User getUser(string login)
        {
            string response = client.GetStringAsync(address + "/users/" + login).Result;
            User user = JsonConvert.DeserializeObject<User>(response);
            return user;
        }

        public bool Register(RegistrationRequest request)
        {
            string body = JsonConvert.SerializeObject(request);
            HttpResponseMessage response = client.PostAsync(address + "/users/" + request.Login, new StringContent(body, Encoding.UTF8, "application/json")).Result;
            return response.IsSuccessStatusCode;
        }

        public string getPosts(string login)
        {
            string posts;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            posts = client.GetStringAsync(address + "/users/" + login + "/posts/").Result;
            return posts;
        }

        public string getAll()
        {
            string posts;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            posts = client.GetStringAsync(address + "/posts/").Result;
            return posts;
        }

        public bool postPost(User user, Post post)
        {
            string body = JsonConvert.SerializeObject(post);
            HttpResponseMessage response = client.PostAsync(address + "/users/" + user.Login + "/posts/", new StringContent(body, Encoding.UTF8, "application/json")).Result;
            return response.IsSuccessStatusCode;
        }

        public bool updatePost(Post post)
        {
            string body = JsonConvert.SerializeObject(post);
            HttpResponseMessage response = client.PutAsync(address + "/posts/" + post.id, new StringContent(body, Encoding.UTF8, "application/json")).Result;
            return response.IsSuccessStatusCode;
        }

        ~Client()
        {
            client.Dispose();
        }
    }
}
