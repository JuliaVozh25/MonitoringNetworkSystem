using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Test
{
    public class NetworkTesting
    {
        WindowsFormsApplication1.Network Net;
        WindowsFormsApplication1.PackageFactory factory;
        WindowsFormsApplication1.Package package;
        [SetUp]
        public void BeforeTest()
        {
            Net = new WindowsFormsApplication1.Network();
            factory = new WindowsFormsApplication1.PackageFactory();
            package = factory.CreatePingPackage("192.168.0.25", "192.168.0.221", "");
        }
        [Test]
        public void TestCreateNetwork()
        {
            Assert.That(Net, Is.TypeOf(typeof(WindowsFormsApplication1.Network)));
            Assert.That(Net.Devices, Is.Not.Empty);
           
        }
        [Test]
        public void TestGetAllDevice()
        {
            List<WindowsFormsApplication1.Device> alldevice = Net.GetAllDevice();
            Assert.IsNotEmpty(alldevice);
            Assert.That(alldevice,Is.All.InstanceOf(typeof(WindowsFormsApplication1.Device)));
        }
        [Test]
        public void TestGetLocalDevice()
        {
            WindowsFormsApplication1.Device localdevice = Net.GetLocalDevice();
            Assert.IsNotNull(localdevice);
        }
        [Test]
        public void TestGetNetworkDevice()
        {
            List<WindowsFormsApplication1.Device> netdevice = Net.GetNetworkDevice();
            Assert.IsNotEmpty(netdevice);
            Assert.That(netdevice, Is.All.InstanceOf(typeof(WindowsFormsApplication1.Device)));
            Assert.That(netdevice, Is.All.TypeOf(typeof(WindowsFormsApplication1.NetworkDevice)));
        }
        [Test]
        public void TestSendPackage()
        {
            Assert.IsNotNullOrEmpty(package.SourceAddress);
            Assert.IsNotNullOrEmpty(package.DestAddress);
        }
    }
    public class NetworkMonitoringSystemTesting
    {
        WindowsFormsApplication1.Network Net;
        WindowsFormsApplication1.NetworkMonitoringSystem System;
        WindowsFormsApplication1.LocalDevice source;
        WindowsFormsApplication1.NetworkDevice destination;
        WindowsFormsApplication1.Device local;
        [SetUp]
        public void BeforeTest()
        {
            Net = new WindowsFormsApplication1.Network();
            System = new WindowsFormsApplication1.NetworkMonitoringSystem(Net);
            local = System.GetUserNetworkParametres();
            source = new WindowsFormsApplication1.LocalDevice("Компьютер", "User1", "192.168.0.25");
            destination = new WindowsFormsApplication1.NetworkDevice("Компьютер", "Acer", "192.168.0.221");
        }
        [Test]
        public void TestStructure()
        {
            Assert.That(System.GetStructDevice(), Is.Not.Empty);
            Assert.That(System.GetStructDevice(), Is.Unique);
        }
        [Test]
        public void TestUserParametrs()
        {
            Assert.That(System.GetUserNetworkParametres(), Is.Not.Null);
            Assert.That(System.GetStructDevice(), Has.Member(local));
        }
        [Test]
        public void TestNetworkDevice()
        {
            Assert.That(System.GetNetworkDevice(), Is.Not.Empty);
        }
        [Test]
        public void TestSendMessagePackage()
        {
            int time = System.SendMessagePackage(source, destination, "test");
            Assert.GreaterOrEqual(time, 0);
        }
    }
    public class DeviceTesting
    {
        WindowsFormsApplication1.LocalDevice local;
        WindowsFormsApplication1.NetworkDevice network;
        [SetUp]
        public void BeforeTest()
        {
            local = new WindowsFormsApplication1.LocalDevice("Компьютер", "User1", "192.168.0.25");
            network = new WindowsFormsApplication1.NetworkDevice("Компьютер", "Acer", "192.168.0.221");
        }
        [Test]
        public void TestCreateDevice()
        {
            Assert.That(local, Is.InstanceOf(typeof(WindowsFormsApplication1.Device)));
            Assert.That(local, Is.TypeOf(typeof(WindowsFormsApplication1.LocalDevice)));
            Assert.That(network, Is.InstanceOf(typeof(WindowsFormsApplication1.Device)));
            Assert.That(network, Is.TypeOf(typeof(WindowsFormsApplication1.NetworkDevice)));
            Assert.That(local.IP, Is.Not.Empty);
            Assert.That(network.IP, Is.Not.Empty);
        }
        [Test]
        public void TestTypeDevice()
        {
            Assert.That(local.deviceType, Is.EqualTo(WindowsFormsApplication1.Device.DeviceType.LocalDevice));
            Assert.That(network.deviceType, Is.EqualTo(WindowsFormsApplication1.Device.DeviceType.NetworkDevice));
        }
    }
    public class DeviceRepositoryTesting
    {
        List<WindowsFormsApplication1.Device> devices;
        WindowsFormsApplication1.Query queryip;
        WindowsFormsApplication1.Query querytype;
        WindowsFormsApplication1.DeviceRepository devicerepos;
        [SetUp]
        public void BeforeTest()
        {
            WindowsFormsApplication1.Network network = new WindowsFormsApplication1.Network();
            WindowsFormsApplication1.NetworkMonitoringSystem system = new WindowsFormsApplication1.NetworkMonitoringSystem(network);
            devices = system.GetStructDevice();
            devicerepos = new WindowsFormsApplication1.DeviceRepository(devices);
        }
        [Test]
        public void TestCreateDeviceRepository()
        {
            Assert.That(devicerepos, Is.TypeOf(typeof(WindowsFormsApplication1.DeviceRepository)));
            Assert.That(devicerepos, Is.Not.Null); 
        }
        [Test]
        public void TestGetStructure()
        {
            queryip = new WindowsFormsApplication1.IPQuery("192.168.0.25");
            querytype = new WindowsFormsApplication1.TypeQuery("Компьютер");
            Assert.That(devicerepos.GetStructure(queryip),Is.Not.Empty);
            Assert.That(devicerepos.GetStructure(querytype), Is.Not.Empty);
            queryip = new WindowsFormsApplication1.IPQuery("321.543.0000.25");
            querytype = new WindowsFormsApplication1.TypeQuery("");
            Assert.That(devicerepos.GetStructure(queryip.And(querytype)), Is.Empty);
            queryip = new WindowsFormsApplication1.IPQuery("");
            querytype = new WindowsFormsApplication1.TypeQuery("Тест");
            Assert.That(devicerepos.GetStructure(querytype.Or(queryip)), Is.Not.Empty);
        }
    }
    public class ParametresTesting
    {
        WindowsFormsApplication1.NetworkMonitoringSystem system;
        WindowsFormsApplication1.Network Net;
        List<WindowsFormsApplication1.IObserver> netobserver;
        [SetUp]
        public void BeforeTest()
        {
            Net = new WindowsFormsApplication1.Network();
            system = new WindowsFormsApplication1.NetworkMonitoringSystem(Net);
            netobserver = Net.Observers;
        }
        [Test]
        public void TestCreateStatisticList()
        {
            Assert.That(system.Statistic, Is.TypeOf(typeof(WindowsFormsApplication1.StatisticList)));
        }
        [Test]
        public void TestRegistrObserveble()
        {
            Assert.That(netobserver, Has.Member(system.Statistic));
        }
        [Test]
        public void TestStopTradeObservable()
        {
            system.Statistic.StopTrade();
            Assert.That(netobserver, Has.No.Member(system.Statistic));
        }
    }
    public class PackageTesting
    {
        WindowsFormsApplication1.PackageFactory factory;
        WindowsFormsApplication1.Package messpackage;
        WindowsFormsApplication1.Package pingpackage;
        [SetUp]
        public void BeforeTest()
        {
            factory = new WindowsFormsApplication1.PackageFactory();
            messpackage = factory.CreateMessagePackage("1.1.1.1", "2.2.2.2", "test");
            pingpackage = factory.CreatePingPackage("3.3.3.3", "4.4.4.4", "");
        }
        [Test]
        public void TestCreatePackage()
        {
            Assert.That(factory, Is.InstanceOf(typeof(WindowsFormsApplication1.AbstractFactory)));
            Assert.That(factory, Is.TypeOf(typeof(WindowsFormsApplication1.PackageFactory)));
            Assert.That(messpackage, Is.TypeOf(typeof(WindowsFormsApplication1.MessagePackage)));
            Assert.That(messpackage, Is.InstanceOf(typeof(WindowsFormsApplication1.Package)));
            Assert.That(pingpackage, Is.TypeOf(typeof(WindowsFormsApplication1.PingPackage)));
            Assert.That(pingpackage, Is.InstanceOf(typeof(WindowsFormsApplication1.Package)));
        }
        [Test]
        public void TestIpAddr()
        {
            Assert.That(pingpackage.SourceAddress, Is.Not.Empty);
            Assert.That(pingpackage.DestAddress, Is.Not.Empty);
            Assert.That(messpackage.SourceAddress, Is.Not.Empty);
            Assert.That(messpackage.DestAddress, Is.Not.Empty);
        }
        [Test]
        public void TestToString()
        {
            Assert.That(pingpackage.ToString(), Is.EqualTo("ICMP"));
            Assert.That(messpackage.ToString(), Is.EqualTo("TCP"));
        }
    }
    public class TestQuery
    {
        WindowsFormsApplication1.Query query;
        WindowsFormsApplication1.Query query1;
        WindowsFormsApplication1.Query query2;
        WindowsFormsApplication1.Query query3;
        WindowsFormsApplication1.Device device1;
        WindowsFormsApplication1.Parametres parametr1;
        WindowsFormsApplication1.Device device2;
        WindowsFormsApplication1.Parametres parametr2;
        [SetUp]
        public void BeforeTest()
        {
            device1 = new WindowsFormsApplication1.LocalDevice("Компьютер", "User", "1.1.1.1");
            device2 = new WindowsFormsApplication1.LocalDevice("Принтер", "User", "2.2.2.2");
            parametr1 = new WindowsFormsApplication1.Parametres("1.1.1.1", "2.2.2.2", 20, "TCP", "");
            parametr2 = new WindowsFormsApplication1.Parametres("1.3.1.3", "2.1.2.1", 20, "ICMP", "");
        }
        [Test]
        public void TestCreateIPQuery()
        {
            query = new WindowsFormsApplication1.IPQuery("1.1.1.1");
            Assert.That(query,Is.Not.Null);
            Assert.That(query,Is.InstanceOf(typeof(WindowsFormsApplication1.Query)));
            Assert.That(query, Is.TypeOf(typeof(WindowsFormsApplication1.IPQuery)));
            Assert.That(query.IsSatisfiedBy(device1), Is.True);
            Assert.That(query.IsSatisfiedBy(device2), Is.False);
            query = new WindowsFormsApplication1.IPQuery("");
            Assert.That(query.IsSatisfiedBy(device1), Is.True);
            Assert.That(query.IsSatisfiedBy(device2), Is.True);
        }
        [Test]
        public void TestCreateTypeQuery()
        {
            query = new WindowsFormsApplication1.TypeQuery("Компьютер");
            Assert.That(query, Is.Not.Null);
            Assert.That(query, Is.InstanceOf(typeof(WindowsFormsApplication1.Query)));
            Assert.That(query, Is.TypeOf(typeof(WindowsFormsApplication1.TypeQuery)));
            Assert.That(query.IsSatisfiedBy(device1), Is.True);
            Assert.That(query.IsSatisfiedBy(device2), Is.False);
            query = new WindowsFormsApplication1.TypeQuery("");
            Assert.That(query.IsSatisfiedBy(device1), Is.True);
            Assert.That(query.IsSatisfiedBy(device2), Is.True);
        }
        [Test]
        public void TestCreateSourceQuery()
        {
            query = new WindowsFormsApplication1.SourceQuery("1.1.1.1");
            Assert.That(query, Is.Not.Null);
            Assert.That(query, Is.InstanceOf(typeof(WindowsFormsApplication1.Query)));
            Assert.That(query, Is.TypeOf(typeof(WindowsFormsApplication1.SourceQuery)));
            Assert.That(query.IsSatisfiedBy(parametr1), Is.True);
            Assert.That(query.IsSatisfiedBy(parametr2), Is.False);
            query = new WindowsFormsApplication1.SourceQuery("");
            Assert.That(query.IsSatisfiedBy(parametr1), Is.True);
            Assert.That(query.IsSatisfiedBy(parametr2), Is.True);
        }
        [Test]
        public void TestCreateDestQuery()
        {
            query = new WindowsFormsApplication1.DestQuery("2.2.2.2");
            Assert.That(query, Is.Not.Null);
            Assert.That(query, Is.InstanceOf(typeof(WindowsFormsApplication1.Query)));
            Assert.That(query, Is.TypeOf(typeof(WindowsFormsApplication1.DestQuery)));
            Assert.That(query.IsSatisfiedBy(parametr1), Is.True);
            Assert.That(query.IsSatisfiedBy(parametr2), Is.False);
            query = new WindowsFormsApplication1.DestQuery("");
            Assert.That(query.IsSatisfiedBy(parametr1), Is.True);
            Assert.That(query.IsSatisfiedBy(parametr2), Is.True);
        }
        [Test]
        public void TestCreateProtocolQuery()
        {
            query = new WindowsFormsApplication1.ProtocolQuery("TCP");
            Assert.That(query, Is.Not.Null);
            Assert.That(query, Is.InstanceOf(typeof(WindowsFormsApplication1.Query)));
            Assert.That(query, Is.TypeOf(typeof(WindowsFormsApplication1.ProtocolQuery)));
            Assert.That(query.IsSatisfiedBy(parametr1), Is.True);
            Assert.That(query.IsSatisfiedBy(parametr2), Is.False);
            query = new WindowsFormsApplication1.ProtocolQuery("");
            Assert.That(query.IsSatisfiedBy(parametr1), Is.True);
            Assert.That(query.IsSatisfiedBy(parametr2), Is.True);
        }
        [Test]
        public void TestQueryParametres()
        {
            query1 = new WindowsFormsApplication1.SourceQuery("1.1.1.1");
            query2 = new WindowsFormsApplication1.DestQuery("2.2.2.2");
            query3 = new WindowsFormsApplication1.ProtocolQuery("ICMP");
            Assert.That(query1.Or(query2.Or(query3)).IsSatisfiedBy(parametr1), Is.True);
            Assert.That(query1.And(query2.And(query3)).IsSatisfiedBy(parametr1), Is.False);
            Assert.That(query1.Or(query2.And(query3)).IsSatisfiedBy(parametr2), Is.False);
            query1 = new WindowsFormsApplication1.SourceQuery("1.3.1.3");
            Assert.That(query1.And(query2.Or(query3)).IsSatisfiedBy(parametr2), Is.True);
        }
        [Test]
        public void TestQueryDevice()
        {
            query1 = new WindowsFormsApplication1.IPQuery("1.1.1.1");
            query2 = new WindowsFormsApplication1.TypeQuery("Принтер");
            Assert.That(query1.Or(query2).IsSatisfiedBy(device1), Is.True);
            Assert.That(query1.And(query2).IsSatisfiedBy(device1), Is.False);
        }
    }
}
