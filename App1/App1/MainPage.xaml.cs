﻿using Sockets.Plugin;
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
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class MainPage : MasterDetailPage
    {
        MasterPage fooMasterPage = new MasterPage();

        public MainPage()
        {
            InitializeComponent();
            this.Master = fooMasterPage;
            this.Detail = new NavigationPage(new LoginPage.LoginPage());

            fooMasterPage.MyListView.ItemSelected += OnItemSelected;
        }

        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if(item.Title == "XF 登入跳轉自訂頁面")
                {
                    Detail = new NavigationPage(new LoginPage.LoginPage());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "XF 控制項1")
                {
                    Detail = new NavigationPage(new NavigationDemo.DetailView1());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "XF 控制項2")
                {
                    Detail = new NavigationPage(new NavigationDemo.DetailView2());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "Grid版面配置")
                {
                    Detail = new NavigationPage(new NavigationDemo.DetailView3());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "堆疊與捲動版面配置")
                {
                    Detail = new NavigationPage(new NavigationDemo.DetailView4());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if(item.Title == "標籤式的樣板頁面")
                {
                    Detail = new NavigationPage(new TabPage.TabPage());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
                else if (item.Title == "標籤式的導覽頁面")
                {
                    Detail = new NavigationPage(new TabPage2.TabPage2());
                    var fooPage = this.Master;

                    fooMasterPage.MyListView.SelectedItem = null;
                    IsPresented = false;
                }
            }
        }
    }
}
