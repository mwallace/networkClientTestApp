using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;

namespace networkClientTestApp
{
    public class SimpleDownloader
    {

        public async Task initAsync()
        {
            byte[] data;
            string url = "https://www.microsoft.com";
            Uri uri = new Uri(url);

            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                string mediaType = response.Content.Headers.ContentType.MediaType.Split('/')[1];
                data = await response.Content.ReadAsByteArrayAsync();
                foreach (var ch in data)
                {
                    Debug.Write((char)ch);
                }
                
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }



    }
}
