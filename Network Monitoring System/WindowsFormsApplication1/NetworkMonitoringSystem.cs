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
        public Device GetUserNetworkParametres()
        {
            return Net.GetLocalDevice();
        }
        public List<Device> GetNetworkDevice()
        {
            return Net.GetNetworkDevice();
        }
        public int SendMessagePackage(Device source, Device dest, string message)
        {
            PackageFactory factory = new PackageFactory();
            Package package = factory.CreateMessagePackage(source.IP, dest.IP, message);
            Net.SendPackage(package);
            return Net.ReceivePackage(package);
        }
        public int SendPingPackage(Device source, Device dest, string message)
        {
            PackageFactory factory = new PackageFactory();
            Package package = factory.CreatePingPackage(source.IP, dest.IP, message);
            Net.SendPackage(package);
            return Net.ReceivePackage(package);
        }
    }
}
