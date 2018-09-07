using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;

namespace networkClientTestApp
{
    public class SimpleDownloader
    {

        public async Task downloadURLAsync(string url)
        {
            byte[] data;
            Uri uri = new Uri(url);

            try
            {
                HttpClient httpClient = new HttpClient();
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                string mediaType = response.Content.Headers.ContentType.MediaType.Split('/')[1];
                data = await response.Content.ReadAsByteArrayAsync();

            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }



    }
}
