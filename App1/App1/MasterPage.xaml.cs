﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace App1
{
    public partial class MasterPage : ContentPage
    {
        public ListView MyListView
        {
            get
            {
                return this.listView;
            }
        }

        public MasterPage()
        {
            InitializeComponent();

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "XF 登入跳轉自訂頁面",
                Icon = "\uf00b",
            });

            masterPageItems.Add(new MasterPageItem
            {
                Title = "XF 控制項1",
                Icon = "\uf00b",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "XF 控制項2",
                Icon = "\uf044",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Grid版面配置",
                Icon = "\uf085",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "堆疊與捲動版面配置",
                Icon = "\uf009",
            });

            listView.ItemsSource = masterPageItems;
        }
    }
}
