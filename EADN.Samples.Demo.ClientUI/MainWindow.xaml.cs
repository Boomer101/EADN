using EADN.Samples.Demo.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace EADN.Samples.Demo.ClientUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double setValue;

        private IClientChannel Proxy = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private T GetProxy<T>()
        {
            if(Proxy != null && Proxy.State == CommunicationState.Opened)
            {
                return (T)Proxy;
            }
            else if(Proxy != null && Proxy.State == CommunicationState.Faulted)
            {
                Proxy.Abort();
            }

            Proxy = ChannelFactory<T>.CreateChannel(
                new BasicHttpBinding(),
                new EndpointAddress("http://localhost:4711/DemoService")) as IClientChannel;

            //Proxy = ChannelFactory<T>.CreateChannel("ClientDeclarative");

            return (T)Proxy;
        }

        private void AppDomain_Clicked(object sender, RoutedEventArgs e)
        {
            IDemo proxy = GetProxy<IDemo>();
            AppDomainNameServer.Text =  proxy.GetApplicationDomainName();
        }

        private void SetValueButton_Clicked(object sender, RoutedEventArgs e)
        {
            double parseResult;

            if (double.TryParse(ValueEntry.Text, out parseResult))
            {
                setValue = parseResult;
            }
            else
            {
                setValue = 0d;
            }
            
            IDemo proxy = GetProxy<IDemo>();
            proxy.SetValue(setValue);
        }

        private void GetValueButton_Clicked(object sender, RoutedEventArgs e)
        {
            IDemo proxy = GetProxy<IDemo>();
            ValueRead.Text = proxy.GetValue().ToString();
        }

        private void NextEnumButton_Clicked(object sender, RoutedEventArgs e)
        {
            IDemo proxy = GetProxy<IDemo>();

            DemoEnum newEnum = proxy.NextValue((DemoEnum)EnumValue.SelectedValue);
            EnumValue.SelectedItem = newEnum;
        }

        private void FillinList_Clicked(object sender, RoutedEventArgs e)
        {
            DemoData data = new DemoData
            {
                //Date = DateTime.Now.Date,
                //Name = "Test"
            };

            try
            {
                var proxy = GetProxy<IDemo>();

                var List = proxy.Update(data, (int)setValue);
                foreach (var item in List)
                {
                    DataList.Items.Add(item);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Client Proxy Error:", MessageBoxButton.OK);
            }
            finally
            {
                var channelProxy = (IChannel)Proxy;

                if (channelProxy != null && channelProxy.State == CommunicationState.Opened)
                {
                    channelProxy.Close();
                }
            }
        }
    }
}
