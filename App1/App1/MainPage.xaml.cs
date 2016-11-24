using Sockets.Plugin;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;
using Sockets.Plugin.Abstractions;

namespace App1
{
    public partial class MainPage : ContentPage
    {
        List<ITcpSocketClient> _clients = new List<ITcpSocketClient>();

        TcpSocketClient client = new TcpSocketClient();
        CancellationTokenSource _canceller;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetBackButtonTitle(this, "回到首頁");
        }

        private async void OnSendClicked(object sender, EventArgs e)
        {
            string s_code = entryArduinoCode.Text;
            await client.WriteStringAsync(s_code, "$"); //$ 結束符號
        }

        private async void OnConnectClicked(object sender, EventArgs e)
        {
            try
            {
                //string address = "172.20.159.13";
                //int port = 8807;
                string address = entryIp.Text;
                int port = 0;
                int.TryParse(entryPort.Text, out port);
                if (port == 0)
                {
                    return;
                }

                await client.ConnectAsync(address, port);
                await client.WriteStringAsync("Client Connected", "$");
            }
            catch (Exception ex)
            {
                await DisplayAlert("INFO", ex.ToString(), "");
            }
        }


        private async void OnDisConnectClicked(object sender, EventArgs e)
        {
            //var bytes = Encoding.UTF8.GetBytes("$");
            //await client.WriteStream.WriteAsync(bytes, 0, bytes.Length);
            //await client.WriteStream.FlushAsync();
            await client.WriteStringAsync("Disconnect", "$"); //$ 結束符號
            await client.DisconnectAsync();
        }
    }
}
