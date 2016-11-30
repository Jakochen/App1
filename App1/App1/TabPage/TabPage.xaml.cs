using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
//using Xamarin.Forms.Xaml;

//[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1.TabPage
{
    public partial class TabPage : TabbedPage
    {
        public TabPage()
        {
            InitializeComponent();
            ItemsSource = MonkeyDataModel.All;
        }
    }
}
