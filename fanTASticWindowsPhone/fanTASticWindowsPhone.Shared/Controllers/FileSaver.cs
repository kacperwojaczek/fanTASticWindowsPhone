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
            var stream = await dataFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            using (var outputStream = stream.GetOutputStreamAt(0))
            {
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    dataWriter.WriteString(content);
                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose();
        }

        public async Task<string> readFile()
        {
            string text;

            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile dataFile = await storageFolder.GetFileAsync("db.txt");
            var stream = await dataFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            ulong size = stream.Size;
            using (var inputStream = stream.GetInputStreamAt(0))
            {
                using (var dataReader = new Windows.Storage.Streams.DataReader(inputStream))
                {
                    uint numBytesLoaded = await dataReader.LoadAsync((uint)size);
                    text = dataReader.ReadString(numBytesLoaded);
                    dataReader.Dispose();
                }
            }
            stream.Dispose();
            return text;
        }

        public async void deleteFile()
        {
            Windows.Storage.StorageFolder storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            Windows.Storage.StorageFile dataFile = await storageFolder.CreateFileAsync("db.txt", Windows.Storage.CreationCollisionOption.ReplaceExisting);
            var stream = await dataFile.OpenAsync(Windows.Storage.FileAccessMode.ReadWrite);
            using (var outputStream = stream.GetOutputStreamAt(0))
            {
                using (var dataWriter = new Windows.Storage.Streams.DataWriter(outputStream))
                {
                    dataWriter.WriteString("");
                    await dataWriter.StoreAsync();
                    await outputStream.FlushAsync();
                }
            }
            stream.Dispose();
        }
    }
}
