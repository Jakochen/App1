using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1.TabPage2
{
    public partial class UpcomingAppointmentsPage : ContentPage
    {
        public UpcomingAppointmentsPage()
        {
            InitializeComponent();
        }

        async void OnBackButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
