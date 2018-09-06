using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Networking;
using Windows.Networking.Sockets;

namespace networkClientTestApp
{
    public class SimpleDownloader
    {

        public async Task initAsync()
        {
            // Define some variables and set values
            StreamSocket clientSocket = new StreamSocket();

            HostName serverHost = new HostName("www.microsoft.com");
            string serverServiceName = "https";

            // For simplicity, the sample omits implementation of the
            // NotifyUser method used to display status and error messages 

            // Try to connect to contoso using HTTPS (port 443)
            try
            {

                // Call ConnectAsync method with SSL
                await clientSocket.ConnectAsync(serverHost, serverServiceName, SocketProtectionLevel.Ssl);

                NotifyUser("Connected");
            }
            catch (Exception exception)
            {
                // If this is an unknown status it means that the error is fatal and retry will likely fail.
                if (SocketError.GetStatus(exception.HResult) == SocketErrorStatus.Unknown)
                {
                    throw;
                }

                NotifyUser("Connect failed with error: " + exception.Message);
                // Could retry the connection, but for this simple example
                // just close the socket.

                clientSocket.Dispose();
                clientSocket = null;
            }

            // Add code to send and receive data using the clientSocket


            // Close the clientSocket
            clientSocket.Dispose();
            clientSocket = null;
        }

        private void NotifyUser(string v)
        {
            Debug.WriteLine(v);
        }
    }
}
