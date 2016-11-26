using EADN.Samples.Demo.Contracts;
using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Windows;
//using System.Windows.Data;

namespace EADN.Samples.Demo.ClientUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double setValue;

        private IDemo DemoProxy = null;

        private IElaborateService ElaboratePerSessionServiceProxy = null;

        public MainWindow()
        {
            InitializeComponent();
        }

        private T GetProxy<T>()
        {

            return GetProxy<T>((T)DemoProxy, new BasicHttpBinding(), "http://localhost:4711/DemoService");
        }
        public static T GetProxy<T>(T proxy, Binding binding, string address)
        {
            IClientChannel proxyImpl = proxy as IClientChannel;

            if (proxy != null && proxyImpl.State == CommunicationState.Opened)
            {
                return (T)proxy;
            }
            else if (proxy != null && proxyImpl.State == CommunicationState.Faulted)
            {
                proxyImpl.Abort();
            }
            proxy = ChannelFactory<T>.CreateChannel(
                binding,
                new EndpointAddress(address));
            return (T)proxy;

            // TODO
            // Proxy = ChannelFactory<T>.CreateChannel("ClientDeclarative");
            // Verschieben, raus aus dem UI Code
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

        private void Elaborate_Clicked(object sender, RoutedEventArgs e)
        {
            ElaboratePerSessionServiceProxy = GetProxy<IElaborateService>(
              ElaboratePerSessionServiceProxy,
              new NetTcpBinding(),
              "net.tcp://localhost:4712/ElaborateService");

            string result = ElaboratePerSessionServiceProxy.GetData("TEST");

            ElaborateValue.Text = result;
        }

        private void FillinList_Clicked(object sender, RoutedEventArgs e)
        {
            DemoData data = new DemoData
            {
                Date = DateTime.Now.Date,
                Name = "Test"
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
                var channelProxy = (IChannel)DemoProxy;

                if (channelProxy != null && channelProxy.State == CommunicationState.Opened)
                {
                    channelProxy.Close();
                }
            }
        }
      
    }
}
