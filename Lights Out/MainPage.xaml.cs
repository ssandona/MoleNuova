using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using System.IO;
using System.Runtime.Serialization;
using PhoneApp1;
<<<<<<< HEAD
=======
using Lights_Out.ViewModel;
>>>>>>> Button game.xaml


namespace Lights_Out
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
<<<<<<< HEAD
            Test();
=======
            //Test();
            LivelliVM lvm = new LivelliVM();
>>>>>>> Button game.xaml
        }


        private void Inizia_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PagLivelli.xaml", UriKind.Relative));
        }

       

        public static void Test()
        {
            // serialization
            MemoryStream ms = new MemoryStream();
            DataContractSerializationHelper.Serialize(ms, new Livello(1));
            /*
            ms.Position = 0;
            // deserialization
            var sampleData = DataContractSerializationHelper.Deserialize(ms, typeof(Livello));
            */
            ms.Close();
        }
    }

}