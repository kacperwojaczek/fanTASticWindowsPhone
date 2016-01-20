using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace fanTASticWindowsPhone.Models
{
    public class FileSaver
    {
        public async void saveFile(string content)
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile dataFile = await storageFolder.CreateFileAsync("db.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            await Windows.Storage.FileIO.WriteTextAsync(dataFile, content);
        }

        public async Task<string> readFile()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile dataFile = await storageFolder.GetFileAsync("db.txt");
            string text = await Windows.Storage.FileIO.ReadTextAsync(dataFile);
            return text;
        }

        public async Task<bool> openFile()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            try
            {
                Windows.Storage.StorageFile dataFile = await storageFolder.GetFileAsync("db.txt");
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
