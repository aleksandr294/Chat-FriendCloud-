using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using ClientFriendCloud.ServiceChat;
namespace ClientFriendCloud
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window, IServiceChatCallback
    {
        ServiceChatClient client;
        int ID;
        string login;
        bool isConnected=false;
        MainWindow windows = new MainWindow();
        public Window1()
        {
            InitializeComponent();
            content.ImageSource = new BitmapImage(new Uri("Media/лого.png", UriKind.Relative));
        }
        void Connect()
        {
            if(!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(TB.Text);
                TB.IsEnabled = false;
                TextBloc.Text= "Вихід";
                isConnected = true;
            }
        }

        void Disconnect()
        {
            if (isConnected)
            {
                client.Disconnect(ID);
                client = null;
                TB.IsEnabled = true;
                TextBloc.Text = "Вхід";
                isConnected = false;
            }
        }
        public void MsgCallback(string msg)
        {
            listBox.Items.Add(msg);
            listBox.ScrollIntoView(listBox.Items[listBox.Items.Count - 1]);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            // client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
            //login = windows.login;
            //ID=client.Connect(login);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Disconnect();
        }

        private void author_Click(object sender, RoutedEventArgs e)
        {
            Window2 win = new Window2();
            win.Show();
           
        }

        private void Exit_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void entrance_Click(object sender, RoutedEventArgs e)
        {
            if(isConnected)
            {
                Disconnect();
            }
            else
            {
                Connect();
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if(client!=null)
            {
                client.SendMsg(textBox.Text, ID);
                textBox.Text = string.Empty;
            }
        }

        private void HamburgerMenuItem_Selected(object sender, RoutedEventArgs e)
        {
            content.ImageSource = new BitmapImage(new Uri("Media/лого.png", UriKind.Relative));

        }

        private void HamburgerMenuItem_Selected_1(object sender, RoutedEventArgs e)
        {
            content.ImageSource = new BitmapImage(new Uri("Media/art-fantaziya-nebo-oblaka-noch.jpg", UriKind.Relative));
        }

        private void HamburgerMenuItem_Selected_2(object sender, RoutedEventArgs e)
        {
            content.ImageSource = new BitmapImage(new Uri("Media/Тема2.jpg", UriKind.Relative));
           
        }
    }
}
