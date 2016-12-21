using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class NetworkMonitoringSystem
    {
        public Network Net;
        public DeviceRepository Repository;
        public StatisticList Statistic;
        public NetworkMonitoringSystem(Network net)
        {
            Net = net;
            this.Statistic = new StatisticList(net);
        }
        public List<Device> GetStructDevice()
        {
            return Net.GetAllDevice();
        }
        public LocalDevice GetUserNetworkParametres()
        {
            return Net.GetLocalDevice();
        }
        public List<NetworkDevice> GetNetworkDevice()
        {
            return Net.GetNetworkDevice();
        }
        public int SendMessage(Device source, Device dest, string message)
        {
            MessageFactory factory = new MessageFactory();
            Package package = factory.CreatePackage(source.IP, dest.IP, message);
            Net.SendPackage(package);
            return Net.ReceivePackage(package);
        }
        public int SendPing(Device source, Device dest, string message)
        {
            PingFactory factory = new PingFactory();
            Package package = factory.CreatePackage(source.IP, dest.IP, message);
            Net.SendPackage(package);
            return Net.ReceivePackage(package);
        }
    }
}
