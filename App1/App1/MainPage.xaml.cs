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

namespace App1
{
    public partial class MainPage : ContentPage
    {

        TcpSocketClient client = new TcpSocketClient();

        public MainPage()
        {
            InitializeComponent();
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
                if(port == 0)
                {
                    return;
                }

                await client.ConnectAsync(address, port);
                //// we're connected!
                //for (int i = 0; i < 5; i++)
                //{
                //    // write to the 'WriteStream' property of the socket client to send data
                //    var nextByte = (byte)r.Next(0, 254);
                //    client.WriteStream.WriteByte(nextByte);
                //    await client.WriteStream.FlushAsync();

                //    // wait a little before sending the next bit of data
                //    await Task.Delay(TimeSpan.FromMilliseconds(500));
                //}                
            }
            catch (Exception ex)
            {
                await DisplayAlert("INFO", ex.ToString(), "");
            }
        }


        private async void OnDisConnectClicked(object sender, EventArgs e)
        {
            await client.DisconnectAsync();
        }

            //private void InitView()
            //{
            //    Content = new StackLayout()
            //    {
            //        Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0),
            //        Children =
            //        {
            //            new ClientConnectView("172.20.159.13", 8807, this)
            //            {
            //                ConnectTapped = async (s, i) =>
            //                {
            //                    await _client.ConnectAsync(s, i);
            //                    _canceller = new CancellationTokenSource();
            //
            //                    Task.Factory.StartNew(() =>
            //                    {
            //                        foreach (var msg in _client.ReadStrings(_canceller.Token))
            //                        {
            //                            _messagesSub.OnNext(msg);
            //                        }
            //                    }, TaskCreationOptions.LongRunning);
            //
            //                    return true;
            //                },
            //                DisconnectTapped = async () =>
            //                {
            //                    var bytes = Encoding.UTF8.GetBytes("<EOF>");
            //                    await _client.WriteStream.WriteAsync(bytes, 0, bytes.Length);
            //                    await _client.WriteStream.FlushAsync();
            //
            //                    _canceller.Cancel();
            //                    await _client.DisconnectAsync();
            //                }
            //            },
            //            new MessagesView(_messagesObs, true)
            //            {
            //                SendData = async s =>
            //                {
            //                    await _client.WriteStringAsync(s);
            //
            //                    return new Message
            //                    {
            //                        Text = s,
            //                        DetailText = String.Format("Sent at {0}", DateTime.Now.ToString("HH:mm:ss"))
            //                    };
            //                }
            //            }
            //        }
            //    };
            //}
        }
}
