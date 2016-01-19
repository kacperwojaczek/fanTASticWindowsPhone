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
            address = "http://ipsume2.azurewebsites.net/";
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /*
        public bool addPost()
        {
            string body = JsonConvert.SerializeObject(task);
            HttpResponseMessage response = client.PostAsync(address, new StringContent(body, Encoding.UTF8, "application/json")).Result;
            bool retVal = response.IsSuccessStatusCode;
            return retVal;
        }
        */

        /*

        public string getTasks()
        {
            string Tasks;
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Tasks = client.GetStringAsync(address).Result;
            return Tasks;
        }

         */

        /*public string getTask(int id)
        {
            string Task = "b";
            return Task;
        }*/

        /*
        public bool removeTask(int id)
        {
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.DeleteAsync(address + "/" + id).Result;
            return response.IsSuccessStatusCode;
        }
        */

        /*
        public bool updateTask(TodoTask task)
        {
            string body = JsonConvert.SerializeObject(task);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.PutAsync(address + "/" + task.id, new StringContent(body, Encoding.UTF8, "application/json")).Result;
            return response.IsSuccessStatusCode;
        }
        */

        ~Client()
        {
            client.Dispose();
        }
    }
}
