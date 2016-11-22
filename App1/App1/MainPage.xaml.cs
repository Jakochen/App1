using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnRESTfulClicked(object sender, EventArgs e)
        {
            try
            {

                var address = "172.20.159.13";
                var port = 8807;
                var r = new Random();

                var client = new TcpSocketClient();
                await client.ConnectAsync(address, port);

                // we're connected!
                for (int i = 0; i < 5; i++)
                {
                    // write to the 'WriteStream' property of the socket client to send data
                    var nextByte = (byte)r.Next(0, 254);
                    client.WriteStream.WriteByte(nextByte);
                    await client.WriteStream.FlushAsync();

                    // wait a little before sending the next bit of data
                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                }

                await client.DisconnectAsync();
            }
            catch(Exception ex)
            {
                await DisplayAlert("INFO",ex.ToString(),"");
            }
        }
    }
}
