﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Lights_Out.ViewModel;

namespace Lights_Out
{
    public partial class Game : PhoneApplicationPage
    {
        public Game()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string liv = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("id", out liv))
            {

                b00.Content = liv;
                int a = Convert.ToInt32(liv);

                int a = Convert.ToInt32(liv);
                this.DataContext = new LivelloVM(a);

            }
        }
    }
}